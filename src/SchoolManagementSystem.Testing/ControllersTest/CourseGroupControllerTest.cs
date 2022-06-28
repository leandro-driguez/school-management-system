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
    public class CourseGroupControllerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<CourseGroupsController> _mockRepo;
        private readonly ICourseGroupService service;
        private readonly CourseGroupsController _controller;

        public CourseGroupControllerTest()
        {
            _mockRepo = new Mock<CourseGroupsController>();
            _controller = new CourseGroupsController(service, mapper);
        }

        private CourseGroupDto SeedCourseGroup(string guid_seed = "")
        {
            CourseGroupDto seedCourseGroup = new CourseGroupDto
            {
                Capacity = 10,
                Name = "unit-test",
                CourseId = "unit-test",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };
            if (guid_seed != "")
            {
                seedCourseGroup.Id = new Guid(guid_seed).ToString();
            }
            return seedCourseGroup;
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
            _mockRepo.Setup(repo => repo.GetAll()).Returns((IActionResult)new List<CourseGroupDto>() { new CourseGroupDto(), new CourseGroupDto(), new CourseGroupDto() });
            // Act
            var okResult = _controller.GetAll() as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<CourseGroupDto>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void GetById_WhenCalled_ReturnsOkResultAndCorrectObject()
        {
            var seedCourseGroup = this.SeedCourseGroup("43aaaa9c-17bd-4e17-b2ec-7603644b8f27");
            _mockRepo.Setup(p => p.GetItemById(new Guid("43aaaa9c-17bd-4e17-b2ec-7603644b8f27").ToString())).Returns((IActionResult)seedCourseGroup);
            var okResult = _controller.GetItemById(new Guid("43aaaa9c-17bd-4e17-b2ec-7603644b8f27").ToString());
            var result = Assert.IsType<OkObjectResult>(okResult);
            var item = Assert.IsType<CourseGroupDto>(result.Value);
            Assert.Equal(seedCourseGroup, item);
        }

        [Fact]
        public void GetById_WhenCalled_ReturnsNotFoundsResult()
        {
            _mockRepo.Setup(p => p.GetItemById(It.IsAny<Guid>().ToString())).Throws(new KeyNotFoundException());
            var notFoundResult = _controller.GetItemById(new Guid("43bbbb9c-17bd-4e17-b2ec-7603644b8f27").ToString());
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }

        [Fact]
        public void Add_ValidCourseGroupPassed_ReturnsCreatedResponse()
        {
            // Arrange
            CourseGroupDto courseGroup = this.SeedCourseGroup();
            _mockRepo.Setup(repo => repo.Post(courseGroup)).Returns((IActionResult)new CourseGroupDto { Id = Guid.NewGuid().ToString(), Capacity = courseGroup.Capacity, EndDate=courseGroup.EndDate,StartDate=courseGroup.StartDate,Name=courseGroup.Name,CourseId=courseGroup.CourseId });
            // Act
            var createdResponse = _controller.Post(courseGroup);
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse);
        }
        [Fact]
        public void Add_ValidCourseGroupPassed_ReturnsCreatedCourseGroup()
        {
            // Arrange
            CourseGroupDto courseGroup = this.SeedCourseGroup();
            _mockRepo.Setup(repo => repo.Post(courseGroup))
                .Returns((IActionResult)new CourseGroupDto { Id = Guid.NewGuid().ToString(), Capacity=courseGroup.Capacity,Name=courseGroup.Name,CourseId=courseGroup.CourseId,EndDate=courseGroup.EndDate,StartDate=courseGroup.StartDate});
            // Act
            var createdResponse = _controller.Post(courseGroup) as OkObjectResult;
            var item = createdResponse.Value as CourseGroupDto;
            // Assert
            Assert.IsType<CourseGroupDto>(item);
            Assert.Equal(courseGroup.Capacity, item.Capacity);
            Assert.Equal(courseGroup.Name, item.Name);
            Assert.Equal(courseGroup.CourseId, item.CourseId);
        }

        [Fact]
        public void Update_ValidCourseGroupPassed_ReturnedOkResponse()
        {
            // Arrange
            CourseGroupDto courseGroup = this.SeedCourseGroup("43aaaa9c-17bd-4e17-b2ec-7603644b8f27");
            _mockRepo.Setup(repo => repo.Put(courseGroup))
                .Returns((IActionResult)new CourseGroupDto { Id = courseGroup.Id, Capacity = 30, Name=courseGroup.Name, EndDate=courseGroup.EndDate,CourseId=courseGroup.CourseId,StartDate=courseGroup.StartDate});
            // Act
            var createdResponse = _controller.Put(courseGroup);
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse);
        }

        [Fact]
        public void Update_ValidCourseGroupPassed_ReturnedObjectUpdated()
        {
            // Arrange
            CourseGroupDto courseGroup = this.SeedCourseGroup("43aaaa9c-17bd-4e17-b2ec-7603644b8f27");
            _mockRepo.Setup(repo => repo.Put(courseGroup))
                .Returns((IActionResult)new CourseGroupDto { Id = courseGroup.Id, Capacity = 30, Name=courseGroup.Name,CourseId=courseGroup.CourseId,EndDate=courseGroup.EndDate,StartDate=courseGroup.StartDate});
            // Act
            var createdResponse = _controller.Put(courseGroup) as OkObjectResult;
            var item = createdResponse.Value as CourseGroupDto;
            // Assert
            Assert.IsType<CourseGroupDto>(item);
            Assert.Equal(courseGroup.Id, item.Id);
            Assert.Equal(30, item.Capacity);
            Assert.Equal(courseGroup.Name, item.Name);
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
            _mockRepo.Setup(p => p.Put(new CourseGroupDto())).Throws(new KeyNotFoundException());
            var notFoundResult = _controller.Put(new CourseGroupDto());
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }
    }
}
