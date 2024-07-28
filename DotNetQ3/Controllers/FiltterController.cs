using DotNetQ3.Filtters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetQ3.Controllers
{
    // [HandelError]
    [Authorize(Roles ="Admin")]
    public class FiltterController : Controller
    {
       // [Authorize]//Befor - after execute
        public IActionResult Index()
        {
            throw new Exception("Exception Index Action");
            return View();
            
        }

        [AllowAnonymous]
        public IActionResult Index2()
        {
            throw new Exception("Exception Index Action");
            return View();
        }
    }
}
