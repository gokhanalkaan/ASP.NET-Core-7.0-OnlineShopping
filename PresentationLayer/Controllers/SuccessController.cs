using BusinessLayer.Abstract;
using EntityLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;

namespace PresentationLayer.Controllers
{
    public class SuccessController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICartService _cartService;
        private readonly ICartItemService _cartItemService;
        private readonly IOrderService _orderService;

     

        public SuccessController(UserManager<AppUser> userManager, ICartService cartService, ICartItemService cartItemService, IOrderService orderService)
        {
            _userManager = userManager;
            _cartService = cartService;
            _cartItemService = cartItemService;
            _orderService = orderService;
          
        }

        [HttpGet("order/success")]
        public IActionResult Success(string session_id)
        {
            var sessionService = new SessionService();
            Session session = sessionService.Get(session_id);
            ViewBag.sessionId=session.Id;
            ViewBag.name = session.ShippingDetails.Name;


            var userId = _userManager.GetUserId(User);
            var userCart = _cartService.TGetCartWithUserId(Int32.Parse(userId));
            var cartItems = _cartItemService.TGetCartItemsWithQuery(userCart.Id);
            var orderItems=new List<OrderItem>();
            Order newOrder = new Order()
                 {
                     Address = session.ShippingDetails.Address.Line1 + "/" + session.ShippingDetails.Address.Line2,
                     Country=session.ShippingDetails.Address.Country,
                     City=session.ShippingDetails.Address.City,
                     PostalCode=session.ShippingDetails.Address.PostalCode,
                     PhoneNumber=session.ShippingDetails.Phone,
                     Total=(decimal)session.AmountTotal!,
                     PostOffice=session.ShippingDetails.Address.State,
                     UserId = Int32.Parse( _userManager.GetUserId(User)!),
                     OrderItems = orderItems


             };
                 Console.WriteLine("ORDER:" + newOrder.Address);
                 
                 foreach (var item in cartItems)
                 {
                        Console.WriteLine(item);
                orderItems.Add(new OrderItem() {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,



                });

                     _cartItemService.TDelete(item);


                 }
            _orderService.TInsert(newOrder);

            return View();
        }
    }
}
