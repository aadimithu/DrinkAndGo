using System;
using System.Collections.Generic;
using System.Linq;
using OrderService.Model;
using OrderService.Repository;
using OrderService.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OrderService.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository _ProductRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        private const string sessionKeyCart = "_cart";
        private const string sessionKeyUserId = "_userId";

        public CartController(IProductRepository ProductRepository, UserManager<ApplicationUser> userManager)
        {
            _ProductRepository = ProductRepository;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.Get<List<CartItem>>(sessionKeyCart);
            var products = _ProductRepository.GetAll();

            CartViewModel vm= new CartViewModel();
            vm.Products = cart;

            vm.TotalPrice = vm.Products.Sum(fp => fp.Product.Price * fp.Amount);

            return View(vm);
        }

        public IActionResult Delete(Guid id)
        {
            var cart = HttpContext.Session.Get<List<CartItem>>(sessionKeyCart).ToList();
            if (cart != null)
            {
                HttpContext.Session.Remove(sessionKeyCart);
                HttpContext.Session.Set(sessionKeyCart, cart.Where(x => x.Product.Id != id));               
            }            
            return RedirectToAction("Index");

        }
        
        
        [HttpPost]
        public async Task<IActionResult> MyOrder([Bind("TotalPrice, Product")] CartViewModel cart)
        {
            cart.Products = HttpContext.Session.Get<List<CartItem>>(sessionKeyCart);
            OrderViewModel viewModel = new OrderViewModel();
            Order order = new Order();
            order.Date = DateTime.Now;
            order.TotalPrice = cart.TotalPrice;
            order.OrderRows = cart.Products.Select(cartItem => new OrderRow(cartItem)
            {
                Amount = cartItem.Amount,
                Product = cartItem.Product
            }).ToList();
            var userIdentity = User.FindFirstValue(ClaimTypes.NameIdentifier);
            order.UserId = Guid.Parse(_userManager.GetUserId(User));
           
            viewModel.Order = order;
            var user = await _userManager.GetUserAsync(User);
            viewModel.User = user;
            return View("OrderSuccess", viewModel);
        }

        public IActionResult OrderSuccess(Order order)
        {
            return View(order);
        }


    }
   
}