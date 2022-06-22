

using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.API.Dtos;
public class ConsultWorkerSalaryGetSingleDto : IDto
{
    public string Id { get; set; }

    public string WorkerName { get; set; }
    
    [DataType(DataType.Currency)]
    public int TotalFixSalary { get; set; }

    public int TotalCoursesPorcentualPayment { get; set; }
    public int Total { get
        {
            return TotalFixSalary + TotalCoursesPorcentualPayment;
        } 
        set{}
    }


    // public int TotalAdditionalServicesPorcentualPayment { get; set; }
    // public int Bonification {get; set;}
    // public int Penalization {get; set;}


}