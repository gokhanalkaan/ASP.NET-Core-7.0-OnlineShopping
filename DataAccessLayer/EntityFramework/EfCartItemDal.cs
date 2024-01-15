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
    public class EfCartItemDal : GenericRepository<CartItem>, ICartItemDal
    {
        public List<CartItem> GetCartItemsWithQuery(int id)
        {
            using var context= new  ApplicationDbContext();
           return context.CartItems.Include(ci => ci.Product).Where(c => c.CartId == id).ToList(); 
        }
    }
}
