using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfProductCategoryDal : GenericRepository<ProductCategory>, IProductCategoryDal
    {
        public void DeleteAllProductCategoryWithCategoryId(int categoryId)
        {
            using var context = new ApplicationDbContext();
          var list=  context.ProductCategories.Where(p => p.ProductId==categoryId).ToList();
            foreach(var item in list )
            {
                context.Remove(item);
            }
            
            context.SaveChanges();
           
        }
    }
}
