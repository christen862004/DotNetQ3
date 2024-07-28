using DotNetQ3.Models;
using DotNetQ3.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DotNetQ3.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController
            (UserManager<ApplicationUser> UserManager
            ,SignInManager<ApplicationUser> SignInManager)
        {
            userManager = UserManager;
            signInManager = SignInManager;
        }

        [HttpGet]//a
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]//submit button
        public async Task<IActionResult> Register(RegisterViewModel newUserVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser newUser=new ApplicationUser();
                newUser.UserName = newUserVM.UserName;
                newUser.PasswordHash = newUserVM.Password;
                newUser.Address = newUserVM.Address;
                //db
                
                IdentityResult result=await  userManager.CreateAsync(newUser,newUserVM.Password);

                if (result.Succeeded)
                {
                    //Admin
                    await userManager.AddToRoleAsync(newUser, "Admin");
                    //create session cookie
                    await signInManager.SignInAsync(newUser, false);

                    return RedirectToAction("Index", "Department");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);//Div
                    }
                }

            }
            return View("Register",newUserVM);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]//login from outside web site
        public async Task<IActionResult> Login(LoginViewModel userVM)
        {
            if(ModelState.IsValid)
            {
                //check db
                ApplicationUser userModel=
                    await userManager.FindByNameAsync(userVM.UserName);
                if (userModel != null)
                {
                    //check password
                    bool found=await userManager.CheckPasswordAsync(userModel, userVM.Password);
                    if (found)
                    {
                        //Address
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim("Address", userModel.Address));

                        await signInManager.SignInWithClaimsAsync(userModel, userVM.IsRemember, claims);
                        //await signInManager.SignInAsync(userModel, userVM.IsRemember);
                        return RedirectToAction("Index", "Department");
                    }
                }
                ModelState.AddModelError("", "invalid username  or PAssword");
            }
            return View("Login",userVM);
        }


        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
