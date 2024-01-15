using BusinessLayer.Abstract;
using DTOLayer;
using EntityLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCategoryController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;

        public AdminCategoryController(IProductService productService, ICategoryService categoryService, UserManager<AppUser> userManager)
        {
            _productService = productService;
            _categoryService = categoryService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult InsertCategory()
        {
            var user = _userManager.GetUserAsync(User).Result;
            if (user == null)
            {
                return RedirectToAction("Error", "Home");

            }
            if (_userManager.IsInRoleAsync(user, "Admin").Result)
            {
               
                return View();

            }
            else
            {
                return RedirectToAction("/", "Error");
            }


        }

     



        [HttpPost]
        public IActionResult InsertCategory(AddCategoryDto newCategory)
        {
            var user = _userManager.GetUserAsync(User).Result;
            if (user == null)
            {
                return RedirectToAction("Error", "Home");

            }
            if (_userManager.IsInRoleAsync(user, "Admin").Result)
            {
                _categoryService.TInsert(new Category()
                {
                    CategoryName= newCategory.CategoryName
                });

                return View();

            }
            else
            {
                return RedirectToAction("/", "Error");
            }


        }


        public IActionResult GetCategoryList()
        {
            var user = _userManager.GetUserAsync(User).Result;
            if (user == null)
            {
                return RedirectToAction("Error", "Home");

            }
            if (_userManager.IsInRoleAsync(user, "Admin").Result)
            {
                var categories = _categoryService.TGetList();

                return View(categories);

            }
            else
            {
                return RedirectToAction("/", "Error");
            }


        }



        [HttpGet]
        public IActionResult EditCategory(int categoryId)
        {
            var user = _userManager.GetUserAsync(User).Result;
            if (user == null)
            {
                return RedirectToAction("Error", "Home");

            }
            if (_userManager.IsInRoleAsync(user, "Admin").Result)
            {
                var category = _categoryService.TGetByID(categoryId);

                return View(category);

            }
            else
            {
                return RedirectToAction("/", "Error");
            }


        }

        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            var user = _userManager.GetUserAsync(User).Result;
            if (user == null)
            {
                return RedirectToAction("Error", "Home");

            }
            if (_userManager.IsInRoleAsync(user, "Admin").Result)
            {
                _categoryService.TUpdate(category);

                return View();

            }
            else
            {
                return RedirectToAction("/", "Error");
            }


        }






        [HttpPost("AdminCategory/deleteCategory")]
        public IActionResult removeCategory(int categoryId)
        {
            Console.WriteLine("ctid" + categoryId);
            var user = _userManager.GetUserAsync(User).Result;
            if (user == null)
            {
                return RedirectToAction("Error", "Home");

            }
            if (_userManager.IsInRoleAsync(user, "Admin").Result)
            {
                var category = _categoryService.TGetByID(categoryId);
                _categoryService.TDelete(category);

                return Ok();

            }
            else
            {
                return RedirectToAction("/", "Error");
            }


        }













    }
}
