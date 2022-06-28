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
    public class TeachersControllerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<TeachersController> _mockRepo;
        private readonly ITeacherService service;
        private readonly TeachersController _controller;

        public TeachersControllerTest()
        {
            _mockRepo = new Mock<TeachersController>();
            _controller = new TeachersController(service, mapper);
        }

        private TeacherDto SeedTeacher(string guid_seed = "")
        {
            TeacherDto seedTeacher = new TeacherDto
            {
                PhoneNumber = 11111111,
                Name = "unit-test",
                LastName = "unit-test",
                Address = "unit-test",
            };
            if (guid_seed != "")
            {
                seedTeacher.Id = new Guid(guid_seed).ToString();
            }
            return seedTeacher;
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
        public void GetAll_WhenCalled_ReturnsAllTeachers()
        {
            _mockRepo.Setup(repo => repo.GetAll()).Returns((IActionResult)new List<TeacherDto>() { new TeacherDto(), new TeacherDto(), new TeacherDto() });
            // Act
            var okResult = _controller.GetAll() as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<TeacherDto>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void GetById_WhenCalled_ReturnsOkResultAndCorrectObject()
        {
            var seedTeacher = this.SeedTeacher("43aaaa9c-17bd-4e17-b2ec-7603644b8f27");
            _mockRepo.Setup(p => p.GetItemById(new Guid("43aaaa9c-17bd-4e17-b2ec-7603644b8f27").ToString())).Returns((IActionResult)seedTeacher);
            var okResult = _controller.GetItemById(new Guid("43aaaa9c-17bd-4e17-b2ec-7603644b8f27").ToString());
            var result = Assert.IsType<OkObjectResult>(okResult);
            var item = Assert.IsType<TeacherDto>(result.Value);
            Assert.Equal(seedTeacher, item);
        }

        [Fact]
        public void GetById_WhenCalled_ReturnsNotFoundsResult()
        {
            _mockRepo.Setup(p => p.GetItemById(It.IsAny<Guid>().ToString())).Throws(new KeyNotFoundException());
            var notFoundResult = _controller.GetItemById(new Guid("43bbbb9c-17bd-4e17-b2ec-7603644b8f27").ToString());
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }

        [Fact]
        public void Add_ValidTeacherPassed_ReturnsCreatedResponse()
        {
            // Arrange
            TeacherDto teacher = this.SeedTeacher();
            _mockRepo.Setup(repo => repo.Post(teacher)).Returns((IActionResult)new TeacherDto { Id = Guid.NewGuid().ToString(), Name = teacher.Name, PhoneNumber = teacher.PhoneNumber, Address=teacher.Address, LastName=teacher.LastName });
            // Act
            var createdResponse = _controller.Post(teacher);
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse);
        }
        [Fact]
        public void Add_ValidTeacherPassed_ReturnsCreatedTeacher()
        {
            // Arrange
            TeacherDto teacher = this.SeedTeacher();
            _mockRepo.Setup(repo => repo.Post(teacher))
                .Returns((IActionResult)new TeacherDto { Id = Guid.NewGuid().ToString(), PhoneNumber = teacher.PhoneNumber, Name = teacher.Name,Address=teacher.Address,LastName=teacher.LastName });
            // Act
            var createdResponse = _controller.Post(teacher) as OkObjectResult;
            var item = createdResponse.Value as TeacherDto;
            // Assert
            Assert.IsType<TeacherDto>(item);
            Assert.Equal(teacher.PhoneNumber, item.PhoneNumber);
            Assert.Equal(teacher.Name, item.Name);
            Assert.Equal(teacher.LastName, item.LastName);
            Assert.Equal(teacher.Address, item.Address);
        }

        [Fact]
        public void Update_ValidTeacherPassed_ReturnedOkResponse()
        {
            // Arrange
            TeacherDto teacher = this.SeedTeacher("43aaaa9c-17bd-4e17-b2ec-7603644b8f27");
            _mockRepo.Setup(repo => repo.Put(teacher))
                .Returns((IActionResult)new TeacherDto { Id = teacher.Id, PhoneNumber = 22222222, Name = teacher.Name ,LastName=teacher.LastName,Address=teacher.Address});
            // Act
            var createdResponse = _controller.Put(teacher);
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse);
        }

        [Fact]
        public void Update_ValidTeacherPassed_ReturnedObjectUpdated()
        {
            // Arrange
            TeacherDto teacher = this.SeedTeacher("43aaaa9c-17bd-4e17-b2ec-7603644b8f27");
            _mockRepo.Setup(repo => repo.Put(teacher))
                .Returns((IActionResult)new TeacherDto { Id = teacher.Id, PhoneNumber = 22222222, Name = teacher.Name, LastName=teacher.LastName,Address=teacher.Address });
            // Act
            var createdResponse = _controller.Put(teacher) as OkObjectResult;
            var item = createdResponse.Value as TeacherDto;
            // Assert
            Assert.IsType<TeacherDto>(item);
            Assert.Equal(teacher.Id, item.Id);
            Assert.Equal(22222222, item.PhoneNumber);
            Assert.Equal(teacher.Name, item.Name);
            Assert.Equal(teacher.Address, item.Address);
            Assert.Equal(teacher.LastName, item.LastName);
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
            _mockRepo.Setup(p => p.Put(new TeacherDto())).Throws(new KeyNotFoundException());
            var notFoundResult = _controller.Put(new TeacherDto());
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }
    }
}
