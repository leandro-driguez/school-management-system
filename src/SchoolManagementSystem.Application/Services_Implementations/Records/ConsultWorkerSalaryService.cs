
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Application.Repositories_Interfaces.Records;
// using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagementSystem.Application.Services_Implementations;

public class ConsultWorkerSalaryService : IConsultWorkerSalaryService
{
    IWorkerPayRecordByPositionRepository _repo;
    public ConsultWorkerSalaryService(IWorkerPayRecordByPositionRepository repo)
    {
        _repo = repo;
    }
    public List<int> Proof()
    {
        return new List<int> { 1, 2, 3, 4 };
    }
    
    public List<Tuple<string, int>> GetWorkerFixSalaries(string id)
    {      
        // throw new NotImplementedException();
        var ans =  new List<Tuple<string, int>>();
        var _query = _repo.Query()
                        .Where(c => id == c.WorkerId)
                        .Include(c => c.Position);

        System.Console.WriteLine(_query);

        foreach( var item in _query)
            {
                ans.Add(new Tuple<string, int>(item.Position.Name,item.Payment));
            }
        return ans;
    }
}