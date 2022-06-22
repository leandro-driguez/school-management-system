

using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.API.Dtos;
public class ConsultWorkerSalaryGetSingleDto : IDto
{
    public string Id { get; set; }

    public string WorkerName { get; set; }
    
    [DataType(DataType.Currency)]
    public int TotalFixSalary { get; set; }

    public double TotalCoursesPorcentualPayment { get; set; }
    public double Total { get
        {
            return TotalFixSalary + TotalCoursesPorcentualPayment;
        } 
        set{}
    }


    // public int TotalAdditionalServicesPorcentualPayment { get; set; }
    // public int Bonification {get; set;}
    // public int Penalization {get; set;}


}