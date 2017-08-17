using AutoMapper;
using OCS.BusinessLayer.Models;
using OCS.DataAccess;
using OCS.DataAccess.Repositories;
using System.Collections.Generic;

namespace OCS.BusinessLayer.Services
{
    public class BrandServices : IBrandServices
    {
        private readonly IBrandRepository repository;

        public BrandServices(IBrandRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<BrandModel> GetAll()
        {
            IEnumerable<Brand> listOfBrands = repository.GetAllBrands();
            IEnumerable<BrandModel> mappedBrands = Mapper.Map<IEnumerable<BrandModel>>(listOfBrands);

            return mappedBrands;
        }
    }
}
