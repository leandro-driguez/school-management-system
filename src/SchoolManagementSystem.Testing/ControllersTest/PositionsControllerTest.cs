using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using AutoMapper;
using Xunit;
using SchoolManagementSystem.API.Mappers;
using SchoolManagementSystem.API.Controllers.CrudEntities;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.API.Dtos;

namespace SchoolManagementSystem.Testing.ControllersTest
{
    public class PositionsControllerTest
    {
        private readonly Mock<PositionsController> _mockRepo;
        private readonly PositionsController _controller;
        private readonly IMapper mapper;
        private readonly IPositionService service;

        public PositionsControllerTest()
        {
            _mockRepo = new Mock<PositionsController>();
            _controller = new PositionsController(service, mapper);
        }

        private PositionDto SeedPosition(string guid_seed = "")
        {
            PositionDto seedPosition = new PositionDto
            {
                Name = "Unit-Testing"
            };
            if (guid_seed != "")
            {
                seedPosition.Id = new Guid(guid_seed).ToString();
            }
            return seedPosition;
        }

        [Fact]
        public void GetAll_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetAll();
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void GetAll_WhenCalled_ReturnsAllPosition()
        {
            _mockRepo.Setup(repo => repo.GetAll())
                .Returns((IActionResult)new List<PositionDto>() { new PositionDto(), new PositionDto(), new PositionDto() });
            // Act
            var okResult = _controller.GetAll() as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<PositionDto>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void GetById_WhenCalled_ReturnsOkResultAndCorrectObject()
        {
            var seedPosition = this.SeedPosition("43aaaa9c-17bd-4e17-b2ec-7603644b8f27");
            _mockRepo.Setup(p => p.GetItemById(new Guid("43aaaa9c-17bd-4e17-b2ec-7603644b8f27").ToString())).Returns((IActionResult)seedPosition);
            var okResult = _controller.GetItemById(new Guid("43aaaa9c-17bd-4e17-b2ec-7603644b8f27").ToString());
            var result = Assert.IsType<OkObjectResult>(okResult);
            var item = Assert.IsType<PositionDto>(result.Value);
            Assert.Equal(seedPosition, item);
        }

        [Fact]
        public void GetById_WhenCalled_ReturnsNotFoundsResult()
        {
            _mockRepo.Setup(p => p.GetItemById(It.IsAny<Guid>().ToString())).Throws(new KeyNotFoundException());
            var notFoundResult = _controller.GetItemById(new Guid("43bbbb9c-17bd-4e17-b2ec-7603644b8f27").ToString());
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }

        [Fact]
        public void Add_ValidPositionPassed_ReturnsCreatedResponse()
        {
            // Arrange
            PositionDto position = this.SeedPosition();
            _mockRepo.Setup(repo => repo.Post(position))
                .Returns((IActionResult)new PositionDto { Id = Guid.NewGuid().ToString(), Name = position.Name});
            // Act
            var createdResponse = _controller.Post(position);
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse);
        }
        [Fact]
        public void Add_ValidPositionPassed_ReturnsCreatedPosition()
        {
            // Arrange
            PositionDto position = this.SeedPosition();
            _mockRepo.Setup(repo => repo.Post(position))
                .Returns((IActionResult)new PositionDto { Id = Guid.NewGuid().ToString(), Name = position.Name});
            // Act
            var createdResponse = _controller.Post(position) as OkObjectResult;
            var item = createdResponse.Value as PositionDto;
            // Assert
            Assert.IsType<PositionDto>(item);
            Assert.Equal(position.Name, item.Name);
        }

        [Fact]
        public void Update_ValidPositionPassed_ReturnedOkResponse()
        {
            // Arrange
            PositionDto position = this.SeedPosition("43aaaa9c-17bd-4e17-b2ec-7603644b8f27");
            _mockRepo.Setup(repo => repo.Put(position))
                .Returns((IActionResult)new PositionDto { Id = position.Id, Name ="test"});
            // Act
            var createdResponse = _controller.Put(position);
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse);
        }

        [Fact]
        public void Update_ValidPositionPassed_ReturnedObjectUpdated()
        {
            // Arrange
            PositionDto position = this.SeedPosition("43aaaa9c-17bd-4e17-b2ec-7603644b8f27");
            _mockRepo.Setup(repo => repo.Put(position))
                .Returns((IActionResult)new PositionDto { Id = position.Id, Name="Test"});
            // Act
            var createdResponse = _controller.Put(position) as OkObjectResult;
            var item = createdResponse.Value as PositionDto;
            // Assert
            Assert.IsType<PositionDto>(item);
            Assert.Equal(position.Id, item.Id);
            Assert.Equal(position.Name, item.Name);
        }

        [Fact]
        public void Delete_Valid_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Delete("");
            // Assert
            Assert.IsType<OkResult>(okResult);
        }

        [Fact]
        public void Delete_InValid_ReturnsNotFoundsResult()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.Delete(It.IsAny<Guid>().ToString())).Throws(new KeyNotFoundException());
            // Act
            var notFoundResult = _controller.Delete(new Guid().ToString());
            // Assert
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }

        [Fact]
        public void Update_Invalid_ReturnNotFoundResult()
        {
            _mockRepo.Setup(p => p.Put(It.IsAny<PositionDto>())).Throws(new KeyNotFoundException());
            var notFoundResult = _controller.Put(new PositionDto());
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }
    }
}