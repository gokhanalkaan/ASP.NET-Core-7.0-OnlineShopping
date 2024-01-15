using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService :IGenericService<Category>
    {
        public List<Product> TgetProductListWithCategory(int id);
    }
}
