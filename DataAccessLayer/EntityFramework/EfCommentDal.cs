using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public Comment ? GetUserCommentFromProduct(int userId, int productId)
        {
            using var context = new ApplicationDbContext();
            return context.Comments.Where(c => c.UserId==userId && c.ProductId==productId).SingleOrDefault();
       
        }
    }
}
