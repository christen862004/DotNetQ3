using DotNetQ3.Filtters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Runtime.InteropServices;

namespace DotNetQ3.Controllers
{
    [Route("t1")]
    //[ITI] //apply all action in controller
    public class RouteController : Controller
    {
        //Action Public | not Static | cant overload
        //Route/test1
        //t1
        //t1/12/ahmed

        //[Route("t1/{age:int}/{name?}",Name ="route11")] //remove defau;t route
        [Route("tt")]//t1/tt
        [HandelError]
        public IActionResult Test1()//string name,int age)
        {
                return Content("TEst1");
            
        }
        //t1/test2
        public IActionResult Test2()
        {
            return Content("TEst2");
        }
        //t3
        public IActionResult Test3()
        {
            return Content("TEst3");
        }
        //Route/Index/1 :Get
        [HttpGet]
        public IActionResult Index(int id)
        {
            return Content("Method1");
        }
        //Route/Index/1?name=ahmed :POST
        [HttpPost]
        public IActionResult Index(int id,string name)
        {
            return Content("Method2");

        }
    }
}
