using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class _MonthlyMostSelledProducts:ViewComponent
    {
        private readonly IProductService _productService;

        public _MonthlyMostSelledProducts(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var popularProducts = _productService.TGetMostOrderedItems("month");
            return View(popularProducts);
        }
    }
}
