using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class _ProductComments:ViewComponent
    {
        private readonly ICommentService _commentService;

        public _ProductComments(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var popularProducts = _commentService.TGetCommentsByBlog(id);
            return View(popularProducts);
        }
    }
}
