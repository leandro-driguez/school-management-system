
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Repositories_Interfaces;
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Relations;

namespace SchoolManagementSystem.Application.Services_Implementations;

public class StudentCourseGroupRelationService : BaseService<StudentCourseGroupRelation>, IStudentCourseGroupRelationService
{
    IStudentCourseGroupRelationRepository repo;
    ICourseGroupRepository cg_repo;
    IStudentRepository st_repo;
    public StudentCourseGroupRelationService(ICourseGroupRepository cg_repo,
            IStudentRepository st_repo,
             IStudentCourseGroupRelationRepository repository) : base(repository)
    {
        this.repo = repository;
        this.cg_repo = cg_repo;
        this.st_repo = st_repo;
    }
    public bool ValidateIds(string StudentId, string courseGroupId, string courseId)
    {
        var row = cg_repo.Query().Where(c => c.Id == courseGroupId && c.CourseId == courseId)
                            .FirstOrDefault();

        if (row == null)
            return false;

        var std = st_repo.Query().Where(c => c.Id == StudentId)
                            .FirstOrDefault();
        if (std == null)
            return false;

        return true;
    }

    public void AddStudentsToCourseGroup(string StudentId, string courseGroupId, string courseId)
    {
        repo.Add(new StudentCourseGroupRelation
        {
            CourseGroupId = courseGroupId,
            StudentId = StudentId,
            CourseGroupCourseId = courseId
        });
        repo.CommitAsync();
    }

    public void DeleteStudentsFromCourseGroup(string StudentId, string courseGroupId, string courseId)
    {
        var item = repo.Query().Where(
                    c => c.CourseGroupId == courseGroupId
                    && c.StudentId == StudentId
                    && c.CourseGroupCourseId == courseId
                ).FirstOrDefault();
        if (item != null)
            repo.Remove(item);
        repo.CommitAsync();
    }
}