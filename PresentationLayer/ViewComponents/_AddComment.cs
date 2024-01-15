using BusinessLayer.Abstract;
using DTOLayer;
using EntityLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace PresentationLayer.ViewComponents
{
    public class _AddComment : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
         private readonly IOrderService _orderService;
        private readonly ICommentService _commentService;

        public _AddComment(UserManager<AppUser> userManager, IOrderService orderService, ICommentService commentService)
        {
            _userManager = userManager;
            _orderService = orderService;
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int productId)
        {

          var userId=  _userManager.GetUserId((System.Security.Claims.ClaimsPrincipal)User);
            
            if (userId == null)
            {
                return View();
            }

          bool isOrdered=  _orderService.TIsUserOrdered(Int32.Parse(userId!), productId);
            if (isOrdered)
            {
             Comment ? userComment=_commentService.TGetUserCommentFromProduct(Int32.Parse(userId!), productId);
               

                if (userComment != null)
                {
                    var cmdto = new CommentDto();

                    cmdto.CommentText = userComment.CommentText;
                    cmdto.CommentTitle = userComment.CommentTitle;
                    cmdto.Id = userComment.Id;
                    cmdto.ProductId = userComment.ProductId;
                    cmdto.Point = userComment.Point;


                    ViewBag.comment = cmdto ;

                }

                ViewBag.productId = productId;
             
            
               
                ViewBag.isOrdered=isOrdered;
                return View();

            }
            else
            {
                return View();

            }
          
       
        }
    }
}
