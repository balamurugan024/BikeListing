using AutoMapper;
using BikeListing.Controllers;
using BikeListing.IRepository;
using BikeListing.Models;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;
using System.Collections.Specialized;

namespace BikeListing.Test
{
    public class BikeControllerTests
    {
        private BikeController _bikeController;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<ILogger<BikeController>> _mockLogger;
        private Mock<IMapper> _mockMapper;

        public BikeControllerTests()
        {
            _mockUnitOfWork  = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<BikeController>>();
            _mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public void TestGetBikes()
        {
            _mockUnitOfWork.Setup(unit => unit.Bikes.GetByPage(new Models.RequestParams { P });
            _bikeController = new BikeController(_mockUnitOfWork.Object, _mockLogger.Object, _mockMapper.Object);
            

        }
    }
}
{ }