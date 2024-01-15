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
    public class EfOrderItemDal : GenericRepository<OrderItem>, IOrderItemDal
    {
  

        public List<OrderItem> GetOrderItemsWithOrderId(int OrderId)
        {
            using var context = new ApplicationDbContext();
            return context.OrderItems.Where(item=>item.OrderId == OrderId).Include(p=>p.Product).ToList();
        }
    }
}
