using DotNetQ3.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DotNetQ3.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IDepartmentRepository deptREpo;

        public ServiceController(IDepartmentRepository DeptREpo)//, IDepartmentRepository DeptREpo2)
        {
            deptREpo = DeptREpo;
        }
        public IActionResult Index()//[FromServices]IDepartmentRepository deptre)
        {
            ViewData["Id"] = deptREpo.Id;
            return View();
        }
    }
}
