using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class _BestRankedProducts:ViewComponent
    {
        private readonly IProductService _productService;

        public _BestRankedProducts(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
          var products=  _productService.TGetBestRankedProducts();
            return View(products);

        }
        
    
    }
}
