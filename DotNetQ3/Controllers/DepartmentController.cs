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
        [HttpGet]
        public IActionResult Add()
        {
            return View("Add");//Model Null
        }
        //Support reuest (GET|Post)
      
        [HttpPost]
        public IActionResult SaveAdd(Department newDept)
        {
            //if (Request.Method == "POST")
            
            if (newDept.Name != null && newDept.ManagerName != null)
            {
                context.Add(newDept);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Add", newDept);//View Add,Model DEpartment
            
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
