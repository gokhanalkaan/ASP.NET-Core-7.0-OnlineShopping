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
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly  IProductCategoryDal _productCategoryDal ;

        public ProductCategoryService(IProductCategoryDal productCategoryDal)
        {
            _productCategoryDal = productCategoryDal;
        }

        public void TDelete(ProductCategory t)
        {
            throw new NotImplementedException();
        }

        public void TDeleteAllProductCategoryWithCategoryId(int categoryId)
        {
            _productCategoryDal.DeleteAllProductCategoryWithCategoryId(categoryId);
        }

        public ProductCategory TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProductCategory> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TInsert(ProductCategory t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(ProductCategory t)
        {
            throw new NotImplementedException();
        }
    }
}
