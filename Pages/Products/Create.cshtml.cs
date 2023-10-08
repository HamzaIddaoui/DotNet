using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductWebapp.Data;
using ProductWebapp.Models;

namespace ProductWebapp.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly ProductWebapp.Data.ProductWebappContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;


        public CreateModel(ProductWebapp.Data.ProductWebappContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(IFormFile imageFile)
        {
            /**
            if (!ModelState.IsValid)
            {
                return Page();
            }
            **/
            if ((imageFile == null) || (imageFile.Length <= 0)) return Page();
            var fileName = Path.GetRandomFileName() + Path.GetExtension(imageFile.FileName);
            var imagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","images");
            var filePath = Path.Combine(imagesFolder, fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
                await imageFile.CopyToAsync(fileStream);
            Product.imagePath = fileName;
            _context.Product.Add(Product);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
            
        }
    }
}
