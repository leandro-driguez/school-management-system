

using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.API.Mappers;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Relations;
using Microsoft.EntityFrameworkCore; 
using AutoMapper;

namespace SchoolManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkerPositionRelationController : Controller
{
    public readonly IWorkerPositionRelationService _service;
    public readonly IMapper mapper;
    
    public WorkerPositionRelationController(IWorkerPositionRelationService service, IMapper mapper)
    {
        _service = service;
        this.mapper = mapper;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        var _query = _service.Query().Include(c => c.Worker).Include(c => c.Position);
        // List<StudentCourseGroupRelationDto> output = new List<StudentCourseGroupRelationDto>();   
        // foreach (var item in _query)
        // {
        //     StudentCourseGroupRelationDto dto = new StudentCourseGroupRelationDto(){
        //        CourseGroupCourseId = item.CourseGroupCourseId,
        //        CourseGroupCourseName = item.CourseGroup.Course.Name,
        //        CourseGroupName = item.CourseGroup.CourseGroupName,
        //        StudentName = item.Student.Name,
        //        StudentId = item.StudentId,
        //        CourseGroupId = item.CourseGroupId,
        //        EndDate = item.EndDate,
        //        StartDate = item.StartDate               
        //     };
        //     output.Add(dto);
        // }
        return Ok(_query.Select(mapper.Map<WorkerPositionRelation,WorkerPositionRelationDto>));
    }

    [HttpPost]
    public IActionResult Post([FromForm]WorkerPositionRelationDto dto)
    {
        if(!_service.ValidateIds(dto.WorkerId, dto.PositionId))
            return NotFound();
        _service.Add(mapper.Map<WorkerPositionRelation>(dto));
        // _service.Add(new StudentCourseGroupRelation
        // {
        //     CourseGroupId = dto.CourseGroupId,
        //     StudentId = dto.StudentId,
        //     CourseGroupCourseId = dto.CourseGroupCourseId,
        //     StartDate = dto.StartDate,
        //     EndDate = dto.EndDate
        // });
        _service.CommitAsync();
        return Ok();
    }

    [HttpPut]
    public IActionResult Put([FromForm]WorkerPositionRelationDto dto)
    {
        if(!_service.ValidateIds(dto.WorkerId, dto.PositionId))
            return NotFound();
        var relation = mapper.Map<WorkerPositionRelation>(dto);
        // var relation = new StudentCourseGroupRelation
        // {
        //     CourseGroupId = dto.CourseGroupId,
        //     StudentId = dto.StudentId,
        //     CourseGroupCourseId = dto.CourseGroupCourseId,
        //     StartDate = dto.StartDate,
        //     EndDate = dto.EndDate
        // };
        _service.Update(relation);
        _service.CommitAsync();
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete([FromForm]WorkerPositionRelationDto dto)
    {
        if(!_service.ValidateIds(dto.WorkerId, dto.PositionId))
            return NotFound();
        var item = _service.Query().Where(
                    c => c.WorkerId == dto.WorkerId
                    && c.PositionId == dto.PositionId
                ).FirstOrDefault();
        if (item != null)
            _service.Remove(item);
        _service.CommitAsync();
        return Ok();
    }

}
