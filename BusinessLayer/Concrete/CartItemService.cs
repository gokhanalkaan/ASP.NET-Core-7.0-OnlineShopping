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
    public class CartItemService : ICartItemService
    {

        private readonly ICartItemDal _cartItemDal;

        public CartItemService(ICartItemDal cartItemDal)
        {
            _cartItemDal = cartItemDal;
        }

        public List<CartItem> TGetCartItemsWithQuery(int cartId)
        {
            return _cartItemDal.GetCartItemsWithQuery(cartId);
        }

        public void TDelete(CartItem t)
        {
           _cartItemDal.Delete(t);
        }

        public CartItem TGetByID(int id)
        {
            return _cartItemDal.GetByID(id);
        }

        public List<CartItem> TGetList()
        {
          return  _cartItemDal.GetList();
        }

        public void TInsert(CartItem t)
        {
           _cartItemDal.Insert(t);
        }

        public void TUpdate(CartItem t)
        {
           _cartItemDal.Update(t);
        }
    }
}
