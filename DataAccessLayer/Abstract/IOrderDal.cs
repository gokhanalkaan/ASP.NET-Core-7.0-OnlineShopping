using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IOrderDal:IGenericDal<Order>
    {
        List<Order> GetAllUserOrdersWithId(int id);
        bool IsUserOrdered(int userId, int productId);
    }
}
