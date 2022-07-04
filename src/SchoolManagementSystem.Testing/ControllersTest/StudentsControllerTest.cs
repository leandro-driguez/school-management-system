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
using SchoolManagementSystem.Domain.Enums;
using SchoolManagementSystem.API.Dtos;

namespace SchoolManagementSystem.Testing.ControllersTest
{
    public class StudentsControllerTest
    {
        private readonly Mock<StudentsController> _mockRepo;
        private readonly StudentsController _controller;
        private readonly IMapper mapper;
        private readonly IStudentService service;

        public StudentsControllerTest()
        {
            _mockRepo = new Mock<StudentsController>();
            _controller = new StudentsController(service, mapper);
        }

        private StudentDto SeedStudent(string guid_seed = "")
        {
            StudentDto seedStudent = new StudentDto
            {
                Founds = 10,
                Name = "Unit-Testing",
                LastName = "Unit-Testing",
                PhoneNumber = 11111111,
                Address = "unit-testing",
                DateBecomedMember = DateTime.Now.ToString()
            };
            if (guid_seed != "")
            {
                seedStudent.Id = new Guid(guid_seed).ToString();
            }
            return seedStudent;
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
        public void GetAll_WhenCalled_ReturnsAllStudent()
        {
            _mockRepo.Setup(repo => repo.GetAll())
                .Returns((IActionResult)new List<StudentDto>() { new StudentDto(), new StudentDto(), new StudentDto() });
            // Act
            var okResult = _controller.GetAll() as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<StudentDto>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void GetById_WhenCalled_ReturnsOkResultAndCorrectObject()
        {
            var seedStudent = this.SeedStudent("43aaaa9c-17bd-4e17-b2ec-7603644b8f27");
            _mockRepo.Setup(p => p.GetItemById(new Guid("43aaaa9c-17bd-4e17-b2ec-7603644b8f27").ToString())).Returns((IActionResult)seedStudent);
            var okResult = _controller.GetItemById(new Guid("43aaaa9c-17bd-4e17-b2ec-7603644b8f27").ToString());
            var result = Assert.IsType<OkObjectResult>(okResult);
            var item = Assert.IsType<StudentDto>(result.Value);
            Assert.Equal(seedStudent, item);
        }

        [Fact]
        public void GetById_WhenCalled_ReturnsNotFoundsResult()
        {
            _mockRepo.Setup(p => p.GetItemById(It.IsAny<Guid>().ToString())).Throws(new KeyNotFoundException());
            var notFoundResult = _controller.GetItemById(new Guid("43bbbb9c-17bd-4e17-b2ec-7603644b8f27").ToString());
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }

        [Fact]
        public void Add_ValidStudentPassed_ReturnsCreatedResponse()
        {
            // Arrange
            StudentDto student = this.SeedStudent();
            _mockRepo.Setup(repo => repo.Post(student))
                .Returns((IActionResult)new StudentDto { Id = Guid.NewGuid().ToString(), DateBecomedMember = student.DateBecomedMember, Name = student.Name, LastName = student.LastName, PhoneNumber = student.PhoneNumber, Address = student.Address, Founds = student .Founds});
            // Act
            var createdResponse = _controller.Post(student);
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse);
        }
        [Fact]
        public void Add_ValidStudentPassed_ReturnsCreatedStudent()
        {
            // Arrange
            StudentDto student = this.SeedStudent();
            _mockRepo.Setup(repo => repo.Post(student))
               .Returns((IActionResult)new StudentDto { Id = Guid.NewGuid().ToString(), DateBecomedMember = student.DateBecomedMember, Name = student.Name,LastName = student.LastName, PhoneNumber = student.PhoneNumber, Address = student.Address, Founds = student.Founds});
            // Act
            var createdResponse = _controller.Post(student) as OkObjectResult;
            var item = createdResponse.Value as StudentDto;
            // Assert
            Assert.IsType<StudentDto>(item);
            Assert.Equal(student.Name, item.Name);
            Assert.Equal(student.LastName, item.LastName);
            Assert.Equal(student.Address, item.Address);
            Assert.Equal(student.PhoneNumber, item.PhoneNumber);
            Assert.Equal(student.Founds, item.Founds);
        }

        [Fact]
        public void Update_ValidStudentPassed_ReturnedOkResponse()
        {
            // Arrange
            StudentDto student = this.SeedStudent("43aaaa9c-17bd-4e17-b2ec-7603644b8f27");
            _mockRepo.Setup(repo => repo.Put(student))
                .Returns((IActionResult)new StudentDto { Id = student.Id, DateBecomedMember = student.DateBecomedMember, Name = student.Name,  LastName = student.LastName, PhoneNumber = 22222222, Address = student.Address,Founds= 20});
            // Act
            var createdResponse = _controller.Put(student);
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse);
        }

        [Fact]
        public void Update_ValidStudentPassed_ReturnedObjectUpdated()
        {
            // Arrange
            StudentDto student = this.SeedStudent("43aaaa9c-17bd-4e17-b2ec-7603644b8f27");
            _mockRepo.Setup(repo => repo.Put(student))
                .Returns((IActionResult)new StudentDto { Id = student.Id, DateBecomedMember = student.DateBecomedMember, Name = student.Name, LastName = student.LastName, PhoneNumber = 22222222, Address = student.Address,Founds=20});
            // Act
            var createdResponse = _controller.Put(student) as OkObjectResult;
            var item = createdResponse.Value as StudentDto;
            // Assert
            Assert.IsType<StudentDto>(item);
            Assert.Equal(student.Id, item.Id);
            Assert.Equal(22222222, item.PhoneNumber);
            Assert.Equal(student.Address, item.Address);
            Assert.Equal(student.Name, item.Name);
            Assert.Equal(student.LastName, item.LastName);
            Assert.Equal(20, item.Founds);
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
            _mockRepo.Setup(p => p.Put(It.IsAny<StudentDto>())).Throws(new KeyNotFoundException());
            var notFoundResult = _controller.Put(new StudentDto());
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }
    }
}