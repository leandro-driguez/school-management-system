
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

public class DoStudentPaymentService : BaseService<Student>, IDoStudentPaymentService
{
    IStudentRepository _studentRepo;
    ICourseGroupRepository _courseGroupRepo;
    IStudentCourseGroupRelationRepository _studentCourseRelation;
    IStudentPayCourseRecordRepository _studentCourseRecord;    

    public DoStudentPaymentService(IStudentRepository studentRepo,
                                    ICourseGroupRepository courseGroupRepo,
                                    IStudentCourseGroupRelationRepository studentCourseRelation,
                                    IStudentPayCourseRecordRepository studentCourseRepository)
        : base(studentRepo)
    {
        _studentRepo = studentRepo;
        _courseGroupRepo = courseGroupRepo;
        _studentCourseRelation = studentCourseRelation;
        _studentCourseRecord = studentCourseRepository;
    }

    public void DoCoursePayment(string studentId, string groupCourseId)
    {
        //if (_studentRepo.GetById(studentId) == null)
        //    return "No existe el estudiante";
        //if (_courseGroupRepo.GetById(groupCourseId) == null)
        //    return "No existe el grupo del curso";
        //// de los registros de pago del estudiante determinado y su grupo de clase
        //// agrupar los registros por el grupo de clase
        //// tomando la última fecha de pago
        //var q1 = from record in _studentCourseRecord.Query()
        //         where record.StudentId == studentId &&
        //                record.CourseGroupId == groupCourseId
        //         group record by record.CourseGroupId into g
        //         select new
        //         {
        //             StudentId = g.Select(r => r.StudentId).FirstOrDefault(),
        //             CourseGroupId = g.Select(r => r.CourseGroupId).FirstOrDefault(),
        //             CourseGroupCourseId = g.Select(r => r.CourseGroupCourseId).FirstOrDefault(),
        //             Date = g.Select(r => r.Date).FirstOrDefault(),
        //             DatePaid = g.Max(r => r.DatePaid)
        //         };
        //if (q1.Count() > 1)
        //{
        //    // Este Exception jamás debe ocurrir
        //    Exception e = new Exception("En StudentCourseGroupRecord hay más de un Curso " +
        //                        "con el mismo StudentId y GroupCourseId\nQuery\n" +
        //                        q1.ToList().ToString());
        //}
        //if (q1.Any())
        //{
        //    var q2 = from relation in _studentCourseRelation.Query()
        //             where relation.StudentId == studentId &&
        //                   relation.CourseGroupId == groupCourseId
        //             select relation.EndDate;
        //    if (q2.Count() != 1)
        //    {
        //        // Este Exception jamás debe ocurrir
        //        throw new Exception("En StudentCourseGroupRelation hay más de un Curso " +
        //                            "con el mismo StudentId y GroupCourseId " +
        //                            "o no existe la relación\nQuery:\n" +
        //                            q2.ToList());                
        //    }
        //    var finalDate = q2.First().Date;
        //    if (finalDate >= q1.First().Date)
        //    {
        //        // Ya se pagó todo el curso
        //        return "Ya el curso estaba pagado";
        //    }
        //    // Se supone que ahora se procede a cobrar
        //    // O sea a guardar el curso en la base de datos
        //    return "Cobro de curso realizada";
        //}
        //throw new NotImplementedException("Falta revisar los curso que no se han pagado ni una vez");
    }

    public IRepository<CourseGroup> GetCOurseGroupRepo()
    {
        return _courseGroupRepo;
    }

    public IRepository<StudentCourseGroupRelation> GetStudentCourseGroupRelationRepo()
    {
        return _studentCourseRelation;
    }

    public IRecordRepository<StudentPaymentRecordPerCourseGroup> GetStudentPaymentRecordPerCourseGroupRepo()
    {
        return _studentCourseRecord;
    }

    public IRepository<Student> GetStudentRepo()
    {
        return _studentRepo;
    }
}