using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IOrderService:IGenericService<Order>
    {
        List<Order> TGetUserOrderWithUserIdList(int userId);
        bool TIsUserOrdered(int userId,int productId);
        

    }
}
