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
    public class EfCartDal : GenericRepository<Cart>, ICartDal
    {
        public Cart GetCartWithUserId(int id)
        {
            using var context = new ApplicationDbContext();
            return context.Carts.Include(ci => ci.CartItems).Where(c => c.UserId == id).FirstOrDefault();
        }
    }
}
