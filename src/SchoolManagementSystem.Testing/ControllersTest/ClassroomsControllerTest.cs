using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using AutoMapper;
using SchoolManagementSystem.API.Mappers;
using SchoolManagementSystem.API.Controllers.CrudEntities;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.API.Dtos;

namespace SchoolManagementSystem.Testing.ControllersTest
{
    public class ClassroomsControllerTest
    {
        private readonly Mock<ClassroomsController> _mockRepo;
        private readonly IClassroomService service;
        private readonly ClassroomsController _controller;
        private readonly IMapper mapper;

        public ClassroomsControllerTest()
        {
            _mockRepo = new Mock<ClassroomsController>();
            _controller = new ClassroomsController(service, mapper);
        }

        private ClassroomDto SeedClassrooms(string guid_seed = "")
        {
            ClassroomDto seedClassrooms = new ClassroomDto
            {
                Name = "unit-test",
                Capacity = 10
            };
            if (guid_seed != "")
            {
                seedClassrooms.Id = new Guid(guid_seed).ToString();
            }
            return seedClassrooms;
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
        public void GetAll_WhenCalled_ReturnsAllClassrooms()
        {
            _mockRepo.Setup(repo => repo.GetAll())
                .Returns((IActionResult)new List<ClassroomDto>() { new ClassroomDto(), new ClassroomDto(), new ClassroomDto() });
            // Act
            var okResult = _controller.GetAll() as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<ClassroomDto>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void GetById_WhenCalled_ReturnsOkResultAndCorrectObject()
        {
            var seedClassroom = this.SeedClassrooms("43aaaa9c-17bd-4e17-b2ec-7603644b8f27");
            _mockRepo.Setup(p => p.GetItemById(new Guid("43aaaa9c-17bd-4e17-b2ec-7603644b8f27").ToString())).Returns((IActionResult)seedClassroom);
            var okResult = _controller.GetItemById(new Guid("43aaaa9c-17bd-4e17-b2ec-7603644b8f27").ToString());
            var result = Assert.IsType<OkObjectResult>(okResult);
            var item = Assert.IsType<ClassroomDto>(result.Value);
            Assert.Equal(seedClassroom, item);
        }

        [Fact]
        public void GetById_WhenCalled_ReturnsNotFoundsResult()
        {
            _mockRepo.Setup(p => p.GetItemById(It.IsAny<Guid>().ToString())).Throws(new KeyNotFoundException());
            var notFoundResult = _controller.GetItemById(new Guid("43bbbb9c-17bd-4e17-b2ec-7603644b8f27").ToString());
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }

        [Fact]
        public void Add_ValidClassroomPassed_ReturnsCreatedResponse()
        {
            // Arrange
            ClassroomDto classroom = this.SeedClassrooms();
            _mockRepo.Setup(repo => repo.Post(classroom))
                .Returns((IActionResult)new ClassroomDto { Id = Guid.NewGuid().ToString(),  Capacity = classroom.Capacity, Name = classroom.Name });
            // Act
            var createdResponse = _controller.Post(classroom);
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse);
        }
        [Fact]
        public void Add_ValidClassroomPassed_ReturnsCreatedClassroom()
        {
            // Arrange
            ClassroomDto classroom = this.SeedClassrooms();
            _mockRepo.Setup(repo => repo.Post(classroom))
                .Returns((IActionResult)new ClassroomDto { Id = Guid.NewGuid().ToString(), Capacity = classroom.Capacity, Name = classroom.Name });
            // Act
            var createdResponse = _controller.Post(classroom) as OkObjectResult;
            var item = createdResponse.Value as ClassroomDto;
            // Assert
            Assert.IsType<ClassroomDto>(item);
            Assert.Equal(classroom.Capacity, item.Capacity);
            Assert.Equal(classroom.Name, item.Name);
        }

        [Fact]
        public void Update_ValidClassroomPassed_ReturnedOkResponse()
        {
            // Arrange
            ClassroomDto classroom = this.SeedClassrooms("43aaaa9c-17bd-4e17-b2ec-7603644b8f27");
            _mockRepo.Setup(repo => repo.Put(classroom))
                .Returns((IActionResult)new ClassroomDto { Id = classroom.Id, Capacity = 30, Name = classroom.Name});
            // Act
            var createdResponse = _controller.Put(classroom);
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse);
        }

        [Fact]
        public void Update_ValidClassroomPassed_ReturnedObjectUpdated()
        {
            // Arrange
            ClassroomDto classroom = this.SeedClassrooms("43aaaa9c-17bd-4e17-b2ec-7603644b8f27");
            _mockRepo.Setup(repo => repo.Put(classroom))
                .Returns((IActionResult)new ClassroomDto { Id = classroom.Id, Capacity = 30, Name = classroom.Name});
            // Act
            var createdResponse = _controller.Put(classroom) as OkObjectResult;
            var item = createdResponse.Value as ClassroomDto;
            // Assert
            Assert.IsType<ClassroomDto>(item);
            Assert.Equal(classroom.Id, item.Id);
            Assert.Equal(30, item.Capacity);
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
            _mockRepo.Setup(p => p.Put(It.IsAny<ClassroomDto>())).Throws(new KeyNotFoundException());
            var notFoundResult = _controller.Put(new ClassroomDto());
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }
    }
}