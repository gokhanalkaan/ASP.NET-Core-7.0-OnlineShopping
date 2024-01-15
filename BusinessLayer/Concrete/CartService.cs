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
    public class CartService : ICartService
    {
        private readonly ICartDal _cartDal;

        public CartService(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }

        public void TDelete(Cart t)
        {
            _cartDal.Delete(t);
        }

        public Cart TGetByID(int id)
        {
           return _cartDal.GetByID(id);
        }

        public Cart TGetCartWithUserId(int id)
        {
            return _cartDal.GetCartWithUserId(id);
        }

        public List<Cart> TGetList()
        {
            return _cartDal.GetList();
        }

        public void TInsert(Cart t)
        {
            _cartDal.Insert(t);
        }

        public void TUpdate(Cart t)
        {
            _cartDal.Update(t);
        }
    }
}
