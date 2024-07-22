using Microsoft.AspNetCore.Mvc;

namespace DotNetQ3.Controllers
{
    public class StateController : Controller
    {
        public IActionResult SetSession(string name)
        {
            //logic
            //Convert object to json 
            HttpContext.Session.SetString("Name",name);
            HttpContext.Session.SetInt32("Age", 12);
            //logic
            return Content("Session Data Saved");
        }

        public IActionResult GetSession()
        {
            //logic
            string n=HttpContext.Session.GetString("Name");
            int a = HttpContext.Session.GetInt32("Age").Value;
            //loic
            return Content($"name={n}\t age={a}");

        }


        public IActionResult setCookie()
        {
            //logic
            //state Resourec
            //Type Of Cookie 
            //Session Cookie 
            HttpContext.Response.Cookies.Append("Name", "Ahmed");
            //Presisitent cookie
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(1); ;
            HttpContext.Response.Cookies.Append("Age", "12", options);
            return Content("Cookie SAve");

        }
        public IActionResult GetCookie()
        {
            //server need from client
            string n=HttpContext.Request.Cookies["Name"];
            string a = HttpContext.Request.Cookies["Age"];
            //logic
            return Content($"name={n} \t age={a}");

        }
    }
}
