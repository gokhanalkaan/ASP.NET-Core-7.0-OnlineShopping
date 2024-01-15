using BusinessLayer.Abstract;
using DTOLayer;
using EntityLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;

        public CommentController(ICommentService commentService, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddComment( CommentDto comment)
        {
            var userId = _userManager.GetUserId(User);
            var newComment = new Comment()
            {
                ProductId = (int)comment.ProductId ,
                Point=comment.Point,
                CommentText=comment.CommentText,
                CommentTitle=comment.CommentTitle,
                UserId=Int32.Parse(userId)
            };
          Console.WriteLine("my comment"+comment.CommentText+comment.CommentTitle+comment.Point+comment.UserId);
            _commentService.TInsert(newComment);
            return Redirect("/Product?productId=" + comment.ProductId);

        }

        [HttpPost]
        public IActionResult UpdateComment(CommentDto comment)
        {
            var userId = _userManager.GetUserId(User);
            var updatedComment = new Comment()
            {
                Id=(int)comment.Id!,
                ProductId = (int)comment.ProductId!,
                Point = comment.Point,
                CommentText = comment.CommentText,
                CommentTitle = comment.CommentTitle,
                UserId = Int32.Parse(userId)
            };
            _commentService.TUpdate(updatedComment);
            return Redirect("/Product?productId="+comment.ProductId);

        }
    }
}
