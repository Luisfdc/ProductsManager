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
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int Id);
    }
}