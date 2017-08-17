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
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository repository;

        public CategoryServices(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<CategoryModel> GetAll()
        {
            IEnumerable<Category> listOfCategs = repository.GetAllCategories();
            IEnumerable<CategoryModel> mappedCategs = Mapper.Map<IEnumerable<CategoryModel>>(listOfCategs);

            return mappedCategs;
        }
    }
}
