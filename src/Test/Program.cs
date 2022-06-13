
using SchoolManagementSystem.Domain.Entities;

namespace Test;

public class Program
{
    public static void Main()
    {
        Student student = new Student("123456784012", "Pablo", "Curbelo Paez", 56784392, 
            "Pocitos No.23 e/ Czda de Vento y ALmendares",new DateTime(2020,2,1),
            new Tuitor{Name="Elena", PhoneNumber=54637721},3, SchoolManagementSystem.Domain.Enums.Education.Posgrado);
    }
}
