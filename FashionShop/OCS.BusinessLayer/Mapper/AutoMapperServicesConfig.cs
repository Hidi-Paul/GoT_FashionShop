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
                cfg.CreateMap<ProductModel, Product>()
                        .ForMember(prod => prod.ProductName, map => map.MapFrom(p => p.ProductName))
                        .ForMember(prod => prod.ProductPrice, map => map.MapFrom(p => p.ProductPrice))
                        .ForMember(prod => prod.Brand, map => map.Ignore())
                        .ForMember(prod => prod.Category, map => map.Ignore())
                        .ForMember(prod => prod.Color, map => map.Ignore())
                        .ForMember(prod => prod.Gender, map => map.Ignore());

                cfg.CreateMap<Product, ProductModel>()
                        .ForMember(prod => prod.ProductID, map => map.MapFrom(p => p.ProductID))
                        .ForMember(prod => prod.ProductName, map => map.MapFrom(p => p.ProductName))
                        .ForMember(prod => prod.ProductPrice, map => map.MapFrom(p => p.ProductPrice))
                        .ForMember(prod => prod.Gender, map => map.MapFrom(p =>p.Gender.GenderName))
                        .ForMember(prod => prod.Color, map => map.MapFrom(p => p.Color.ColorName))
                        .ForMember(prod => prod.Brand, map => map.MapFrom(p => p.Brand.BrandName))
                        .ForMember(prod => prod.Category, map => map.MapFrom(p => p.Category.CategoryName));                

            });

        }        
    }
}
