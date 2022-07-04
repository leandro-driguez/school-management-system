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
    public class WorkerControllerTest
    {
        private readonly Mock<WorkersController> _mockRepo;
        private readonly WorkersController _controller;
        private readonly IMapper mapper;
        private readonly IWorkerService service;

        public WorkerControllerTest()
        {
            _mockRepo = new Mock<WorkersController>();
            _controller = new WorkersController(service, mapper);
        }

        private WorkerDto SeedWorker(string guid_seed = "")
        {
            WorkerDto seedWorker = new WorkerDto
            {
                Name = "Unit-Testing",
                LastName = "Unit-Testing",
                IDCardNo = "Unit-Testing",
                PhoneNumber = 11111111,
                Address = "unit-testing",
                DateBecomedMember = DateTime.Now.ToString()
            };
            if (guid_seed != "")
            {
                seedWorker.Id = new Guid(guid_seed).ToString();
            }
            return seedWorker;
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
        public void GetAll_WhenCalled_ReturnsAllWorker()
        {
            _mockRepo.Setup(repo => repo.GetAll())
                .Returns((IActionResult)new List<WorkerDto>() { new WorkerDto(), new WorkerDto(), new WorkerDto() });
            // Act
            var okResult = _controller.GetAll() as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<WorkerDto>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void GetById_WhenCalled_ReturnsOkResultAndCorrectObject()
        {
            var seedWorker = this.SeedWorker("43aaaa9c-17bd-4e17-b2ec-7603644b8f27");
            _mockRepo.Setup(p => p.GetItemById(new Guid("43aaaa9c-17bd-4e17-b2ec-7603644b8f27").ToString())).Returns((IActionResult)seedWorker);
            var okResult = _controller.GetItemById(new Guid("43aaaa9c-17bd-4e17-b2ec-7603644b8f27").ToString());
            var result = Assert.IsType<OkObjectResult>(okResult);
            var item = Assert.IsType<WorkerDto>(result.Value);
            Assert.Equal(seedWorker, item);
        }

        [Fact]
        public void GetById_WhenCalled_ReturnsNotFoundsResult()
        {
            _mockRepo.Setup(p => p.GetItemById(It.IsAny<Guid>().ToString())).Throws(new KeyNotFoundException());
            var notFoundResult = _controller.GetItemById(new Guid("43bbbb9c-17bd-4e17-b2ec-7603644b8f27").ToString());
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }

        [Fact]
        public void Add_ValidWorkerPassed_ReturnsCreatedResponse()
        {
            // Arrange
             WorkerDto worker = this.SeedWorker();
            _mockRepo.Setup(repo => repo.Post(worker))
                .Returns((IActionResult)new WorkerDto { Id = Guid.NewGuid().ToString(), IDCardNo = worker.IDCardNo, DateBecomedMember = worker.DateBecomedMember, Name = worker.Name, LastName = worker.LastName, PhoneNumber = worker.PhoneNumber,Address = worker.Address });
            // Act
            var createdResponse = _controller.Post(worker);
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse);
        }
        [Fact]
        public void Add_ValidWorkerPassed_ReturnsCreatedWorker()
        {
            // Arrange
            WorkerDto worker = this.SeedWorker();
            _mockRepo.Setup(repo => repo.Post(worker))
                .Returns((IActionResult)new WorkerDto { Id = Guid.NewGuid().ToString(), IDCardNo = worker.IDCardNo, DateBecomedMember = worker.DateBecomedMember, Name = worker.Name, LastName = worker.LastName, PhoneNumber = worker.PhoneNumber, Address = worker.Address });
            // Act
            var createdResponse = _controller.Post(worker) as OkObjectResult;
            var item = createdResponse.Value as WorkerDto;
            // Assert
            Assert.IsType<WorkerDto>(item);
            Assert.Equal(worker.Name, item.Name);
            Assert.Equal(worker.LastName, item.LastName);
            Assert.Equal(worker.IDCardNo, item.IDCardNo);
            Assert.Equal(worker.Address, item.Address);
            Assert.Equal(worker.PhoneNumber, item.PhoneNumber);
        }

        [Fact]
        public void Update_ValidWorkerPassed_ReturnedOkResponse()
        {
            // Arrange
            WorkerDto worker = this.SeedWorker("43aaaa9c-17bd-4e17-b2ec-7603644b8f27");
            _mockRepo.Setup(repo => repo.Put(worker))
                .Returns((IActionResult)new WorkerDto { Id = worker.Id, IDCardNo = worker.IDCardNo, DateBecomedMember = worker.DateBecomedMember, Name = worker.Name,LastName = worker.LastName, PhoneNumber = 22222222, Address = worker.Address });
            // Act
            var createdResponse = _controller.Put(worker);
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse);
        }

        [Fact]
        public void Update_ValidWorkerPassed_ReturnedObjectUpdated()
        {
            // Arrange
            WorkerDto worker = this.SeedWorker("43aaaa9c-17bd-4e17-b2ec-7603644b8f27");
            _mockRepo.Setup(repo => repo.Put(worker))
                .Returns((IActionResult)new WorkerDto { Id = worker.Id, IDCardNo = worker.IDCardNo, DateBecomedMember = worker.DateBecomedMember, Name = worker.Name, LastName = worker.LastName, PhoneNumber = 22222222, Address = worker.Address });
            // Act
            var createdResponse = _controller.Put(worker) as OkObjectResult;
            var item = createdResponse.Value as WorkerDto;
            // Assert
            Assert.IsType<WorkerDto>(item);
            Assert.Equal(worker.Id, item.Id);
            Assert.Equal(22222222, item.PhoneNumber);
            Assert.Equal(worker.IDCardNo, item.IDCardNo);
            Assert.Equal(worker.Address, item.Address);
            Assert.Equal(worker.Name, item.Name);
            Assert.Equal(worker.LastName, item.LastName);
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
            _mockRepo.Setup(p => p.Put(It.IsAny<WorkerDto>())).Throws(new KeyNotFoundException());
            var notFoundResult = _controller.Put(new WorkerDto());
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }
    }
}