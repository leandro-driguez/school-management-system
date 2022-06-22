
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Application.Repositories_Interfaces.Records;
using SchoolManagementSystem.Application.Repositories_Interfaces;
// using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagementSystem.Application.Services_Implementations;

public class ConsultWorkerSalaryService : BaseRecordService<Worker>, IConsultWorkerSalaryService
{
    IWorkerPayRecordByPositionRepository repoPositionPayments;
    ITeacherPayRecordPerCourseRepository repoTeacherPayments;
    public ConsultWorkerSalaryService(IWorkerPayRecordByPositionRepository repo_1, ITeacherPayRecordPerCourseRepository repo_2, IWorkerRepository base_repo) : base(base_repo)
    {
        repoPositionPayments = repo_1;
        repoTeacherPayments = repo_2;
    }
    public List<int> Proof()
    {
        return new List<int> { 1, 2, 3, 4 };
    }




    public IQueryable<TeacherPayRecordPerCourse> GetWorkerCoursePorcentualSalaries(string id, DateTime date)
    {
        // var ans = new List<Tuple<string, double>>();
        // System.Console.WriteLine("here");
        var _query = repoTeacherPayments.Query()
                       .Where(c => id == c.TeacherId)
                       .Include(c => c.Course)
                       .Where(c => date == c.Date);

        // var query2 =  repoTeacherPayments.Query()
        //                .Where(c => id == c.TeacherId)
        //                .Include(c => c.Course)
        //                .Where(c => date == c.Date).Join();
            
        // System.Console.WriteLine("here2");

        // foreach (var item in _query)
        // {
        //     ans.Add(new Tuple<string, double>(item.Course.Name, item.PaidPorcentage * (1.0 / 100) * item.Course.Price));
        // }
        return _query;
    }
    // public double GetTotalWorkerCoursePorcentualSalaries(string id)
    // {
    //     double sum = 0;
    //     foreach (var pair in GetWorkerCoursePorcentualSalaries(id))
    //         sum += pair.Item2;

    //     return sum;
    // }

    public IQueryable<WorkerPayRecordByPosition> GetWorkerFixSalariesByDate(string id, DateTime date)
    {
        // throw new NotImplementedException();
        var ans = new List<Tuple<string, int>>();
        var _query = repoPositionPayments.Query()
                        .Where(c => id == c.WorkerId)
                        .Include(c => c.Position)
                        .Where(c => c.Date == date);

        // System.Console.WriteLine(_query);

        // foreach (var item in _query)
        // {
        //     ans.Add(new Tuple<string, int>(item.Position.Name, item.Payment));
        // }
        return _query;
    }

    // public int GetTotalWorkerFixSalaries(string id)
    // {
    //     int sum = 0;
    //     foreach (var pair in GetWorkerFixSalaries(id))
    //         sum += pair.Item2;

    //     return sum;
    // }

    public List<DateTime> GetAllPaymentDates(string id)
    {
        List<DateTime> dates = new List<DateTime>();
        var _query = repoPositionPayments.Query()
                        .Where(c => id == c.WorkerId);
        foreach (var item in _query)
            dates.Add(item.Date);
        var _query2 = repoTeacherPayments.Query()
                        .Where(c => id == c.TeacherId);

        foreach (var item in _query2)
            dates.Add(item.Date);

        dates = dates.Distinct().ToList();

        return dates;
    }
}