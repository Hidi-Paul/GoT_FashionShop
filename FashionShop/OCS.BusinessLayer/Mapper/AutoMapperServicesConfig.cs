using AutoMapper;
using OCS.BusinessLayer.Models;
using OCS.DataAccess;
using OCS.DataAccess.Repositories;

namespace OCS.BusinessLayer.Mapping
{
    public class AutoMapperServicesConfig
    {

        public static void Configure()
        {


            Mapper.Initialize(cfg =>
            {
                //v- THis is bad IK -v//
                cfg.CreateMap<ProductModel, Product>()
                        .ForMember(prod => prod.Brand, map => map.MapFrom(p => GetBrand(p.Brand, new BrandRepository())))
                        .ForMember(prod => prod.Gender, map => map.MapFrom(p => GetGender(p.Gender, new GenderRepository())))
                        .ForMember(prod => prod.Color, map => map.MapFrom(p => GetColor(p.Color, new ColorRepository())))
                        .ForMember(prod => prod.Category, map => map.MapFrom(p => GetCategory(p.Category, new CategoryRepository())));

                cfg.CreateMap<Product, ProductModel>()
                        .ForMember(prod => prod.Gender, map => map.MapFrom(p => p.Gender.GenderName))
                        .ForMember(prod => prod.Color, map => map.MapFrom(p => p.Color.ColorName))
                        .ForMember(prod => prod.Brand, map => map.MapFrom(p => p.Brand.BrandName))
                        .ForMember(prod => prod.Category, map => map.MapFrom(p => p.Category.CategoryName));                
                cfg.CreateMap<ProductModel, Product>();
            });
        }

        #region Helpers
        public static Gender GetGender(string name, IGenderRepository repo)
        {
            return repo.GetGenderByName(name);
        }
        public static Color GetColor(string name, IColorRepository repo)
        {
            return repo.GetColorByName(name);
        }
        public static Brand GetBrand(string name, IBrandRepository repo)
        {
            return repo.GetBrandByName(name);
        }
        public static Category GetCategory(string name, ICategoryRepository repo)
        {
            return repo.GetCategoryByName(name);
        }
        #endregion Helpers
    }
}
