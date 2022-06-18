
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.UI.Models;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Interfaces;

namespace SchoolManagementSystem.UI.Controllers;

public class ClassroomsController : Controller
{
    private readonly IService<Classroom> _service;

    public ClassroomsController(IService<Classroom> service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        return View(_service.Query());
        // throw new NotImplementedException();
    }

    public IActionResult Create()
    {
        return View();
    } 
    
    public IActionResult Edit()
    {
        return View();
    } 
    
    public IActionResult Details()
    {
        return View();
    } 
    
    public IActionResult Delete()
    {
        return View();
    } 

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
