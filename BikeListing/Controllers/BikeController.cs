using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BikeListing.Data;
using BikeListing.IRepository;
using BikeListing.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BikeListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BikeController> _logger;
        private readonly IMapper _mapper;

        public BikeController(IUnitOfWork unitOfWork, ILogger<BikeController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBikes()
        {
            try
            {
                var bikes = await _unitOfWork.Bikes.GetAll();
                var results = _mapper.Map<IList<BikeDTO>>(bikes);
                return Ok(results);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Somthing went wrong in the {nameof(GetBikes)}");
                return StatusCode(500, "Internal Server Error, Please try again later");
            }
        }

        
        [HttpGet("{id:int}", Name = "GetBike")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBike(int id)
        {
            try
            {
                var bike = await _unitOfWork.Bikes.Get(q=>q.Id==id, new List<string>{"Brand"});
                var results = _mapper.Map<BikeDTO>(bike);
                return Ok(results);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Somthing went wrong in the {nameof(GetBike)}");
                return StatusCode(500, "Internal Server Error, Please try again later");
            }
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateBike([FromBody] CreateBikeDTO bikeDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateBike)}");
                return BadRequest(ModelState);
            }

            try
            {
                var bike = _mapper.Map<Bike>(bikeDTO);
                await _unitOfWork.Bikes.Insert(bike);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetBike", new { id = bike.Id }, bike);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Somthing went wrong in the {nameof(CreateBike)}");
                return StatusCode(500, "Internal Server Error, Please try again later");
            }

        }




    }
}
