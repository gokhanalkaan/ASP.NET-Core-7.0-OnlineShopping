using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderService(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public void TDelete(Order t)
        {
            throw new NotImplementedException();
        }

        public Order TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> TGetList()
        {
            throw new NotImplementedException();
        }

        public List<Order> TGetUserOrderWithUserIdList(int userId)
        {
            return _orderDal.GetAllUserOrdersWithId(userId);
        }

        public void TInsert(Order t)
        {
            _orderDal.Insert(t);
        }

        public bool TIsUserOrdered(int userId, int productId)
        {
            return _orderDal.IsUserOrdered(userId,productId);
        }

        public void TUpdate(Order t)
        {
            throw new NotImplementedException();
        }

     
    }
}
