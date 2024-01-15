﻿using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICartService:IGenericService<Cart>
    {
         Cart TGetCartWithUserId(int id);
       
    }
}
