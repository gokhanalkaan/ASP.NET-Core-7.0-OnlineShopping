using DTOLayer;
using EntityLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginDto userLoginDto)
        {

            Console.WriteLine(userLoginDto.Password);
            
            var result =await _signInManager.PasswordSignInAsync(userLoginDto.Username, userLoginDto.Password,  false, true);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(userLoginDto.Username);
                if (await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    return Redirect("/Admin/AdminProduct/Index");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
                
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {

            await _signInManager.SignOutAsync();
            
                return RedirectToAction("Index", "Home");
            
          
        }


    }
}
