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
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public List<Order> GetAllUserOrdersWithId(int id)
        { using var context =new ApplicationDbContext();
            return  context.Orders.Where(o=>o.UserId == id).Include(orderItem => orderItem.OrderItems).ToList();
        }

        public bool IsUserOrdered(int userId, int productId)
        {
            using var context = new ApplicationDbContext();

            return context.Orders.Any(u => u.UserId==userId && u.OrderItems.Any(u=>u.ProductId==productId));
        }
    }
}
