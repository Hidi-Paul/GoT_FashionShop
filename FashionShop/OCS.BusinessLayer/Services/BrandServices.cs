using AutoMapper;
using OCS.BusinessLayer.Models;
using OCS.DataAccess;
using OCS.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
