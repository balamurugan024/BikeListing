  using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BikeListing.IRepository;
using BikeListing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace BikeListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BrandController> _logger;
        private readonly IMapper _mapper;

        public BrandController(IUnitOfWork unitOfWork, ILogger<BrandController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBrands()
        {
            try
            {
                var brands = await _unitOfWork.Brands.GetAll();
                var results = _mapper.Map<IList<BrandDTO>>(brands);
                return Ok(results);

            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Somthing went wrong in the {nameof(GetBrands)}");
                return StatusCode(500, "Internal Server Error, Please try again later");
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBrand(int id)
        {
            try
            {
                var brand = await _unitOfWork.Brands.Get(q => q.Id==id, new List<string> {"Bikes"});
                var results = _mapper.Map<BrandDTO>(brand);
                return Ok(results);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Somthing went wrong in the {nameof(GetBrand)}");
                return StatusCode(500, "Internal Server Error, Please try again later");
            }
        }

    }
}
