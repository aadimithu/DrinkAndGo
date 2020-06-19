using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderService.Model;
using Microsoft.AspNetCore.Mvc;
using OrderService.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using OrderService.ViewModel;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace OrderService.Controllers
{
    public class OrderService : Controller
    {
        
        private readonly IProductRepository _ProductRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        private const string sessionKeyCart = "_cart";
        private const string sessionKeyUserId = "_userId";


        public OrderService(IProductRepository ProductRepository, UserManager<ApplicationUser> userManager)
        {
            _ProductRepository = ProductRepository;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            var Products = _ProductRepository.GetAll();
            return View(Products);
           
        }
 
       [Authorize]
        public IActionResult AddToCart(Guid id)
        {
            var currentCartItems = HttpContext.Session.Get<List<CartItem>>(sessionKeyCart);
            var userSessionId = HttpContext.Session.Get<Guid>(sessionKeyUserId);
            var actualUserId = Guid.Parse(_userManager.GetUserId(User));

            List<CartItem> cartItems = new List<CartItem>();

            
            if (currentCartItems != null)
            {
                cartItems = currentCartItems;
                if (userSessionId != actualUserId)
                {
                    currentCartItems = null;
                    HttpContext.Session.Clear();
                    cartItems = new List<CartItem>();

                }

                HttpContext.Session.Set<Guid>(sessionKeyUserId, actualUserId);
              
            }
            if (currentCartItems != null && currentCartItems.Any(fp => fp.Product.Id == id))
            {
                int ProductIndex = currentCartItems.FindIndex(fp => fp.Product.Id == id);
                currentCartItems[ProductIndex].Amount += 1;
                cartItems = currentCartItems;
            }
            else
            {
                var Product = _ProductRepository.GetProById(id);
                CartItem newCartItem = new CartItem()
                {
                    Product = Product,
                    Amount = 1
                };
                cartItems.Add(newCartItem);
            }
            
            HttpContext.Session.Set<List<CartItem>>(sessionKeyCart, cartItems);

            return RedirectToAction("Index");
        }


    }


   
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default :
                                  JsonConvert.DeserializeObject<T>(value);
        }
    }
}