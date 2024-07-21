using DotNetQ3.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetQ3.Controllers
{
    public class StudentController : Controller
    {
        //Student/All
        public IActionResult All()
        {
            StudentBL studentBL = new StudentBL();
            List<Student> StdListModel= studentBL.getAll();//get data from model
            return View("AllStd", StdListModel);//view Name="AllStd",Model type List<student>
        }

        //Student/DEtails?id=2 [Qs]
        //Student/DEtails/2    [route values]
        public IActionResult Details(int id)
        {

            //Get Model
            StudentBL studentBL = new StudentBL();
            Student stdMoedl= studentBL.GetByID(id);
            //Send View
            return View("StdDEtails",stdMoedl);//view StdDEtails,Model Type Student

        }
        












        //Action Must Be Public 
        //Action Cant be static 
        //Action cant be overload " case 1"

        //Action "Endpoint"
        //Controller/Action
        public ContentResult Test()
        {
            //1)decalre
            ContentResult result = new ContentResult();
            //logic...........
            //2)set value
            result.Content = "Test";
            //3)return
            return result;
        }
        //Student/ShowView "Endpoint
        public ViewResult ShowView()//action
        {
            ViewResult result = new ViewResult();
            result.ViewName = "View1";//search
            //Views/Student/View1.cshtml
            //Views/Shared/View1.cshtml
            //Throw Exception
            return result;
        }

        //endion inut (contentREsult | Viwe
        //Student/showmix?NO=1&name=ahmed
        public IActionResult ShowMix(int no)//,string name)
        {
            if(no%2==0) {
                return View("View1");
            }
            else
            {
                //logic
                 return Content("Odd Not Allow");
            }
        }
    


        //Action can return 
        //Content==> ContentResult
        //View   ==> ViewResult
        //JS     ==> JavascriptResult
        //json   ==> JsonResult
        //File
        //NotFound
        //....
    }
}
