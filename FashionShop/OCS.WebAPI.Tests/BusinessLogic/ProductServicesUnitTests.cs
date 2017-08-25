using Moq;
using NUnit.Framework;
using OCS.BusinessLayer.Mapping;
using OCS.BusinessLayer.Services;
using OCS.DataAccess;
using OCS.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCS.DataAccess.Enums;
using OCS.BusinessLayer.Models;

namespace OCS.WebAPI.Tests.BusinessLogic
{
    [TestFixture]
    public class ProductServicesUnitTests
    {
        //Declarations
        private ProductServices service;
        private Mock<IProductRepository> repo;
        private Mock<IBrandRepository> brandRepo;
        private Mock<ICategoryRepository> categRepo;

        [SetUp]
        public void Init()
        {

            //All initializations
            AutoMapperServicesConfig.Configure();

            repo = new Mock<IProductRepository>();

            brandRepo = new Mock<IBrandRepository>();
            categRepo = new Mock<ICategoryRepository>();

            service = new ProductServices(repo.Object, brandRepo.Object, categRepo.Object);
        }

        [Test]
        public void GetByID_ReturnsCorrectProduct()
        {
            //Arrange 
            Product dto = GetProduct("Name", 1, "TestBrand", "TestCateg", Gender.Male);
            Guid id = dto.ProductID;
            ProductModel model = GetProductModel(dto);

            repo.Setup(x => x.GetProductById(id))
                   .Returns(dto);
            //Act
            var result = service.GetByID(id);

            //Assert

            repo.Verify(x => x.GetProductById(id), Times.Once);
            Assert.IsNotNull(result);
            Assert.IsTrue(AreEqual(model, result));
        }

        [Test]
        public void GetByID_ReturnsNullIfProductNotFound()
        {
            //Arrange 
            Guid id = new Guid();

            repo.Setup(x => x.GetProductById(id))
                   .Returns((Product)null);
            //Act
            var result = service.GetByID(id);

            //Assert

            repo.Verify(x => x.GetProductById(id), Times.Once);
            Assert.IsNull(result);
        }

        [Test]
        public void GetAll_ReturnsListOfAllProducts()
        {
            //Arrange
            List<Product> dtoList = new List<Product>()
            {
                GetProduct("Name1", 1, "TestBrand1", "TestCateg1", Gender.Male),
                GetProduct("Name2", 2, "TestBrand2", "TestCateg2", Gender.Male),
                GetProduct("Name3", 3, "TestBrand3", "TestCateg3", Gender.Female),
                GetProduct("Name4", 4, "TestBrand4", "TestCateg4", Gender.Female),
                GetProduct("Name5", 5, "TestBrand5", "TestCateg5", Gender.Unisex)
            };

            repo.Setup(x => x.GetAllProducts())
                   .Returns(dtoList);
            //Act
            var result = service.GetAll();

            //Assert
            Assert.IsNotNull(result);
            repo.Verify(x => x.GetAllProducts(), Times.Once);
            Assert.IsTrue(dtoList.Count == result.Count());
            for (int i = 0; i < dtoList.Count; i++)
            {
                Assert.IsTrue(AreEqual(GetProductModel(dtoList[i]), result.ElementAt(i)));
            }
        }

        [Test]
        public void AddProduct_CallsRepositoryToAddProduct()
        {
            //Arrange
            Product dto = GetProduct("Name1", 1, "TestBrand1", "TestCateg1", Gender.Male);
            ProductModel model = GetProductModel(dto);

            repo.Setup(x => x.SaveProduct(It.Is<Product>(prod => AreEqual(prod, dto))));
            categRepo.Setup(x => x.GetCategoryByName(model.Category)).Returns(dto.Category);
            brandRepo.Setup(x => x.GetBrandByName(model.Brand)).Returns(dto.Brand);

            //Act
            service.AddProduct(model);

            //Assert
            repo.Verify(x => x.SaveProduct(It.IsAny<Product>()), Times.Once);
        }

        [Test]
        public void AddProduct_IncludesCategoriesRelationships()
        {
            //Arrange
            Guid categID = new Guid();

            Product dto = GetProduct("Name1", 1, "TestBrand1", "TestCateg1", Gender.Male);
            ProductModel model = GetProductModel(dto);
            Category categ = new Category { CategoryID = categID, CategoryName = model.Category };

            categRepo.Setup(x => x.GetCategoryByName(model.Category)).Returns(categ);
            repo.Setup(x => x.SaveProduct(It.Is<Product>(prod => prod.Category.CategoryID == categ.CategoryID)));

            //Act
            service.AddProduct(model);

            //Assert
            categRepo.Verify(x => x.GetCategoryByName(categ.CategoryName), Times.Once);
            repo.Verify(x => x.SaveProduct(It.IsAny<Product>()), Times.Once);
        }
        [Test]
        public void AddProduct_IncludesBrandRelationships()
        {
            //Arrange
            Guid brandID = new Guid();

            Product dto = GetProduct("Name1", 1, "TestBrand1", "TestCateg1", Gender.Male);
            ProductModel model = GetProductModel(dto);
            Brand brand = new Brand { BrandID = brandID, BrandName = model.Brand };

            brandRepo.Setup(x => x.GetBrandByName(model.Brand)).Returns(brand);
            repo.Setup(x => x.SaveProduct(It.Is<Product>(prod => prod.Brand.BrandID == brand.BrandID)));

            //Act
            service.AddProduct(model);

            //Assert
            brandRepo.Verify(x => x.GetBrandByName(brand.BrandName), Times.Once);
            repo.Verify(x => x.SaveProduct(It.IsAny<Product>()), Times.Once);
        }

        
        [Test]
        public void FilteredSearch_ReturnsValidResuls()
        {
            //Arrange
            string searchText = "this";
            List<CategoryModel> categs = new List<CategoryModel>()
            {
                new CategoryModel(){Name="GoodCateg1" },
                new CategoryModel(){Name="GoodCateg2" }
            };
            List<BrandModel> brands = new List<BrandModel>()
            {
                new BrandModel(){Name="GoodBrand1" },
                new BrandModel(){Name="GoodBrand2"},
                new BrandModel(){Name="GoodBrand3"}
            };

            List<Product> prods = new List<Product>()
            {
                GetProduct("this2", 2, "TestBrand2", "GoodCateg2", Gender.Male),
                GetProduct("this1", 1, "GoodBrand1", "GoodCateg1", Gender.Male),    //Valid
                GetProduct("Name3", 3, "GoodBrand3", "GoodCateg2", Gender.Female),
                GetProduct("this4", 4, "GoodBrand2", "TestCateg4", Gender.Female),
                GetProduct("Name5", 5, "TestBrand5", "TestCateg5", Gender.Unisex),
                GetProduct("3this", 5, "GoodBrand2", "GoodCateg2", Gender.Unisex)   //Valid
            };
            repo.Setup(x => x.GetAllProducts()).Returns(prods);
            foreach (CategoryModel filter in categs)
            {
                categRepo.Setup(x => x.GetCategoryByName(filter.Name)).Returns(new Category() { CategoryName = filter.Name });
            }
            foreach (BrandModel filter in brands)
            {
                brandRepo.Setup(x => x.GetBrandByName(filter.Name)).Returns(new Brand() { BrandName = filter.Name });
            }

            //Act
            var result = service.FilteredSearch(searchText, categs, brands).ToList();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
            Assert.IsTrue(result.Count() == 2);
            Assert.IsTrue(AreEqual(result.ElementAt(0), GetProductModel(prods[1])));
            Assert.IsTrue(AreEqual(result.ElementAt(1), GetProductModel(prods[5])));
        }

        #region helpers
        private static Product GetProduct(string productName,
                                          int productPrice,
                                          string brandName,
                                          string categName,
                                          Gender gender,
                                          Guid id = new Guid())
        {
            Product dto = new Product
            {
                ProductID = id,
                ProductPrice = productPrice,
                ProductName = productName,
                Brand = new Brand() { BrandName = brandName },
                Category = new Category() { CategoryName = categName },
                Gender = gender,
                Image = "http://qwe.asd.com/zxc.jpg"
            };

            return dto;
        }
        private static ProductModel GetProductModel(Product prod)
        {
            ProductModel model = new ProductModel
            {
                ProductID = prod.ProductID,
                ProductName = prod.ProductName,
                ProductPrice = prod.ProductPrice,
                Brand = prod.Brand.BrandName,
                Category = prod.Category.CategoryName,
                Gender = prod.Gender.ToString(),
                Image = prod.Image
            };
            return model;
        }
        private static bool AreEqual(ProductModel model, ProductModel resultModel)
        {
            return model.ProductID == resultModel.ProductID &&
                   model.ProductName == resultModel.ProductName &&
                   model.ProductPrice == resultModel.ProductPrice &&
                   model.Gender == resultModel.Gender &&
                   model.Brand == resultModel.Brand &&
                   model.Category == resultModel.Category &&
                   model.Image == resultModel.Image;
        }
        private static bool AreEqual(Product model, Product resultModel)
        {
            return model.ProductName == resultModel.ProductName &&
                   model.ProductPrice == resultModel.ProductPrice &&
                   model.Gender == resultModel.Gender &&
                   model.Brand.BrandName == resultModel.Brand.BrandName &&
                   model.Category.CategoryName == resultModel.Category.CategoryName &&
                   model.Image == resultModel.Image;
        }

        #endregion helpers
    }
}
