using BusinessLayer.Abstract;
using DTOLayer;
using EntityLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class ProductController : Controller
    {

        private readonly ICategoryService _categoryService;

        private readonly IProductService _productService;

        public ProductController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

     
        public IActionResult Index(int productId)
        {
         var product=   _productService.TGetByID(productId!);
            var addBasketProductvm = new AddtoBasketDto() { ProductId = product.Id,
                ProductDescription = product.ProductDescription,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ProductPhotoUrl = product.ProductPhotoUrl,
                ProductTitle = product.ProductTitle,
                Quantity = 1
          
          };
            return View(addBasketProductvm);
        }

        public IActionResult FilterProduct(int? categoryId,string? priceOrder,int? minRating)
        {
            ViewBag.v = _categoryService.TGetList();

          
            Console.WriteLine(priceOrder);
            Console.WriteLine(minRating);
            ViewBag.minRating = minRating;
            ViewBag.category = categoryId;
            ViewBag.priceOrder = priceOrder;

            var productList = new List<Product>();
            if (categoryId != null || priceOrder!=null || minRating!=null)
            {

                productList = _productService.TGetFilteredProducts(categoryId, priceOrder, minRating);



            }
            else
            {
                productList = _productService.TGetList();
            }


            return View(productList);
        }


    }
}
