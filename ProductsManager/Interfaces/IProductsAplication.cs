using ProductsManager.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsManager.Interfaces
{
    public interface IProductsAplication
    {
        List<Product> GetAllProducts();
        Product GetProduct(int id);
        void AddProducts(Product product);
        void UpdateProducts(Product product);
        void DeleteProducts(int Id);
    }
}