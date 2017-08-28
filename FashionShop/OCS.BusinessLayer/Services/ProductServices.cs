using AutoMapper;
using OCS.BusinessLayer.Models;
using OCS.DataAccess;
using OCS.DataAccess.Repositories;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using OCS.BusinessLayer.Services.Filters;

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
                mappedProduct.Brand = brand;
            }
            var categ = categoryRepository.GetCategoryByName(productModel.Category);
            if (categ != null)
            {
                mappedProduct.Category = categ;
            }

            repository.SaveProduct(mappedProduct);
        }
        
        public IEnumerable<ProductModel> FilteredSearch(string searchString, IEnumerable<CategoryModel> categories = null, IEnumerable<BrandModel> brands = null)
        {
            IEnumerable<Product> products = repository.GetAllProducts().ToList();
            AbstractFilter filter=new AbstractFilter();
            if (searchString!=null)
            {
                filter = new NameSearchStringFilter(products, searchString, filter);
            }
            if (categories != null)
            {
                foreach(var categ in categories)
                {
                    filter = new CategoryFilter(products, categ.Name, filter);
                }
            }
            if (brands != null)
            {
                foreach(var brand in brands)
                {
                    filter = new BrandFilter(products, brand.Name, filter);
                }
            }
            FilterResult result = filter.Resolve();
            var filteredProducts = result.Result();
            Mapper.Map<IEnumerable<ProductModel>>(filteredProducts);
            return Mapper.Map<IEnumerable<ProductModel>>(filteredProducts);
        }
    }
}
