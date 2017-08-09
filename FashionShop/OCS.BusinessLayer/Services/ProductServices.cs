using AutoMapper;
using OCS.BusinessLayer.Models;
using OCS.DataAccess;
using OCS.DataAccess.Repositories;
using System.Collections.Generic;
using System;

namespace OCS.BusinessLayer.Services
{
    class ProductServices
    {
        private IProductRepository repository;

        public IEnumerable<ProductModel> GetAll()
        {
            IEnumerable<Product> listOfProducts =  repository.GetAllProducts();
            List<ProductModel> mappedProducts = new List<ProductModel>();

            foreach (Product p in listOfProducts)
            {
                ProductModel mappedProduct = Mapper.Map<ProductModel>(p);
                mappedProducts.Add(mappedProduct);
            }
            return mappedProducts;
        }

        public ProductModel GetByID(Guid id)
        {
            Product product = repository.GetProductById(id);
            ProductModel mappedProduct = Mapper.Map<ProductModel>(product);
            return mappedProduct;
        }

        public void AddProduct(ProductModel productModel)
        {
            Product mappedProduct = Mapper.Map<Product>(productModel);
            repository.SaveProduct(mappedProduct);
        }
    }
}
