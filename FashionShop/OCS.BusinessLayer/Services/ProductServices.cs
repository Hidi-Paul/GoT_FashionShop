using AutoMapper;
using OCS.BusinessLayer.Models;
using OCS.DataAccess;
using OCS.DataAccess.Repositories;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;

namespace OCS.BusinessLayer.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository repository;
        private readonly IBrandRepository brandRepository;
        private readonly ICategoryRepository categoryRepository;

        public ProductServices(IProductRepository repository, IBrandRepository brandRepository, ICategoryRepository categoryRepository)
        {
            this.repository = repository;
            this.brandRepository = brandRepository;
            this.categoryRepository = categoryRepository;
        }

        public IEnumerable<ProductModel> GetAll()
        {
            IEnumerable<Product> listOfProducts = repository.GetAllProducts();

            IEnumerable<ProductModel> mappedProducts = Mapper.Map<IEnumerable<ProductModel>>(listOfProducts);

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

            mappedProduct.ProductID = Guid.NewGuid();

            var brand = brandRepository.GetBrandByName(productModel.Brand);
            if (brand != null)
            {
                mappedProduct.BrandID = brand.BrandID;
                mappedProduct.Brand = brand;
            }
            var categ = categoryRepository.GetCategoryByName(productModel.Category);
            if (categ != null)
            {
                mappedProduct.CategoryID = categ.CategoryID;
                mappedProduct.Category = categ;
            }

            repository.SaveProduct(mappedProduct);
        }

        public IEnumerable<ProductModel> SearchProduct(string searchString)
        {
            IEnumerable<Product> products = repository.GetAllProducts();

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.ProductName.ToUpper().Contains(searchString.ToUpper())).ToList();
            }

            IEnumerable<ProductModel> mappedProducts = Mapper.Map<IEnumerable<ProductModel>>(products);

            return mappedProducts;
        }

        public IEnumerable<Product> FilterByCategory(Category category, IEnumerable<Product> products)
        {
            return products.Where(p => p.Category.CategoryName == category.CategoryName);
        }

        public IEnumerable<Product> FilterByBrand(Brand brand, IEnumerable<Product> products)
        {
            return products.Where(p => p.Brand.BrandName == brand.BrandName);
        }

        public IEnumerable<ProductModel> Filter(string[] category, string[] brand)
        {
            IEnumerable<Product> products = repository.GetAllProducts();

            List<Product> filteredByCateg = new List<Product>();
            if (category != null)
            {
                foreach (string filter in category)
                {
                    var results = FilterByCategory(categoryRepository.GetCategoryByName(filter), products);
                    filteredByCateg.AddRange(results);
                }
            }
            List<Product> filteredByBrand = new List<Product>();
            if (brand != null)
            {
                foreach (string filter in brand)
                {
                    var results = FilterByBrand(brandRepository.GetBrandByName(filter), products);
                    filteredByBrand.AddRange(results);
                }
            }

            IEnumerable<Product> filteredProducts = filteredByBrand.Intersect(filteredByCateg);
            IEnumerable<ProductModel> mappedProducts = Mapper.Map<IEnumerable<ProductModel>>(filteredProducts);

            return mappedProducts;
        }
        public IEnumerable<ProductModel> FilteredSearch(string searchString, string[] category = null, string[] brand = null)
        {
            IEnumerable<ProductModel> filteredProducts;
            if (category == null && brand == null)
            {
                filteredProducts = SearchProduct(searchString);
            }
            else
            {
                filteredProducts = Filter(category, brand);
                filteredProducts = filteredProducts.Where(p => p.ProductName.Contains(searchString));
            }
            return filteredProducts;
        }
    }
}
