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
    public class ColorServices : IColorServices
    {
        private readonly IColorRepository repository;

        public ColorServices(IColorRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<ColorModel> GetAll()
        {
            IEnumerable<Color> listOfColors = repository.GetAllColors();
            IEnumerable<ColorModel> mappedColors = Mapper.Map<IEnumerable<ColorModel>>(listOfColors);
            return mappedColors;
        }
    }
}
