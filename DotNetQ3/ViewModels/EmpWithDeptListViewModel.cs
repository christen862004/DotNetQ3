using DotNetQ3.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetQ3.ViewModels
{
    public class EmpWithDeptListViewModel
    {
        public int Id { get; set; }

        [Display(Name="Full Name")]
        //[DataType(DataType.Password)]
        public string Name { get; set; }

        public int Salary { get; set; }

        public string ImageUrl { get; set; }
        public string? Address { get; set; }
        public string? JobTitle { get; set; }

        [Display(Name= "- Deptartment -")]
        public int DeptartmentId { get; set; }


        public List<Department> DeptList { get; set; }
    }
}
