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
    public class CommentService : ICommentService
    {
        private readonly ICommentDal _commentDal;

        public CommentService(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void TDelete(Comment t)
        {
            _commentDal.Delete(t);
        }

        public Comment TGetByID(int id)
        {
            return _commentDal.GetByID(id);
        }

        public List<Comment> TGetCommentsByBlog(int id)
        {
            return _commentDal.FindAll(comment => comment.ProductId == id);
        }

        public List<Comment> TGetList()
        {
            return _commentDal.GetList();
        }

        public Comment ? TGetUserCommentFromProduct(int userId, int productId)
        {
           return _commentDal.GetUserCommentFromProduct(userId,productId);
        }

        private Comment _commentDalGetUserCommentFromProduct(string userId, int productId)
        {
            throw new NotImplementedException();
        }

        public void TInsert(Comment t)
        {
            _commentDal.Insert(t);
        }

        public void TUpdate(Comment t)
        {
            _commentDal.Update(t);
        }
    }
}
