
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
    IWorkerPositionRelationRepository repoWorkerPositionR;
    IWorkerPayRecordByPositionRepository repoPositionPayments;
    ITeacherPayRecordPerCourseRepository repoTeacherPayments;
    ITeacherCourseGroupRelationRepository repoTeacherCGREl;
    ITeacherCourseRelationRepository repoTeacherCourseRel;
    // ICourseGroupRepository repoCG;
    public DoWorkersPaymentService(IWorkerPositionRelationRepository repoWorkerPositionR,ITeacherCourseRelationRepository repoTeacherCourseRel,ITeacherCourseGroupRelationRepository repoTeacherCGREl, IWorkerPayRecordByPositionRepository repo_1, ITeacherPayRecordPerCourseRepository repo_2, IWorkerRepository base_repo) : base(base_repo)
    {
        repoPositionPayments = repo_1;
        repoTeacherPayments = repo_2;
        this.repoTeacherCGREl = repoTeacherCGREl;
        this.repoTeacherCourseRel = repoTeacherCourseRel;
        this.repoWorkerPositionR = repoWorkerPositionR;
    }
    public IRepository<TeacherCourseGroupRelation>  GetTeacherCourseGroupRelationRepo()
    {
        return repoTeacherCGREl;
    }
    public  IRepository<WorkerPositionRelation>  GetWorkerPositionRelationRepo()
    {
        return repoWorkerPositionR;
    }
    public  IRepository<TeacherCourseRelation>  GetTeacherCourseRelationRepo()
    {
        return repoTeacherCourseRel;
    }

    // public IQueryable<WorkerPayRecordByPosition> GetWorkerFixSalaries(string id)
    // {
    //     var ans = new List<Tuple<string, int>>();
    //     var _query = repoPositionPayments.Query()
    //                     .Where(c => id == c.WorkerId)
    //                     .Include(c => c.Position);

    //     return _query;
    // }
}