using DTOLayer;
using EntityLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterDto userRegisterDto)
        {
            Console.WriteLine(userRegisterDto.Password + " -------- " + userRegisterDto.ConfirmPassword);

            if(userRegisterDto.Password == userRegisterDto.ConfirmPassword){
                AppUser appUser = new AppUser()
                {
                    Name = userRegisterDto.Name,
                    Surname = userRegisterDto.Surname,
                    UserName = userRegisterDto.Username,
                    Email = userRegisterDto.Email,
                    City=userRegisterDto.City,
                    District=userRegisterDto.District,
                    ImageUrl=userRegisterDto.ImageUrl,
                    ConfirmCode=111
                    


                };
                var result = await _userManager.CreateAsync(appUser, userRegisterDto.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");

                }
                return View();



            }

         
      

            return View();
           
        }
    }
}
