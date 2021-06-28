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
   
    [ApiVersion("2.0")]
    [Route("api/{v:apiversion}/bike")]
    [ApiController]
    public class BikeV2Controller : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BikeController> _logger;
        private readonly IMapper _mapper;

        public BikeV2Controller(IUnitOfWork unitOfWork, ILogger<BikeController> logger, IMapper mapper)
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
            var bikes = await _unitOfWork.Bikes.GetAll();
            var results = _mapper.Map<IList<BikeDTO>>(bikes);
            return Ok(results);
        }

    }
}
