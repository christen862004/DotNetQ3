using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetQ3.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        
        public string ImageUrl { get; set; }
        public string? Address { get; set; }
        [Display(Name="Current Job Title")]
        public string? JobTitle { get; set; }

        [ForeignKey("Department")]
        [Display(Name="Department")]
        public int DeptartmentId { get; set; }
        //[ForeignKey("DeptartmentId")]
        public Department? Department { get; set; }
    }
}
