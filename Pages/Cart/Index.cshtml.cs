using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductWebapp.Command;
using ProductWebapp.Data;
using ProductWebapp.Models;
using ProductWebapp.ShoppingCart;

namespace ProductWebapp.Pages.Cart
{
    public class IndexModel : PageModel
    {
        private readonly ProductWebappContext _context;
        public IList<Product> Products { get; set; } = new List<Product>();
        public string Message { get; set; } = "test";

        public IndexModel(ProductWebappContext productWebappContext)
        {
            _context = productWebappContext;
        }
        public void OnGet()
        {
            ShoppingCart.Cart cart = ShoppingCart.Cart.Instance();
            foreach(var product in cart.products)
                Products.Add(product);
        }

        public IActionResult OnPost(int id)
        {
            var product = _context.Product.FirstOrDefault(p => p.Id == id);
            AddToCart addToCart = new AddToCart(product);
            Invoker invoker = Invoker.Instance();
            invoker.addCommand(addToCart);
            return RedirectToPage("/Cart/Index");
        }
    }
}
