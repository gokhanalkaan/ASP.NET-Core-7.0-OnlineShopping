using BusinessLayer.Abstract;
using EntityLayer.Models;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using System.Diagnostics;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        

        private readonly ICategoryService _categoryService;

        private readonly IProductService _productService;

        public HomeController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public IActionResult Index(int ?id)
        {
            ViewBag.v =_categoryService.TGetList();

            var productList = new List<Product>();
            if (id!=null)
            {
              
             productList = _categoryService.TgetProductListWithCategory(id.Value);

           

            }
            else
            {
                productList = _productService.TGetList();
            }
          

            return View(productList);
        }

        [HttpGet("Home/Privacy")]
        public IActionResult Privacy( string session_id)
        {
            Console.WriteLine("session_id"+ session_id);
            return View();
        }

      
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
