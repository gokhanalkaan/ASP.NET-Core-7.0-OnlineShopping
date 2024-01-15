using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProductService:IGenericService<Product>
    {
        List<Product> TGetMostOrderedItems(string timeCategory);
        List<Product> TGetBestRankedProducts();
        List<Product> TGetBestRankedProductsByCategory(int categoryId);
        List<Product> TGetFilteredProducts(int? categoryId, string? priceOrder, int? minRating);
        float TGetProductPoint(int productId);
    }
}
