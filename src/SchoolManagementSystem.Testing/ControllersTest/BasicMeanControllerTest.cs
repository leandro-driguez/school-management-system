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
    public class BasicMeanControllerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<BasicMeanController> _mockRepo;
        private readonly IBasicMeanService service;
        private readonly BasicMeanController _controller;

        public BasicMeanControllerTest()
        {
            _mockRepo = new Mock<BasicMeanController>();
            _controller = new BasicMeanController(service, mapper);
        }

        private BasicMeanDto SeedBasicMean(string guid_seed = "")
        {
            BasicMeanDto seedBasicMean = new BasicMeanDto
            {
                Price = 10,
                Type = "unit-test",
                Origin = "unit-test",
                DevaluationInTime = 10,
                InaugurationDate = DateTime.Now,
                Description = "unit-testing"
            };
            if (guid_seed != "")
            {
                seedBasicMean.Id = new Guid(guid_seed).ToString();
            }
            return seedBasicMean;
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
        public void GetAll_WhenCalled_ReturnsAllBasicMeans()
        {
            _mockRepo.Setup(repo => repo.GetAll()).Returns((IActionResult)new List<BasicMeanDto>() { new BasicMeanDto(), new BasicMeanDto(), new BasicMeanDto() });
            // Act
            var okResult = _controller.GetAll() as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<BasicMeanDto>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void GetById_WhenCalled_ReturnsOkResultAndCorrectObject()
        {
            var seedBasicMean = this.SeedBasicMean("43aaaa9c-17bd-4e17-b2ec-7603644b8f27");
            _mockRepo.Setup(p => p.GetItemById(new Guid("43aaaa9c-17bd-4e17-b2ec-7603644b8f27").ToString())).Returns((IActionResult)seedBasicMean);
            var okResult = _controller.GetItemById(new Guid("43aaaa9c-17bd-4e17-b2ec-7603644b8f27").ToString());
            var result = Assert.IsType<OkObjectResult>(okResult);
            var item = Assert.IsType<BasicMeanDto>(result.Value);
            Assert.Equal(seedBasicMean, item);
        }

        [Fact]
        public void GetById_WhenCalled_ReturnsNotFoundsResult()
        {
            _mockRepo.Setup(p => p.GetItemById(It.IsAny<Guid>().ToString())).Throws(new KeyNotFoundException());
            var notFoundResult = _controller.GetItemById(new Guid("43bbbb9c-17bd-4e17-b2ec-7603644b8f27").ToString());
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }

        [Fact]
        public void Add_ValidBasicMeanPassed_ReturnsCreatedResponse()
        {
            // Arrange
            BasicMeanDto basicmean = this.SeedBasicMean();
            _mockRepo.Setup(repo => repo.Post(basicmean)).Returns( (IActionResult)new BasicMeanDto { Id = Guid.NewGuid().ToString(), Price = basicmean.Price, DevaluationInTime = basicmean.DevaluationInTime, Type = basicmean.Type, Origin = basicmean.Origin, InaugurationDate = basicmean.InaugurationDate, Description = basicmean.Description });
            // Act
            var createdResponse = _controller.Post(basicmean);
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse);
        }
        [Fact]
        public void Add_ValidBasicMeanPassed_ReturnsCreatedBasicMean()
        {
            // Arrange
            BasicMeanDto basicmean = this.SeedBasicMean();
            _mockRepo.Setup(repo => repo.Post(basicmean))
                .Returns((IActionResult)new BasicMeanDto { Id = Guid.NewGuid().ToString(), Price = basicmean.Price, DevaluationInTime = basicmean.DevaluationInTime, Type = basicmean.Type, Origin = basicmean.Origin, InaugurationDate = basicmean.InaugurationDate, Description = basicmean.Description });
            // Act
            var createdResponse = _controller.Post(basicmean) as OkObjectResult;
            var item = createdResponse.Value as BasicMeanDto;
            // Assert
            Assert.IsType<BasicMeanDto>(item);
            Assert.Equal(basicmean.Price, item.Price);
            Assert.Equal(basicmean.Type, item.Type);
            Assert.Equal(basicmean.DevaluationInTime, item.DevaluationInTime);
            Assert.Equal(basicmean.Origin, item.Origin);
            Assert.Equal(basicmean.Description, item.Description);
            Assert.Equal(basicmean.InaugurationDate, item.InaugurationDate);
        }

        [Fact]
        public void Update_ValidBasicMeanPassed_ReturnedOkResponse()
        {
            // Arrange
            BasicMeanDto basicmean = this.SeedBasicMean("43aaaa9c-17bd-4e17-b2ec-7603644b8f27");
            _mockRepo.Setup(repo => repo.Put(basicmean))
                .Returns((IActionResult)new BasicMeanDto { Id = basicmean.Id, Price = 30, Type = basicmean.Type, DevaluationInTime = 30, Origin = basicmean.Origin, InaugurationDate = basicmean.InaugurationDate, Description = basicmean.Description });
            // Act
            var createdResponse = _controller.Put(basicmean);
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse);
        }

        [Fact]
        public void Update_ValidBasicMeanPassed_ReturnedObjectUpdated()
        {
            // Arrange
            BasicMeanDto basicmean = this.SeedBasicMean("43aaaa9c-17bd-4e17-b2ec-7603644b8f27");
            _mockRepo.Setup(repo => repo.Put(basicmean))
                .Returns((IActionResult)new BasicMeanDto { Id = basicmean.Id, Price = 30, Type = basicmean.Type, DevaluationInTime = 30, Origin = basicmean.Origin, InaugurationDate = basicmean.InaugurationDate, Description = basicmean.Description });
            // Act
            var createdResponse = _controller.Put(basicmean) as OkObjectResult;
            var item = createdResponse.Value as BasicMeanDto;
            // Assert
            Assert.IsType<BasicMeanDto>(item);
            Assert.Equal(basicmean.Id, item.Id);
            Assert.Equal(30, item.Price);
            Assert.Equal(30, item.DevaluationInTime);
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
            _mockRepo.Setup(p => p.Put(new BasicMeanDto())).Throws(new KeyNotFoundException());
            var notFoundResult = _controller.Put(new BasicMeanDto());
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }
    }
}

