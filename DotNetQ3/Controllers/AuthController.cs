using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DotNetQ3.Controllers
{
    public class AuthController : Controller
    {
        [Authorize]//actio read info as claim from cookie
        public IActionResult Index()
        {
            //if(User.Identity.IsAuthenticated)
            string name= User.Identity.Name;
            
            Claim idClaim= User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            string id = idClaim.Value;

            Claim AddressClaim= User.Claims.FirstOrDefault(c => c.Type == "Address");
            string ad = AddressClaim.Value;
            //respositoy order 
            return Content("Ay hage");
        }
    }
}
