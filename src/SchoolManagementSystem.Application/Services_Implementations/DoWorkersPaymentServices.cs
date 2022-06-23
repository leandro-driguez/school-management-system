
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Relations;
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Application.Repositories_Interfaces.Records;
using SchoolManagementSystem.Application.Repositories_Interfaces;
// using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagementSystem.Application.Services_Implementations;

public class DoWorkersPaymentService : BaseRecordService<Worker>, IDoWorkersPaymentService
{
    IWorkerPayRecordByPositionRepository repoPositionPayments;
    ITeacherPayRecordPerCourseRepository repoTeacherPayments;
    ITeacherCourseGroupRelationRepository repoTeacherCGREl;
    ITeacherCourseRelationRepository repoTeacherCourseRel;
    // ICourseGroupRepository repoCG;
    public DoWorkersPaymentService(ITeacherCourseRelationRepository repoTeacherCourseRel,ITeacherCourseGroupRelationRepository repoTeacherCGREl, IWorkerPayRecordByPositionRepository repo_1, ITeacherPayRecordPerCourseRepository repo_2, IWorkerRepository base_repo) : base(base_repo)
    {
        repoPositionPayments = repo_1;
        repoTeacherPayments = repo_2;
        this.repoTeacherCGREl = repoTeacherCGREl;
        this.repoTeacherCourseRel = repoTeacherCourseRel;
    }
    public IRepository<TeacherCourseGroupRelation>  GetTeacherCourseGroupRelationRepo(string id)
    {
        return repoTeacherCGREl;
    }
    public  IRepository<TeacherCourseRelation>  GetTeacherCourseRelationRepo(string id)
    {
        return repoTeacherCourseRel;
    }
    // public IQueryable<TeacherCourseGroupRelation> GetWorkerCoursePorcentualSalaries(string id)
    // {
    //     // var _query = from teacherCGREl in repoTeacherCGREl.Query()
    //                     join teacherCourseRel in repoTeacherCourseRel.Query()
    //                     on new {teacherCGREl.TeacherId, CourseId = teacherCGREl.CourseGroupCourseId}
    //                         equals new {teacherCourseRel.TeacherId, CourseId = teacherCourseRel.CourseId}
    //                     select new {
    //                         TeacherId = teacherCGREl.TeacherId,
    //                         Procentage = teacherCourseRel.CorrespondingPorcentage,
    //                         CourseGroup = teacherCGREl.CourseGroup
    //                     };

    //     return _query;
    // }

    public IQueryable<WorkerPayRecordByPosition> GetWorkerFixSalaries(string id)
    {
        var ans = new List<Tuple<string, int>>();
        var _query = repoPositionPayments.Query()
                        .Where(c => id == c.WorkerId)
                        .Include(c => c.Position);

        return _query;
    }

    // public List<DateTime> GetAllPaymentDates(string id)
    // {
    //     List<DateTime> dates = new List<DateTime>();
    //     var _query = repoPositionPayments.Query()
    //                     .Where(c => id == c.WorkerId);
    //     foreach (var item in _query)
    //         dates.Add(item.Date);
    //     var _query2 = repoTeacherPayments.Query()
    //                     .Where(c => id == c.TeacherId);

    //     foreach (var item in _query2)
    //         dates.Add(item.Date);

    //     dates = dates.Distinct().ToList();

    //     return dates;
    // }
}