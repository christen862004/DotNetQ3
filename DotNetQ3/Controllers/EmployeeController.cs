using DotNetQ3.Models;
using DotNetQ3.Repository;
using DotNetQ3.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DotNetQ3.Controllers
{
    public class EmployeeController : Controller//High Level
    {
        //DIP (lossly couple )[IOC]
       
        IEmployeeRepository EmployeeRepository;//abstarction |Interface
        IDepartmentRepository DepartmentRepository;
     
        //Controller one Contrusture(inject |ask)
        public EmployeeController
            (IEmployeeRepository empREpo,IDepartmentRepository DeptREpo)
            //[DI] ask IOC Container
        {
            //Dont Create ==>ask (DI)
            EmployeeRepository = empREpo;// new EmployeeRepository();   //DIP             
            DepartmentRepository = DeptREpo;// new DepartmentRepository();
        }
        public IActionResult Index()
        
        {
            return View("Index", EmployeeRepository.GetAll());
        }

        //Employee/GetEmpCardPartial/1 (Part of Page) partial request using Ajax
        public IActionResult GetEmpCardPartial(int id)
        {
            Employee empModel =EmployeeRepository.GetById(id);
            return PartialView("_EmpCardPartial",empModel);
        }


        //Employeee/CheckSalary?Salary=10000&jobTitle=web
        public IActionResult CheckSalary(int Salary,string JobTitle)
        {
            int baseSaalary = 6000;
            if(Salary>baseSaalary)
            {
                return Json(true);
            }
            return Json(false);
        }


        [HttpGet]//Anchor create reqquest type Get
        public IActionResult New()
        {
            ViewBag.DeptList = DepartmentRepository.GetAll();

            return View("New");
        }

        [HttpPost]
        public IActionResult SaveNew(Employee newEmpFromRequest)
        {
            if (ModelState.IsValid==true)
            {
                try
                {
                    EmployeeRepository.Insert(newEmpFromRequest);
                    EmployeeRepository.Save();
                    return RedirectToAction("Index");
                }catch (Exception ex) /* Constrain Exption */
                {
                    /*Custom Valiadtion [action]*/
                    // ModelState.AddModelError("DeptartmentId","Please Select DEpartment");
                    ModelState.AddModelError("ayhaga", ex.Message + " " + ex.InnerException?.Message);
                }
            }

            ViewBag.DeptList = DepartmentRepository.GetAll();
            return View("New", newEmpFromRequest);
        }
       
        //Employee/Edit/1 Get
        public IActionResult Edit(int id)
        {
            Employee empModel = EmployeeRepository.GetById(id);
            //Mapping
            EmpWithDeptListViewModel empVM=new EmpWithDeptListViewModel();
            empVM.Id = empModel.Id;
            empVM.Name = empModel.Name;
            empVM.Address = empModel.Address;
            empVM.DeptartmentId = empModel.DeptartmentId;
            empVM.Salary = empModel.Salary;
            empVM.ImageUrl = empModel.ImageUrl;
            empVM.JobTitle = empModel.JobTitle;

            empVM.DeptList = DepartmentRepository.GetAll();


            return View("Edit",empVM);
        }

        [HttpPost]
        public IActionResult SaveEdit(EmpWithDeptListViewModel empFromReq)
        {
            if (empFromReq.Name != null && empFromReq.Salary > 6000)
            {
                Employee empModel= EmployeeRepository.GetById(empFromReq.Id);
                empModel.Name = empFromReq.Name;
                empModel.Address = empFromReq.Address;
                empModel.Salary = empFromReq.Salary;
                empModel.JobTitle = empFromReq.JobTitle;
                empModel.DeptartmentId= empFromReq.DeptartmentId;
                empModel.ImageUrl = empFromReq.ImageUrl;

                //context.Update(empFromReq);//Must ID with value
                EmployeeRepository.Save();

                return RedirectToAction("Index");
            }
           
            empFromReq.DeptList =DepartmentRepository.GetAll();
            return View("Edit", empFromReq);
        }

        public IActionResult Delete (int id)
        {
            Employee empModel = 
                EmployeeRepository.GetById(id);
            return View("Delete", empModel);
        }


        public IActionResult test()
        {
            return NoContent();
        }
        public IActionResult DEtails(int id,string Msg)
        {
            //object obj = new Employee();
            //((Employee)obj).
            string msg = "Hello";
            int no = 30;
            string localDate = DateTime.Now.ToShortDateString();
            string color = "red";
            List<string> branchList=new List<string>();
            branchList.Add("Smart");
            branchList.Add("Manofia");
            branchList.Add("Alex");
            
            ViewData["Message"] = msg;
            ViewData["Brch"] = branchList;
            
            ViewData["no"] = no;
            ViewData["date"] = localDate;


            ViewData["clr"] = "red";
            ViewBag.Chris = "33";//ViewData["Chris"]="33"
            ViewBag.clr = "blue";
            Employee empModel=EmployeeRepository.GetById(id);
            return View("DEtails",empModel);
        }


        public IActionResult DEtailsWithVM(int id)
        {
            string msg = "Hello";
            string color = "red";
            List<string> branchList = new List<string>();
            branchList.Add("Smart");
            branchList.Add("Manofia");
            branchList.Add("Alex");

            Employee empModel = EmployeeRepository.GetById(id);
            //Map frpm souce ==>ViewMdoel
            var EmpVM = new EmpNameWithBrchListColorDateMesViewModel();
            EmpVM.EmpName = empModel.Name;
            EmpVM.Message= msg;
            EmpVM.Color = color;
            EmpVM.No = 10;
            EmpVM.BranchList= branchList;


            return View("DEtailsVM", EmpVM);
        }
    }
}
