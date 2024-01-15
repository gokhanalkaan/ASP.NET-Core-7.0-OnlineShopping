using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class _WeeklyMostSelledProducts : ViewComponent
    {
        private readonly IProductService _productService;

        public _WeeklyMostSelledProducts(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var popularProducts = _productService.TGetMostOrderedItems("week");
            return View(popularProducts);
        }
    }
}
