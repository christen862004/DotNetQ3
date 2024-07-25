using DotNetQ3.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetQ3.ViewModels
{
    public class EmpWithDeptListViewModel
    {
        public int Id { get; set; }

        [MaxLength(length: 25)]
        [MinLength(3, ErrorMessage = "Name Must Be More Than 3 Char")]
        ////[Required]
        [Unique(xyz = 111)]
        public string Name { get; set; }

        // [Range(6000,25000)]
        [Remote("CheckSalary", "Employee", AdditionalFields = "JobTitle", ErrorMessage = " Salary Must Be More Than 6000")]
        public int Salary { get; set; }
        //Employeee/CheckSalary?Salary=10000&JobTitle=BackEnd

        [RegularExpression(@"\w{2,}\.(png|jpg)", ErrorMessage = "Image Must be .png or .jpg files")]
        public string ImageUrl { get; set; }

        public string? Address { get; set; }

        [Display(Name = "Current Job Title")]
        public string? JobTitle { get; set; }

        [ForeignKey("Department")]
        [Display(Name = "Department")]
        [NotAllowZero(ErrorMessage = "Please Select Department")]
        public int DeptartmentId { get; set; }


        public List<Department> DeptList { get; set; }
    }
}
