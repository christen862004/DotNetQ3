using DotNetQ3.Models;
using DotNetQ3.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DotNetQ3.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context = new ITIContext();

        public EmployeeController()
        {
                
        }
        public IActionResult test()
        {
            return NoContent();
        }
        public IActionResult DEtails(int id)
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
            Employee empModel=context.Employee.FirstOrDefault(x => x.Id == id);
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

            Employee empModel = context.Employee.FirstOrDefault(x => x.Id == id);
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
