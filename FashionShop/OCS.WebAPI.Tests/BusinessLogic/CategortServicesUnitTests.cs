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
    public class CategortServicesUnitTests
    {
        //Declarations
        private CategoryServices service;
        private Mock<ICategoryRepository> repo;

        [SetUp]
        public void Init()
        {

            //All initializations
            AutoMapperServicesConfig.Configure();

            repo = new Mock<ICategoryRepository>();

            service = new CategoryServices(repo.Object);
        }

        [Test]
        public void GetAll_ReturnsListOfAllCategories()
        {
            //Arrange
            List<Category> dtoList = new List<Category>()
            {
                new Category() {CategoryName="CategName1"},
                new Category() {CategoryName="CategName2"},
                new Category() {CategoryName="CategName3"},
                new Category() {CategoryName="CategName4"},
                new Category() {CategoryName="CategName5"}
            };

            repo.Setup(x => x.GetAllCategories())
                   .Returns(dtoList);
            //Act
            var result = service.GetAll();

            //Assert
            Assert.IsNotNull(result);
            repo.Verify(x => x.GetAllCategories(), Times.Once);
            Assert.IsTrue(dtoList.Count == result.Count());
            for (int i = 0; i < dtoList.Count; i++)
            {
                Assert.IsTrue(dtoList[i].CategoryName==result.ElementAt(i).Name);
            }
        }
    }
}
