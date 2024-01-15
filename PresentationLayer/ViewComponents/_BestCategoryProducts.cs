using BusinessLayer.Abstract;
using EntityLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class _BestCategoryProducts : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public _BestCategoryProducts(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke(Category cat)
        {
            ViewBag.category=cat;
         
           var products = _productService.TGetBestRankedProductsByCategory(cat.Id);
               
                 
            

            return View(products);
        }
    }
}
