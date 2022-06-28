using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SchoolManagementSystem.API.Controllers.CrudEntities;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using Xunit;

namespace SchoolManagementSystem.Testing.ControllersTest
{
    public class TuitorsControllerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<TuitorsController> _mockRepo;
        private readonly ITuitorService service;
        private readonly TuitorsController _controller;

        public TuitorsControllerTest()
        {
            _mockRepo = new Mock<TuitorsController>();
            _controller = new TuitorsController(service, mapper);
        }

        private TuitorDto SeedTuitor(string guid_seed = "")
        {
            TuitorDto seedtuitor = new TuitorDto
            {
                PhoneNumber = 11111111,
                Name = "unit-test"
            };
            if (guid_seed != "")
            {
                seedtuitor.Id = new Guid(guid_seed).ToString();
            }
            return seedtuitor;
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
        public void GetAll_WhenCalled_ReturnsAllCourseGroups()
        {
            _mockRepo.Setup(repo => repo.GetAll()).Returns((IActionResult)new List<TuitorDto>() { new TuitorDto(), new TuitorDto(), new TuitorDto() });
            // Act
            var okResult = _controller.GetAll() as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<TuitorDto>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void GetById_WhenCalled_ReturnsOkResultAndCorrectObject()
        {
            var seedTuitor = this.SeedTuitor("43aaaa9c-17bd-4e17-b2ec-7603644b8f27");
            _mockRepo.Setup(p => p.GetItemById(new Guid("43aaaa9c-17bd-4e17-b2ec-7603644b8f27").ToString())).Returns((IActionResult)seedTuitor);
            var okResult = _controller.GetItemById(new Guid("43aaaa9c-17bd-4e17-b2ec-7603644b8f27").ToString());
            var result = Assert.IsType<OkObjectResult>(okResult);
            var item = Assert.IsType<TuitorDto>(result.Value);
            Assert.Equal(seedTuitor, item);
        }

        [Fact]
        public void GetById_WhenCalled_ReturnsNotFoundsResult()
        {
            _mockRepo.Setup(p => p.GetItemById(It.IsAny<Guid>().ToString())).Throws(new KeyNotFoundException());
            var notFoundResult = _controller.GetItemById(new Guid("43bbbb9c-17bd-4e17-b2ec-7603644b8f27").ToString());
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }

        [Fact]
        public void Add_ValidTuitorPassed_ReturnsCreatedResponse()
        {
            // Arrange
            TuitorDto tuitor = this.SeedTuitor();
            _mockRepo.Setup(repo => repo.Post(tuitor)).Returns((IActionResult)new TuitorDto { Id = Guid.NewGuid().ToString(),Name = tuitor.Name, PhoneNumber=tuitor.PhoneNumber });
            // Act
            var createdResponse = _controller.Post(tuitor);
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse);
        }
        [Fact]
        public void Add_ValidTuitorPassed_ReturnsCreatedTuitor()
        {
            // Arrange
            TuitorDto tuitor = this.SeedTuitor();
            _mockRepo.Setup(repo => repo.Post(tuitor))
                .Returns((IActionResult)new TuitorDto { Id = Guid.NewGuid().ToString(), PhoneNumber = tuitor.PhoneNumber, Name = tuitor.Name });
            // Act
            var createdResponse = _controller.Post(tuitor) as OkObjectResult;
            var item = createdResponse.Value as TuitorDto;
            // Assert
            Assert.IsType<TuitorDto>(item);
            Assert.Equal(tuitor.PhoneNumber, item.PhoneNumber);
            Assert.Equal(tuitor.Name, item.Name);
        }

        [Fact]
        public void Update_ValidTuitorPassed_ReturnedOkResponse()
        {
            // Arrange
            TuitorDto tuitor = this.SeedTuitor("43aaaa9c-17bd-4e17-b2ec-7603644b8f27");
            _mockRepo.Setup(repo => repo.Put(tuitor))
                .Returns((IActionResult)new TuitorDto { Id = tuitor.Id, PhoneNumber = 22222222, Name = tuitor.Name});
            // Act
            var createdResponse = _controller.Put(tuitor);
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse);
        }

        [Fact]
        public void Update_ValidTuitorPassed_ReturnedObjectUpdated()
        {
            // Arrange
            TuitorDto tuitor = this.SeedTuitor("43aaaa9c-17bd-4e17-b2ec-7603644b8f27");
            _mockRepo.Setup(repo => repo.Put(tuitor))
                .Returns((IActionResult)new TuitorDto { Id = tuitor.Id, PhoneNumber = 22222222, Name = tuitor.Name});
            // Act
            var createdResponse = _controller.Put(tuitor) as OkObjectResult;
            var item = createdResponse.Value as TuitorDto;
            // Assert
            Assert.IsType<TuitorDto>(item);
            Assert.Equal(tuitor.Id, item.Id);
            Assert.Equal(22222222, item.PhoneNumber);
            Assert.Equal(tuitor.Name, item.Name);
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
            _mockRepo.Setup(p => p.Put(new TuitorDto())).Throws(new KeyNotFoundException());
            var notFoundResult = _controller.Put(new TuitorDto());
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }
    }
}
