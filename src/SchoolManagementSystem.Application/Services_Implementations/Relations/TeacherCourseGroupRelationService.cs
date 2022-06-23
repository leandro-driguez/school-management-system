
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Repositories_Interfaces;
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Relations;

namespace SchoolManagementSystem.Application.Services_Implementations;

public class TeacherCourseGroupRelationService : BaseService<TeacherCourseGroupRelation>, ITeacherCourseGroupRelationService
{
    ITeacherCourseGroupRelationRepository repo;
    ITeacherRepository tch_repo;
    ICourseGroupRepository cgrs_repo;
    public TeacherCourseGroupRelationService(ICourseGroupRepository cgrs_repo,
            ITeacherRepository tch_repo,
             ITeacherCourseGroupRelationRepository repository) : base(repository)
    {
        this.repo = repository;
        this.tch_repo = tch_repo;
        this.cgrs_repo = cgrs_repo;
    }
    public bool ValidateIds(string TeacherId, string CourseGroupId, string CourseId)
    {
        var row = cgrs_repo.Query().Where(c => c.Id == CourseGroupId && c.CourseId == CourseId) 
                            .FirstOrDefault();

        if (row == null)
            return false;

        var std = tch_repo.Query().Where(c => c.Id == TeacherId)
                            .FirstOrDefault();
        if (std == null)
            return false;

        return true;
    }
}