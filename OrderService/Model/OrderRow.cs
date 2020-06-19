using OrderService.ViewModel;

namespace OrderService.Model
{
    public class OrderRow
    {
        
        public OrderRow(CartItem cartItem)
        {
            Amount = cartItem.Amount;
            Product = cartItem.Product;
        }
        public OrderRow() { }
        public Product Product { get; set; }
        public int Amount { get; set; }
     
    }
}
