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
        public async Task<IActionResult> GetBikes([FromQuery] RequestParams requestParams)
        {

                var bikes = await _unitOfWork.Bikes.GetByPage(requestParams);
                var results = _mapper.Map<IList<BikeDTO>>(bikes);
                return Ok(results);

        }


        [HttpGet("{id:int}", Name = "GetBike")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBike(int id)
        {
            
                var bike = await _unitOfWork.Bikes.Get(q=>q.Id==id, new List<string>{"Brand"});
                var results = _mapper.Map<BikeDTO>(bike);
                return Ok(results);
           
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

                var bike = _mapper.Map<Bike>(bikeDTO);
                await _unitOfWork.Bikes.Insert(bike);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetBike", new { id = bike.Id }, bike);

        }


        [Authorize]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateBike(int id, [FromBody] UpdateBikeDTO bikeDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(UpdateBike)}");
                return BadRequest(ModelState);
            }

          
                var bike = await _unitOfWork.Bikes.Get(q => q.Id == id);
                if(bike ==  null)    
                {
                    _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateBike)}");
                    return BadRequest("Submitted data is Invalid");
                }

                _mapper.Map(bikeDTO, bike);
                _unitOfWork.Bikes.Update(bike);
                await _unitOfWork.Save();

                return NoContent();
           

        }

        [Authorize(Roles ="Admin")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteBike(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid Delete Attempt in {nameof(DeleteBike)}");
                return BadRequest();
            }

         
                var bike = await _unitOfWork.Bikes.Get(q => q.Id == id);
                if (bike == null)
                {
                    _logger.LogError($"Invalid Delete attempt in {nameof(DeleteBike)}");
                    return BadRequest("Submitted data is Invalid");
                }

                
                await _unitOfWork.Bikes.Delete(id);
                await _unitOfWork.Save();

                return NoContent();
            

        }

    }
}
