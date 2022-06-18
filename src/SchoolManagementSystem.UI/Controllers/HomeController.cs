
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.UI.Models;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Application.Services_Implementations;

namespace SchoolManagementSystem.UI.Controllers;

public class HomeController : Controller
{
    // private readonly IService<> _service;
    
    public HomeController()
    {
        // _service = service;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
