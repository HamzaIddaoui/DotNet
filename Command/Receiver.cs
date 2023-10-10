
using ProductWebapp.Models;
using ProductWebapp.ShoppingCart;

namespace ProductWebapp.Command
{
    public class Receiver
    {
        private static Receiver _instance { get; set; } = null;
        private Receiver() { }
        public static Receiver Instance()
        {
            if(_instance == null) _instance = new Receiver();
            return _instance;
        }

        public void addToCart(Product product)
        {
            Cart cart = Cart.Instance();
            cart.addToCart(product);
        }

        public void removeFromCart(Product product) 
        { 
            Cart cart = Cart.Instance();
            cart.removeFromCart(product);
        }
    }
}
