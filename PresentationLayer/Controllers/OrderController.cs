using BusinessLayer.Abstract;
using DTOLayer;
using EntityLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Stripe;
using Stripe.Checkout;

namespace PresentationLayer.Controllers
{
  
    public class OrderController : Controller { 


    private readonly UserManager<AppUser> _userManager;
    private readonly ICartService _cartService;
    private readonly ICartItemService _cartItemService;
    private readonly IOrderService _orderService;
    private readonly IOrderItemService  _orderItemService;

        public OrderController(UserManager<AppUser> userManager, ICartService cartService, ICartItemService cartItemService, IOrderService orderService, IOrderItemService orderItemService)
        {
            _userManager = userManager;
            _cartService = cartService;
            _cartItemService = cartItemService;
            _orderService = orderService;
            _orderItemService = orderItemService;
            StripeConfiguration.ApiKey = "Your stripe key will be here";
        }


        public async Task<IActionResult> Index()
        {
           
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }
            //_userManager.GetUserId(User);
            var orders=   _orderService.TGetUserOrderWithUserIdList(user.Id);
            List<OrderDto> ?orderDtoItems =new List<OrderDto>();

        foreach (var order in orders)
            {
                   List<OrderItem> orderProduct = _orderItemService.TGetOrderItemsWithOrderId(order.Id);
                List<OrderProductDto> orderProductsDto = new List<OrderProductDto>();
                foreach(var product in orderProduct)
                {
                    orderProductsDto.Add(new OrderProductDto() {
                        ProductId=product.ProductId,
                        ProductDescription=product.Product.ProductDescription,
                        ProductName=product.Product.ProductName,
                        ProductPhotoUrl=product.Product.ProductPhotoUrl,
                        ProductPrice=product.Product.ProductPrice,
                        ProductTitle=product.Product.ProductTitle,
                        Quantity=product.Quantity
                        
                    
                    
                    });
                }
                orderDtoItems.Add(
                    new OrderDto()
                    {Id=order.Id,
                    Address=order.Address,
                    City=order.City,
                    Country     =order.Country,
                      PhoneNumber=order.PhoneNumber,
                      PostalCode=order.PostalCode,
                      PostOffice=order.PostOffice,
                      Total=order.Total,
                      OrderProducts= orderProductsDto

                    }
                    
                    );
            }
         
            return View(orderDtoItems ?? new List<OrderDto>());
        }

        [HttpPost("create-checkout-session")]
        public  ActionResult CreateCheckoutSession()
        {
         
            var userId = _userManager.GetUserId(User);
        
             if (userId == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var userCart = _cartService.TGetCartWithUserId(Int32.Parse(userId));

            if (userCart != null)
            {
                Console.WriteLine("cartid" + userCart.Id);


                var cartItems = _cartItemService.TGetCartItemsWithQuery(userCart.Id);
                if (cartItems.Count == 0)
                {
                    return RedirectToAction("Index", "Cart");

                }
                decimal total = 0;
                List<SessionLineItemOptions> itemList = new List<SessionLineItemOptions>();
                List<OrderItem> orderItem = new List<OrderItem>();
              

                foreach (var item in cartItems)
                {
                    itemList.Add(new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = (long?)(item.Product.ProductPrice*100),
                            Currency = "usd",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = item.Product.ProductName,
                                Images = new List<string> { item.Product.ProductPhotoUrl }
                            },
                        },
                        Quantity = item.Quantity,
                    });

                    orderItem.Add(new OrderItem()
                    {
                        ProductId = item.ProductId,
                        Quantity= item.Quantity,

                    });


                }



                Console.WriteLine("item count" + itemList.Count);



                var options = new SessionCreateOptions
                {
                    LineItems = itemList,
                    Mode = "payment",
                    ShippingAddressCollection=new SessionShippingAddressCollectionOptions { 
                    AllowedCountries = new List<string> {"TR","US","CA", } },
                    
                   
                  
             
                    SuccessUrl = "http://localhost:5240/order/success?session_id={CHECKOUT_SESSION_ID}",
                    CancelUrl = "http://localhost:5240/Home/Error",
                };
                var service = new SessionService();
                Session session = service.Create(options);


               
               




                Response.Headers.Add("Location", session.Url);
              


                return new StatusCodeResult(303);







            }








            return RedirectToAction("Index", "Cart");






        }
    }
}
