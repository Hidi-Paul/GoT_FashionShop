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
                        .ForMember(prod => prod.Gender, map => map.MapFrom(p => p.Gender.GenderName))
                        .ForMember(prod => prod.Color, map => map.MapFrom(p => p.Color.ColorName))
                        .ForMember(prod => prod.Brand, map => map.MapFrom(p => p.Brand.BrandName))
                        .ForMember(prod => prod.Category, map => map.MapFrom(p => p.Category.CategoryName));

                cfg.CreateMap<Category, CategoryModel>()
                        .ForMember(cat => cat.Name, map => map.MapFrom(p => p.CategoryName));

                cfg.CreateMap<Brand, BrandModel>()
                        .ForMember(bran => bran.Name, map => map.MapFrom(p => p.BrandName));

                cfg.CreateMap<Color, ColorModel>()
                        .ForMember(col => col.Name, map => map.MapFrom(p => p.ColorName));
            });

        }
    }
}
