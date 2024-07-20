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
        public string? JobTitle { get; set; }

        [ForeignKey("Department")]
        public int DeptartmentId { get; set; }
        //[ForeignKey("DeptartmentId")]
        public Department? Department { get; set; }
    }
}
