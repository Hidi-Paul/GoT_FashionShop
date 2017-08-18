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
        private readonly IColorRepository colorRepository;
        private readonly IGenderRepository genderRepository;

        public ProductServices(IProductRepository repository, IBrandRepository brandRepository, ICategoryRepository categoryRepository, IColorRepository colorRepository, IGenderRepository genderRepository)
        {
            this.repository = repository;
            this.brandRepository = brandRepository;
            this.categoryRepository = categoryRepository;
            this.colorRepository = colorRepository;
            this.genderRepository = genderRepository;
        }

        public IEnumerable<ProductModel> GetAll()
        {
            IEnumerable<Product> listOfProducts = repository.GetAllProducts();

            IEnumerable <ProductModel> mappedProducts = Mapper.Map<IEnumerable<ProductModel>>(listOfProducts);
            
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

            if (productModel.Brand != null && productModel.Brand.Length > 0)
            {
                var brand = brandRepository.GetBrandByName(productModel.Brand);
                if (brand!=null)
                {
                    mappedProduct.BrandID = brand.BrandID;
                }
            }
            if(productModel.Category != null && productModel.Category.Length > 0)
            {
                var categ = categoryRepository.GetCategoryByName(productModel.Category);
                if (categ != null)
                {
                    mappedProduct.CategoryID = categ.CategoryID;
                }
            }
            if(productModel.Color != null && productModel.Color.Length > 0)
            {
                var color = colorRepository.GetColorByName(productModel.Color);
                if (color != null)
                {
                    mappedProduct.ColorID = color.ColorID;
                }
            }
            if(productModel.Gender != null && productModel.Gender.Length > 0)
            {
                var gender = genderRepository.GetGenderByName(productModel.Gender);
                if (gender != null)
                {
                    mappedProduct.GenderID = gender.GenderID;
                }
            }
            repository.SaveProduct(mappedProduct);
        }

        public IEnumerable<ProductModel> SearchProduct(string searchString)
        {
            IEnumerable<Product> products = repository.GetAllProducts();
            IEnumerable<ProductModel> mappedProducts = Mapper.Map<IEnumerable<ProductModel>>(products);

            if (!String.IsNullOrEmpty(searchString))
            {
                mappedProducts = mappedProducts.Where(s => s.ProductName.Contains(searchString));
            }

            return mappedProducts;
        }

        private IEnumerable<ProductModel> FilterByCategory(Category category, IEnumerable<ProductModel> products)
        {
            return products.Where(p => p.Category == category.CategoryName);
        }

        private IEnumerable<ProductModel> FilterByBrand(Brand brand, IEnumerable<ProductModel> products)
        {
            return products.Where(p => p.Brand == brand.BrandName);
        }

        public IEnumerable<ProductModel> Filter(string[] category, string[] brand)
        {
            IEnumerable<Product> products = repository.GetAllProducts();
            IEnumerable<ProductModel> mappedProducts = Mapper.Map<IEnumerable<ProductModel>>(products);

            List<ProductModel> filteredByCateg= new List<ProductModel>();
            if (category != null)
            {
                foreach(string filter in category)
                {
                    var results = FilterByCategory(categoryRepository.GetCategoryByName(filter), mappedProducts);
                    filteredByCateg.AddRange(results);
                }
            }
            List<ProductModel> filteredByBrand= new List<ProductModel>();
            if (brand != null)
            {
                foreach (string filter in brand)
                {
                    var results = FilterByBrand(brandRepository.GetBrandByName(filter), mappedProducts);
                    filteredByBrand.AddRange(results);
                }
            }

            IEnumerable<ProductModel> filteredProducts = filteredByBrand.Intersect(filteredByCateg);
            
            return filteredProducts;
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
                filteredProducts= filteredProducts.Where(p => p.ProductName.Contains(searchString));
            }
            return filteredProducts;
        }
    }
}
