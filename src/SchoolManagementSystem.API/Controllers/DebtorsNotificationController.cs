
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.API.Mappers;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Relations;
using SchoolManagementSystem.Application.Repositories_Interfaces;
using Microsoft.EntityFrameworkCore; 
using AutoMapper;
using System.Collections.Generic;
using System.Collections;

namespace SchoolManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DebtorsNotificationController : Controller
{    
    public readonly IMapper mapper;

    public DebtorsNotificationController(
        IMapper mapper)
    {
        this.mapper = mapper;
    }    

    [HttpGet]
    public IActionResult GetDebtorsAmount()
    {
        if(DebtorsStaticClass.DebtorsAmount == 0)
            return NotFound();
        return Ok (new {
                Title = "There are some debtors.",
                Descrpition = $"There are {DebtorsStaticClass.DebtorsAmount} students that did not have paid some courses.",
                Type = "Warning"
            }
            
        );
    }

}
