using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class _DailyMostSelledProducts : ViewComponent
    {
        private readonly IProductService _productService;

        public _DailyMostSelledProducts(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var popularProducts = _productService.TGetMostOrderedItems("day");
            return View(popularProducts);
        }
    }
}
