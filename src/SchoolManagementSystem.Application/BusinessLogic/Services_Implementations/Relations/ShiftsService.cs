
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Repositories_Interfaces;
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Relations;

namespace SchoolManagementSystem.Application.Services_Implementations;

public class ShiftsService : BaseService<Shift>, IShiftsService
{
    IClassroomRepository classroom_repo;
    public ShiftsService(IShiftRepository repo
                        ,IClassroomRepository classroom_repo) : base(repo)
    {
        this.classroom_repo = classroom_repo;
    } 

    

    public bool ValidateClassroomIds(string classroomId)
    {
        var row = classroom_repo.Query().Where(c => c.Id == classroomId)
                            .FirstOrDefault();

        if (row == null)
            return false;

        return true;
    }
}