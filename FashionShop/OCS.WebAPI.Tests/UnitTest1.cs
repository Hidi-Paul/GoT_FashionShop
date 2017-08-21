using System;
using NUnit;
using NUnit.Framework;
using OCS.BusinessLayer;
using OCS.BusinessLayer.Services;
using OCS.DataAccess.Repositories;
using Moq;
using OCS.BusinessLayer.Models;
using OCS.DataAccess;
using OCS.BusinessLayer.Mapping;

namespace OCS.WebAPI.Tests
{
    [TestFixture]
    public class Test_ClassName                             //LIke Test_ProductServices
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
            AutoMapperServicesConfig.Configure();           //productservices needs automapper to be configured

            repo = new Mock<IProductRepository>();          //ProductServices uses an injected repository, we'll create a mock for it

            brandRepo = new Mock<IBrandRepository>();
            categRepo = new Mock<ICategoryRepository>();

            service = new ProductServices(repo.Object,brandRepo.Object,categRepo.Object);     //We give it the "mocked objects", unity wont inject a repository cuz we'll give it instead
        }

        [Test]
        public void MethodName_Does_What_It_Says()          //GetByID_Returns_Product_From_Repository   --- YES TEST NAMES ARE LIKE THIS XD
        {
            //Arrange                                       //Setup any variables we need 
            Guid id = new Guid();
            Product dto = new Product
            {
                ProductID = id
            };
            ProductModel model = new ProductModel
            {
                ProductID = id
            };


            repo.Setup(x => x.GetProductById(id))           //Mocks are blank, we can add behavior
                   .Returns(dto);                           // "When we call the "GetProductById" with EXACTLY this "id", it returns "dto"
            //Act
            var result = service.GetByID(id);   //actual execution of the test

            //Assert

                //check if it called repo to get product (calls exactly once)
            repo.Verify(x => x.GetProductById(id), Times.Once);
                //check if it returned null
            Assert.IsNotNull(result);
                //check if result is valid
            Assert.AreEqual(result.ProductID, model.ProductID);
        }
    }
}
