using BusinessLayer.Abstract;
using EntityLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        private readonly IProductService _productService;

        public CategoryController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public IActionResult Index(int? categoryId)
        {
            ViewBag.v = _categoryService.TGetList();

            var productList = new List<Product>();
            if (categoryId != null)
            {

                productList = _categoryService.TgetProductListWithCategory(categoryId.Value);



            }
            else
            {
                productList = _productService.TGetList();
            }


            return View(productList);
        }


    }
}
