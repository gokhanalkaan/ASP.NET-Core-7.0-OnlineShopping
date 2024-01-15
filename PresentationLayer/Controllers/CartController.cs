using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DTOLayer;
using EntityLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{

    public class CartController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly ICartService _cartService;
        private readonly ICartItemService _cartItemService;

        public CartController(UserManager<AppUser> userManager, ICartService cartService, ICartItemService cartItemService)
        {
            _userManager = userManager;
            _cartService = cartService;
            _cartItemService = cartItemService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }
         var userCart=_cartService.TGetCartWithUserId(user.Id);
            if (userCart != null)
            {
                




              var cartItems=  _cartItemService.TGetCartItemsWithQuery(userCart.Id);
                decimal total = 0;
                foreach(var item in cartItems)
                {
                    total +=  item.Quantity * item.Product.ProductPrice;

                }
                ViewBag.cartTotal= total;



                     return View(cartItems);

            }
            return View();
          
           
        }

       
        public async Task<IActionResult>  AddToCart(AddtoBasketDto addtoBasketDto)
        {
            //   User.Identity.GetUserId();
            Console.WriteLine(addtoBasketDto.ProductId);
            var user=  await _userManager.GetUserAsync(User);
            if(user == null)
            {
                return RedirectToAction("Index", "Login");
            }

           

           
            var userCart = _cartService.TGetCartWithUserId(user.Id);


            if (userCart == null)
            {
                Cart newCart = new Cart()
                {
                    UserId = user.Id,


                    

                    CartItems = new List<CartItem>()
                {
                    new CartItem() { ProductId=addtoBasketDto.ProductId,Quantity=addtoBasketDto.Quantity,}
                },

                


                };




                Console.WriteLine("adding");
                _cartService.TInsert(newCart);
                return RedirectToAction("Index", "Cart");

            }

            else
            {
                
                CartItem ? item=userCart!.CartItems?.Find(c=>c.ProductId == addtoBasketDto.ProductId);
               


                if (item != null) {
                 

                    item.Quantity += addtoBasketDto.Quantity;
                    
                    Console.WriteLine("qty"+item.Quantity);
                    _cartItemService.TUpdate(item);
                  



                }
                else {
                    CartItem newCartItem = new CartItem()
                    {
                        CartId = userCart.Id,
                        ProductId = addtoBasketDto.ProductId,

                        Quantity = addtoBasketDto.Quantity,
                    };


                    _cartItemService.TInsert(newCartItem);


                }
               
                return RedirectToAction("Index", "Cart");
            }




           
          
         
        }
        [HttpPost("cart/removeFromCart")]
        public IActionResult RemoveFromCart(int cartItemId)
        {
            var cartItem = _cartItemService.TGetByID(cartItemId);
            _cartItemService.TDelete(cartItem!);
            return Ok();


        }

    }
}
