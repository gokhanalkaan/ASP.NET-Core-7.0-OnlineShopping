using BusinessLayer.Abstract;
using EntityLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class _ProductPoint:ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductPoint(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke(int productId)
        {
            

            float productPoint = _productService.TGetProductPoint(productId);


            ViewBag.point=productPoint;

            return View();
        }
    }
}
