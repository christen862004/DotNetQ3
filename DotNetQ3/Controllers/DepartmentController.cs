using DotNetQ3.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetQ3.Controllers
{
    public class DepartmentController : Controller
    {
        ITIContext context = new ITIContext();
        public DepartmentController()
        {
            
        }

        public IActionResult Index()
        {
            List<Department> DEptListModel= context.Department.ToList();
            return View("Index", DEptListModel);//view name="Index" ,Model Type List<department>
        }

        public IActionResult DEtails(int id)
        {
            Department departmentModel = context.Department.FirstOrDefault(x => x.Id == id);
            return View("Details", departmentModel);//View DEatils ,Model Department
        }
    }
}
