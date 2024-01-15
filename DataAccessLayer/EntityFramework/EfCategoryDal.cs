using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public List<Product> getProductListWithCategory(int id)
        {
           
             using var context = new ApplicationDbContext();
            return context.ProductCategories.Where(pc => pc.CategoryId == id).Select(p => p.Product).ToList();
        }
    }
}
