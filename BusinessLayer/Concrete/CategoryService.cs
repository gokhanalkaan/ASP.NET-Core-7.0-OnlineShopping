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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryDal _categoryDal ;

        public CategoryService(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Product> TgetProductListWithCategory(int id)
        {
            return _categoryDal.getProductListWithCategory(id);
        }

        public void TDelete(Category t)
        {
            _categoryDal.Delete(t);
        }

        public Category TGetByID(int id)
        {
            return _categoryDal.GetByID(id);
        }

        public List<Category> TGetList()
        {
          return  _categoryDal.GetList();
        }

        public void TInsert(Category t)
        {
             _categoryDal.Insert(t);
        }

        public void TUpdate(Category t)
        {
             _categoryDal.Update(t);
        }
    }
}
