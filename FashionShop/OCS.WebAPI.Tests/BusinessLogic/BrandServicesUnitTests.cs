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
    public class BrandServicesUnitTests
    {
        //Declarations
        private BrandServices service;
        private Mock<IBrandRepository> repo;

        [SetUp]
        public void Init()
        {

            //All initializations
            AutoMapperServicesConfig.Configure();

            repo = new Mock<IBrandRepository>();

            service = new BrandServices(repo.Object);
        }

        [Test]
        public void GetAll_ReturnsListOfAllBrands()
        {
            //Arrange
            List<Brand> dtoList = new List<Brand>()
            {
                new Brand() {BrandName="BrandName1"},
                new Brand() {BrandName="BrandName2"},
                new Brand() {BrandName="BrandName3"},
                new Brand() {BrandName="BrandName4"},
                new Brand() {BrandName="BrandName5"}
            };

            repo.Setup(x => x.GetAllBrands())
                   .Returns(dtoList);
            //Act
            var result = service.GetAll();

            //Assert
            Assert.IsNotNull(result);
            repo.Verify(x => x.GetAllBrands(), Times.Once);
            Assert.IsTrue(dtoList.Count == result.Count());
            for (int i = 0; i < dtoList.Count; i++)
            {
                Assert.IsTrue(dtoList[i].BrandName == result.ElementAt(i).Name);
            }
        }
    }
}
