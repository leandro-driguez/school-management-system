
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
    
    
    public Dictionary<Position, int> GetWorkerFixSalaries(string id)
    {      
        var dict =  new Dictionary<Position,int>();

        foreach( var position in _repo.Query()
                                    .Where(c => id == c.Id)
                                    .Include(c => c.Positions)
                                    .FirstOrDefault()
                                    .Positions)
            {
                dict[position] 
            }

    }
}