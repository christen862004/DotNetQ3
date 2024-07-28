using DotNetQ3.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DotNetQ3.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult Add()
        {
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> Add(RoleViewModel roleVM)
        {
            if (ModelState.IsValid)
            {
                IdentityRole roleModel = new IdentityRole();
                roleModel.Name = roleVM.RoleName;
                IdentityResult result=  await  roleManager.CreateAsync(roleModel);
                if(result.Succeeded)
                {
                    return View("Add");

                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View("Add",roleVM);
        }
    }
}
