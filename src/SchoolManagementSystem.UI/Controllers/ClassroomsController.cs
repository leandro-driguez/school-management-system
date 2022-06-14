using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.UI.Models;

namespace SchoolManagementSystem.UI.Controllers;

public class ClassroomsController : Controller
{
    private readonly SchoolContext _context;

    public ClassroomsController(SchoolContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Classrooms.ToList());
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
