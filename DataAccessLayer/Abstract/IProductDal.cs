using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> GetBestRankedProducts();
        List<Product> GetBestRankedProductsByCategory(int categoryId);
        List<Product> GetFilteredProducts(int? categoryId, string? priceOrder, int? minRating);
        List<Product> GetMostOrderedItems( string timeCategory);
        float GetProductPoint(int productId);
    }
}
