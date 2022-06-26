

using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Domain.Relations;
using SchoolManagementSystem.Domain.Interfaces;
// using SchoolManagementSystem.Domain.Services;
// using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Services;
public interface IDoStudentPaymentService : IRecordService<Student>
{
    public void GroupCurseNoPaid(string studentId, string groupCourseId);    
    //public IRepository<TeacherCourseGroupRelation> GetTeacherCourseGroupRelationRepo();
    //public IRepository<TeacherCourseRelation> GetTeacherCourseRelationRepo();
    //public IRepository<WorkerPositionRelation> GetWorkerPositionRelationRepo();
    public string DoCoursePayment(string studentId, string groupCourseId);

}