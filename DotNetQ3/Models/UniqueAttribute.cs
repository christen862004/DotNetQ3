using System.ComponentModel.DataAnnotations;

namespace DotNetQ3.Models
{
    /*Server side API*/
    public class UniqueAttribute:ValidationAttribute
    {
        public int xyz { get; set; }

        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            string? name = value.ToString();

            Employee EmpFromREq = (Employee)validationContext.ObjectInstance;

            /*uniqur per department*/
            ITIContext context = new ITIContext();
            Employee? EmpFromDB= context.Employee
                .FirstOrDefault(e=>e.Name== name && e.DeptartmentId==EmpFromREq.DeptartmentId);
            
            if(EmpFromDB == null) {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult($"This Name {name} Already Exist");
            }
        }
    }
}
