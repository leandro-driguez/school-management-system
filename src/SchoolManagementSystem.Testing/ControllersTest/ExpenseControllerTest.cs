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
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.API.Dtos;

namespace SchoolManagementSystem.Testing.ControllersTest
{
    public class ExpenseControllerTest
    {
        private readonly Mock<ExpensesController> _mockRepo;
        private readonly ExpensesController _controller;
        private readonly IMapper mapper;
        private readonly IExpenseService service;

        public ExpenseControllerTest()
        {
            _mockRepo = new Mock<ExpensesController>();
            _controller = new ExpensesController(service, mapper);
        }

        private ExpenseDto SeedExpense(string guid_seed = "")
        {
            ExpenseDto seedExpense = new ExpenseDto
            {
                Category = "unit-test",
                Description = "Unit-Testing"
            };
            if (guid_seed != "")
            {
                seedExpense.Id = new Guid(guid_seed).ToString();
            }
            return seedExpense;
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
                .Returns((IActionResult)new List<ExpenseDto>() { new ExpenseDto(), new ExpenseDto(), new ExpenseDto() });
            // Act
            var okResult = _controller.GetAll() as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<ExpenseDto>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void GetById_WhenCalled_ReturnsOkResultAndCorrectObject()
        {
            var seedExpense = this.SeedExpense("43aaaa9c-17bd-4e17-b2ec-7603644b8f27");
            _mockRepo.Setup(p => p.GetItemById(new Guid("43aaaa9c-17bd-4e17-b2ec-7603644b8f27").ToString())).Returns((IActionResult)seedExpense);
            var okResult = _controller.GetItemById(new Guid("43aaaa9c-17bd-4e17-b2ec-7603644b8f27").ToString());
            var result = Assert.IsType<OkObjectResult>(okResult);
            var item = Assert.IsType<ExpenseDto>(result.Value);
            Assert.Equal(seedExpense, item);
        }

        [Fact]
        public void GetById_WhenCalled_ReturnsNotFoundsResult()
        {
            _mockRepo.Setup(p => p.GetItemById(It.IsAny<Guid>().ToString())).Throws(new KeyNotFoundException());
            var notFoundResult = _controller.GetItemById(new Guid("43bbbb9c-17bd-4e17-b2ec-7603644b8f27").ToString());
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }

        [Fact]
        public void Add_ValidExpensePassed_ReturnsCreatedResponse()
        {
            // Arrange
            ExpenseDto expense = this.SeedExpense();
            _mockRepo.Setup(repo => repo.Post(expense))
                .Returns((IActionResult)new ExpenseDto { Id = Guid.NewGuid().ToString(), Category = expense.Category,Description = expense.Description});
            // Act
            var createdResponse = _controller.Post(expense);
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse);
        }
        [Fact]
        public void Add_ValidExpensePassed_ReturnsCreatedCourse()
        {
            // Arrange
            ExpenseDto expense = this.SeedExpense();
            _mockRepo.Setup(repo => repo.Post(expense))
                .Returns((IActionResult)new ExpenseDto { Id = Guid.NewGuid().ToString(), Category = expense.Category, Description= expense.Description});
            // Act
            var createdResponse = _controller.Post(expense) as OkObjectResult;
            var item = createdResponse.Value as ExpenseDto;
            // Assert
            Assert.IsType<ExpenseDto>(item);
            Assert.Equal(expense.Category, item.Category);
            Assert.Equal(expense.Description, item.Description);
        }

        [Fact]
        public void Update_ValidExpensePassed_ReturnedOkResponse()
        {
            // Arrange
            ExpenseDto expense = this.SeedExpense("43aaaa9c-17bd-4e17-b2ec-7603644b8f27");
            _mockRepo.Setup(repo => repo.Put(expense))
                .Returns((IActionResult)new ExpenseDto { Id = expense.Id, Category = "test" , Description = expense.Description });
            // Act
            var createdResponse = _controller.Put(expense);
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse);
        }

        [Fact]
        public void Update_ValidExpensePassed_ReturnedObjectUpdated()
        {
            // Arrange
            ExpenseDto expense = this.SeedExpense("43aaaa9c-17bd-4e17-b2ec-7603644b8f27");
            _mockRepo.Setup(repo => repo.Put(expense))
                .Returns((IActionResult)new ExpenseDto { Id = expense.Id, Category = "test", Description = expense.Description });
            // Act
            var createdResponse = _controller.Put(expense) as OkObjectResult;
            var item = createdResponse.Value as ExpenseDto;
            // Assert
            Assert.IsType<ExpenseDto>(item);
            Assert.Equal(expense.Id, item.Id);
            Assert.Equal("test", item.Category);
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
            _mockRepo.Setup(p => p.Put(It.IsAny<ExpenseDto>())).Throws(new KeyNotFoundException());
            var notFoundResult = _controller.Put(new ExpenseDto());
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }
    }
}