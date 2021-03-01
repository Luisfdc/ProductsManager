using Microsoft.EntityFrameworkCore;
using ProductsManager.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsManager.Infra.Data.Context
{
    public class ProductContext : DbContext
    {
       
        public ProductContext(DbContextOptions<ProductContext> opcoes)
            : base(opcoes)
        {
        }

        public DbSet<Product> Product { get; set; }
    }
}
