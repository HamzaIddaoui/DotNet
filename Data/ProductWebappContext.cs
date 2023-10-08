using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductWebapp.Models;

namespace ProductWebapp.Data
{
    public class ProductWebappContext : DbContext
    {
        public ProductWebappContext (DbContextOptions<ProductWebappContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite(@"Data Source=F:\Databases\Product.db");

        public DbSet<ProductWebapp.Models.Product> Product { get; set; } = default!;
    }
}
