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
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemDal _orderItemDal;

        public OrderItemService(IOrderItemDal orderItemDal)
        {
            _orderItemDal = orderItemDal;
        }

        public void TDelete(OrderItem t)
        {
            throw new NotImplementedException();
        }

        public OrderItem TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<OrderItem> TGetList()
        {
            throw new NotImplementedException();
        }

    

        public List<OrderItem> TGetOrderItemsWithOrderId(int orderId)
        {
            return _orderItemDal.GetOrderItemsWithOrderId(orderId);
        }

        public void TInsert(OrderItem t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(OrderItem t)
        {
            throw new NotImplementedException();
        }
    }
}
