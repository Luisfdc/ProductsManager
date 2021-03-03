using ProductsManager;
using ProductsManager.Entities;
using ProductsManager.Interfaces;
using System;
using System.Collections.Generic;

namespace ProductsManager.Aplication
{
    public class ProductsAplication : IProductsAplication
    {
        private IProductsRepository _productsRepository;

        public ProductsAplication(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public void AddProduct(Product product)
        {
            _productsRepository.Add(product);
        }

        public void DeleteProduct(int id)
        {
            _productsRepository.Delete(id);
        }

        public List<Product> GetAllProducts()
        {
            return _productsRepository.List();
        }

        public Product GetProduct(int id)
        {
            return _productsRepository.GetEntity(id);
        }

        public void UpdateProduct(Product product)
        {
            _productsRepository.Update(product);
        }
    }
}
