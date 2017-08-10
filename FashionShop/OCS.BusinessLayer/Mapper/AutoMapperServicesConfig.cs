using AutoMapper;
using OCS.BusinessLayer.Models;
using OCS.DataAccess;

namespace OCS.BusinessLayer.Mapping
{
    public class AutoMapperServicesConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Product, ProductModel>()
                        .ForMember(prod => prod.Gender, map => map.MapFrom(p => p.Gender.GenderName))
                        .ForMember(prod => prod.Color, map => map.MapFrom(p => p.Color.ColorName))
                        .ForMember(prod => prod.Brand, map => map.MapFrom(p => p.Brand.BrandName))
                        .ForMember(prod => prod.Category, map => map.MapFrom(p => p.Category.CategoryName));                
                cfg.CreateMap<ProductModel, Product>();
            });
        }
    }
}
