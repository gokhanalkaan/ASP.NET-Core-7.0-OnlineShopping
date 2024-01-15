using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductService : IProductService

    {
        private readonly IProductDal _productDal;

        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }

       

        public void TDelete(Product t)
        {
            _productDal.Delete(t);
   
        }

        public List<Product> TGetBestRankedProducts()
        {
       return _productDal.GetBestRankedProducts();
        }

        public List<Product> TGetBestRankedProductsByCategory(int categoryId)
        {
            return _productDal.GetBestRankedProductsByCategory(categoryId);
        }

        public Product TGetByID(int id)
        {
            return _productDal.GetByID(id);
        }

        public List<Product> TGetFilteredProducts(int? categoryId, string? priceOrder, int? minRating)
        {
          return  _productDal.GetFilteredProducts(categoryId, priceOrder, minRating);
        }

        public List<Product> TGetList()
        {
            return _productDal.GetList();
        }

        public List<Product> TGetMostOrderedItems(string timeCategory)
        {
            return _productDal.GetMostOrderedItems( timeCategory);
        }

        public float TGetProductPoint(int productId)
        {
            return _productDal.GetProductPoint(productId);
        }

        public void TInsert(Product t)
        {
          _productDal.Insert(t);
        }

        public void TUpdate(Product t)
        {
             _productDal.Update(t);   
        }

     
    }
}
