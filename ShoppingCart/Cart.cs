using ProductWebapp.Models;

namespace ProductWebapp.ShoppingCart
{
    public class Cart
    {
        private static Cart _instance { get; set; } = null;
        public List<Product> products { get; set; } = new List<Product> { };
        public string name { get; set; } = "test Cart";
        private Cart() { }
        public static Cart Instance()
        {
            if (_instance == null) _instance = new Cart();
            return _instance;
        }

        public void addToCart(Product product)
        {
            products.Add(product);
        }

        public void removeFromCart(Product product) 
        { 
            products.Remove(product);
        }
    }
}
