using DotNetQ3.Models;
using DotNetQ3.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetQ3.Controllers
{
    public class DepartmentController : Controller
    {
       // ITIContext context = new ITIContext();
       IDepartmentRepository DeptRepository;
        IEmployeeRepository EmployeeRepository;
        public DepartmentController(IDepartmentRepository deptREpo,IEmployeeRepository EmpREpo)
        {
            DeptRepository=deptREpo;//= new DepartmentRepository();
            EmployeeRepository=EmpREpo;//= new EmployeeRepository();
        }

        public IActionResult ShowDEptEmp()
        {
            List<Department> DeptListModel= 
                DeptRepository.GetAll();
            return View("ShowDEptEmp", DeptListModel);
        }
        
        //Department/GetEmpsByDEpt?deptId=1
        public IActionResult GetEmpsByDEpt(int deptId)
        {
            List<Employee> EmpList=
               EmployeeRepository.GetByDeptID(deptId);
            return Json(EmpList);
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
                DeptRepository.Insert(newDept);

                DeptRepository.Save();
                return RedirectToAction("Index");
            }
            return View("Add", newDept);//View Add,Model DEpartment
            
        }
        
        [Authorize]//check cookie | login
        public IActionResult Index()
        {

            List<Department> DEptListModel = DeptRepository.GetAll();
            return View("Index", DEptListModel);//view name="Index" ,Model Type List<department>
        }

        [Authorize(Roles="Admin")]
        public IActionResult DEtails(int id)
        {
            Department departmentModel = DeptRepository.GetById(id);
            return View("Details", departmentModel);//View DEatils ,Model Department
        }
    }
}
