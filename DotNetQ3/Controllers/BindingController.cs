using DotNetQ3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace DotNetQ3.Controllers
{
    public class BindingController : Controller
    {
        



        //Test Biding Premitive
        //Binding/testPrimitive/12?age=10&name=Ahemd&color[1]=red&color[0]=blue
        //Binding/testPrimitive?id=12&age=10&name=Ahemd&color[1]=red&color[0]=blue

        public IActionResult testPrimitive(int id,int age ,string name, string[] color)
        {
            return NoContent();
        }

        //Collection (List,Dict)
        //Binding/TestDic?OwnerName=Yossef&Phones[Ahmed]=123&Phones[Chris]=456
        public IActionResult TestDic(Dictionary<string,string> Phones,string OwnerName)
        {
            return NoContent();
        }

        //binding Complex Object
        //Binding/TestObj/1?Name=SD&ManagerName=Ahmed&Emps[0].Name=Yossef
        public IActionResult TestObj(Department dept)
        {
            return NoContent();
        }

    }
}
