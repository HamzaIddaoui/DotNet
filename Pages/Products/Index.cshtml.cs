using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductWebapp.Command;
using ProductWebapp.Data;
using ProductWebapp.Models;
using ProductWebapp.ShoppingCart;

namespace ProductWebapp.Pages.Products
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly ProductWebapp.Data.ProductWebappContext _context;
        public ShoppingCart.Cart cart { get; set; }  = ShoppingCart.Cart.Instance();

        public IndexModel(ProductWebapp.Data.ProductWebappContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        [BindProperty(SupportsGet =true)]
        public string? Searchstring { get; set; } 
        public SelectList? Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? ProductGenre { get; set; }

        public async Task OnGetAsync()
        {
            var products = from p in _context.Product select p;
            foreach(var p in products)
            {
                if (string.IsNullOrEmpty(p.imagePath))
                    p.imagePath = "notfound.png";
            }
            if (!string.IsNullOrEmpty(Searchstring))
            {
                products = products.Where( s => s.Title.Contains(Searchstring));
            }
            Product = await products.ToListAsync();
        }

        /**
        public async Task<IActionResult> OnPostaddToCart(int id)
        {
            var product = _context.Product.FirstOrDefault(p => p.Id == id);
            AddToCart addToCart = new AddToCart(product);
            Invoker invoker = Invoker.Instance();
            invoker.addCommand(addToCart);
            return Page();
        }
        **/

  
    }
}
