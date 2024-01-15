using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class _YearlyMostSelledProducts : ViewComponent
    {
        private readonly IProductService _productService;

        public _YearlyMostSelledProducts(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var popularProducts = _productService.TGetMostOrderedItems("year");
            return View(popularProducts);
        }
    }
}
