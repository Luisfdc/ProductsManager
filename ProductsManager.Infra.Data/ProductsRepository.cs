using ProductsManager;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ProductsManager;
using ProductsManager.Infra.Data.DataBase;
using ProductsManager.Interfaces;
using ProductsManager.Entities;

namespace ProductsManager.Infra.Data
{
    public class ProductsRepository : IProductsRepository
    {
        private string[] args;

        public void Add(Product Entity)
        {
            using (var db = new DesignTimeDbContextFactory().CreateDbContext(args))
            {
                db.Add(Entity);
                db.SaveChanges();
            }
        }

        public void Delete(int Id)
        {

            using (var db = new DesignTimeDbContextFactory().CreateDbContext(args))
            {
                var product = db.Product.FirstOrDefault(x => x.Id == Id);
                db.Product.Remove(product);
                db.SaveChanges();
            }
        }


        public Product GetEntity(int Id)
        {
            Product product;

            using (var db = new DesignTimeDbContextFactory().CreateDbContext(args))
            {
                product = db.Product.FirstOrDefault(x => x.Id == Id);
            }

            return product;
        }


        public List<Product> List()
        {
            using (var db = new DesignTimeDbContextFactory().CreateDbContext(args))
            {
                return db.Product.ToList();

            }
        }

        public void Update(Product Entity)
        {
            using (var db = new DesignTimeDbContextFactory().CreateDbContext(args))
            {
                var dbProduct = db.Product.FirstOrDefault(x => x.Id == Entity.Id);

                dbProduct.Description = Entity.Description;
                dbProduct.Price = Entity.Price;
                dbProduct.Image = Entity.Image;

                db.Product.Update(dbProduct);
                db.SaveChanges();
            }
        }
    }
}
