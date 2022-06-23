
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Application.Repositories_Interfaces.Records;
using SchoolManagementSystem.Application.Repositories_Interfaces;
// using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagementSystem.Application.Services_Implementations;

public class DoWorkersPaymentService : BaseRecordService<Worker>, IDoWorkersPaymentService
{
    IWorkerPayRecordByPositionRepository repoPositionPayments;
    ITeacherPayRecordPerCourseRepository repoTeacherPayments;
    public DoWorkersPaymentService(IWorkerPayRecordByPositionRepository repo_1, ITeacherPayRecordPerCourseRepository repo_2, IWorkerRepository base_repo) : base(base_repo)
    {
        repoPositionPayments = repo_1;
        repoTeacherPayments = repo_2;
    }

    public IQueryable<TeacherPayRecordPerCourse> GetWorkerCoursePorcentualSalaries(string id)
    {
        var _query = repoTeacherPayments.Query()
                       .Where(c => id == c.TeacherId)
                       .Include(c => c.Course);

        return _query;
    }

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