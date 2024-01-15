using BusinessLayer.Abstract;
using DTOLayer;
using EntityLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Admin.Controllers
{

    [Area("Admin")]
   // [Authorize(Roles = "Admin")]

    public class AdminProductController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly UserManager<AppUser> _userManager;

        public AdminProductController(SignInManager<AppUser> signInManager, IProductService productService, ICategoryService categoryService, IProductCategoryService productCategoryService, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _productService = productService;
            _categoryService = categoryService;
            _productCategoryService = productCategoryService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var user = _userManager.GetUserAsync(User).Result;
            if (user == null)
            {
                return RedirectToAction("Error", "Home");

            }
            if (_userManager.IsInRoleAsync(user, "Admin").Result)
            {
                // Kullanıcı admin rolüne sahip
                // İlgili işlemler burada yapılır
                ViewBag.username = user.UserName;
                return View();
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }



        }
      
        [HttpGet]
        public IActionResult InsertProduct()
        {
            var user = _userManager.GetUserAsync(User).Result;
            if (user == null)
            {
                return RedirectToAction("Error", "Home");

            }
            if (_userManager.IsInRoleAsync(user, "Admin").Result)
            {
                var cats = _categoryService.TGetList();
                ViewBag.v = cats;
                return View();

            }
            else
            {
                return RedirectToAction("/", "Error");
            }


        }

        [HttpPost]
        public IActionResult InsertProduct(AddProductDto addProductDto)
        {
            var user = _userManager.GetUserAsync(User).Result;
            if (user == null)
            {
                return RedirectToAction("Error", "Home");

            }

            if (_userManager.IsInRoleAsync(user, "Admin").Result) { 
                Console.WriteLine("ppppp:" + addProductDto.ProductCategoryIds.Count);
            Product product = new Product() { };

            List<ProductCategory> selectedCategories = new List<ProductCategory>();

            foreach (var c in addProductDto.ProductCategoryIds)
            {
                selectedCategories.Add(new ProductCategory() { CategoryId = c });
            }


            product.ProductTitle = addProductDto.ProductTitle;
            product.ProductPhotoUrl = addProductDto.ProductPhotoUrl;
            product.ProductPrice = addProductDto.ProductPrice;
            product.ProductDescription = addProductDto.ProductDescription;
            product.ProductName = addProductDto.ProductName;


            product.ProductCategory = selectedCategories;



            _productService.TInsert(product);


            return View();
                 }

            else
            {
                return RedirectToAction("Error", "Home");

            }
        
        
            }
  

        [HttpGet]
        public IActionResult EditProduct(int productId)
        {
            var user = _userManager.GetUserAsync(User).Result;
            if (user == null)
            {
                return RedirectToAction("Error", "Home");

            }
            if (_userManager.IsInRoleAsync(user, "Admin").Result)
            {
                var product = _productService.TGetByID(productId);
                var categories=_categoryService.TGetList();
                ViewBag.v=categories;


              


                return View(product);

            }
            else
            {
                return RedirectToAction("/", "Error");
            }


        }

        [HttpPost]
        public IActionResult EditProduct(AddProductDto   productDto)
        {
            var user = _userManager.GetUserAsync(User).Result;
            if (user == null)
            {
                return RedirectToAction("Error", "Home");

            }
            if (_userManager.IsInRoleAsync(user, "Admin").Result)
            {
                var product = new Product()
                {
                   ProductName = productDto.ProductName,
                   ProductDescription= productDto.ProductDescription,
                   ProductPrice= productDto.ProductPrice,
                   ProductPhotoUrl= productDto.ProductPhotoUrl,
                   ProductTitle= productDto.ProductTitle,


                };
                List<ProductCategory> selectedCategories = new List<ProductCategory>();

                foreach (var c in productDto.ProductCategoryIds)
                {
                    Console.WriteLine("category is " +c);
                    selectedCategories.Add(new ProductCategory() { CategoryId = c });
                }
                product.ProductCategory = selectedCategories;
                
             
                product.Id = (int)productDto.ProductId;
                










                _productCategoryService.TDeleteAllProductCategoryWithCategoryId(product.Id);


                _productService.TUpdate(product);

                return View();

            }
            else
            {
                return RedirectToAction("/", "Error");
            }


        }


        public IActionResult GetProductList()
        {
            var products = _productService.TGetList();
            
            return View(products);
        }

        [HttpPost("AdminProduct/deleteProduct")]
        public IActionResult removeProduct(int productId)
        {
    
            var user = _userManager.GetUserAsync(User).Result;
            if (user == null)
            {
                return RedirectToAction("Error", "Home");

            }
            if (_userManager.IsInRoleAsync(user, "Admin").Result)
            {
                Console.WriteLine("productid:" + productId);
                var product = _productService.TGetByID(productId);
                _productService.TDelete(product);

                return Ok();

            }
            else
            {
                return RedirectToAction("/", "Error");
            }


        }





    }
}
