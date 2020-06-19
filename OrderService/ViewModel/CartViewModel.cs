using OrderService.Model;
using System.Collections.Generic;
namespace OrderService.ViewModel
{
    public class CartViewModel
    {
        public List<CartItem> Products { get; set; }
        
        public decimal TotalPrice { get; set; }
    }

    public class CartItem
    {
        public Product Product { get; set; }
        public int Amount { get; set; }
    }
}
