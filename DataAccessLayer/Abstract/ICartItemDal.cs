﻿using DataAccessLayer.Concrete;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICartItemDal : IGenericDal<CartItem>
    {
        List<CartItem> GetCartItemsWithQuery(int id);
    }
}
