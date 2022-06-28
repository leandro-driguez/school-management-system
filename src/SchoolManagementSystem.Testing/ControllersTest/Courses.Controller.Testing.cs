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
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.API.Dtos;

namespace SchoolManagementSystem.Testing.ControllersTest
{
    public class CoursesControllerTest
    {
        private readonly Mock<CoursesController> _mockRepo;
        private readonly CoursesController _controller;
        private readonly IMapper mapper;
        private readonly ICourseService service;

        public CoursesControllerTest()
        {
            _mockRepo = new Mock<CoursesController>();
            _controller = new CoursesController(service, mapper);
        }

        private CourseDto SeedCourse(string guid_seed = "")
        {
            CourseDto seedCourse = new CourseDto
            {
                Price = 10,
                Type = "unit-test",
                Name = "Unit-Testing"
            };
            if (guid_seed != "")
            {
                seedCourse.Id = new Guid(guid_seed).ToString();
            }
            return seedCourse;
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
        public void GetAll_WhenCalled_ReturnsAllExpense()
        {
            _mockRepo.Setup(repo => repo.GetAll())
                .Returns((IActionResult)new List<CourseDto>() { new CourseDto(), new CourseDto(), new CourseDto() });
            // Act
            var okResult = _controller.GetAll() as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<CourseDto>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void GetById_WhenCalled_ReturnsOkResultAndCorrectObject()
        {
            var seedCourse = this.SeedCourse("43aaaa9c-17bd-4e17-b2ec-7603644b8f27");
            _mockRepo.Setup(p => p.GetItemById(new Guid("43aaaa9c-17bd-4e17-b2ec-7603644b8f27").ToString())).Returns((IActionResult)seedCourse);
            var okResult = _controller.GetItemById(new Guid("43aaaa9c-17bd-4e17-b2ec-7603644b8f27").ToString());
            var result = Assert.IsType<OkObjectResult>(okResult);
            var item = Assert.IsType<CourseDto>(result.Value);
            Assert.Equal(seedCourse, item);
        }

        [Fact]
        public void GetById_WhenCalled_ReturnsNotFoundsResult()
        {
            _mockRepo.Setup(p => p.GetItemById(It.IsAny<Guid>().ToString())).Throws(new KeyNotFoundException());
            var notFoundResult = _controller.GetItemById(new Guid("43bbbb9c-17bd-4e17-b2ec-7603644b8f27").ToString());
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }

        [Fact]
        public void Add_ValidCoursePassed_ReturnsCreatedResponse()
        {
            // Arrange
            CourseDto course = this.SeedCourse();
            _mockRepo.Setup(repo => repo.Post(course))
                .Returns((IActionResult)new CourseDto { Id = Guid.NewGuid().ToString(), Name=course.Name,Type=course.Type, Price=course.Price });
            // Act
            var createdResponse = _controller.Post(course);
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse);
        }
        [Fact]
        public void Add_ValidCoursePassed_ReturnsCreatedCourse()
        {
            // Arrange
            CourseDto course = this.SeedCourse();
            _mockRepo.Setup(repo => repo.Post(course))
                .Returns((IActionResult)new CourseDto { Id = Guid.NewGuid().ToString(), Name= course.Name, Type = course.Type, Price = course.Price});
            // Act
            var createdResponse = _controller.Post(course) as OkObjectResult;
            var item = createdResponse.Value as CourseDto;
            // Assert
            Assert.IsType<CourseDto>(item);
            Assert.Equal(course.Name, item.Name);
            Assert.Equal(course.Price, item.Price);
        }

        [Fact]
        public void Update_ValidCoursePassed_ReturnedOkResponse()
        {
            // Arrange
            CourseDto course = this.SeedCourse("43aaaa9c-17bd-4e17-b2ec-7603644b8f27");
            _mockRepo.Setup(repo => repo.Put(course))
                .Returns((IActionResult)new CourseDto { Id = course.Id, Name = course.Name, Price=30,Type=course.Type});
            // Act
            var createdResponse = _controller.Put(course);
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse);
        }

        [Fact]
        public void Update_ValidCoursePassed_ReturnedObjectUpdated()
        {
            // Arrange
            CourseDto course = this.SeedCourse("43aaaa9c-17bd-4e17-b2ec-7603644b8f27");
            _mockRepo.Setup(repo => repo.Put(course))
                .Returns((IActionResult)new CourseDto { Id = course.Id, Name = course.Name, Price = course.Price, Type=course.Type});
            // Act
            var createdResponse = _controller.Put(course) as OkObjectResult;
            var item = createdResponse.Value as CourseDto;
            // Assert
            Assert.IsType<CourseDto>(item);
            Assert.Equal(course.Id, item.Id);
            Assert.Equal(course.Name, item.Name);
            Assert.Equal(30, item.Price);
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
            _mockRepo.Setup(p => p.Put(It.IsAny<CourseDto>())).Throws(new KeyNotFoundException());
            var notFoundResult = _controller.Put(new CourseDto());
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }
    }
}