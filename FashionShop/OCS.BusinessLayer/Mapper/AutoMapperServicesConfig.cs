using AutoMapper;
using OCS.BusinessLayer.Models;
using OCS.DataAccess;
using OCS.DataAccess.Repositories;
using System;

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
                        .ForMember(prod => prod.Image, map => map.MapFrom(p => p.Image));

                cfg.CreateMap<Product, ProductModel>()
                        .ForMember(prod => prod.ProductID, map => map.MapFrom(p => p.ProductID))
                        .ForMember(prod => prod.ProductName, map => map.MapFrom(p => p.ProductName))
                        .ForMember(prod => prod.ProductPrice, map => map.MapFrom(p => p.ProductPrice))
                        .ForMember(prod => prod.Brand, map => map.MapFrom(p => p.Brand.BrandName))
                        .ForMember(prod => prod.Category, map => map.MapFrom(p => p.Category.CategoryName))
                        .ForMember(prod => prod.Image, map=>map.MapFrom(p=> p.Image));
                cfg.CreateMap<Category, CategoryModel>()
                        .ForMember(cat => cat.Name, map => map.MapFrom(p => p.CategoryName));
                cfg.CreateMap<Brand, BrandModel>()
                        .ForMember(bran => bran.Name, map => map.MapFrom(p => p.BrandName));
            });

        }        
    }
}
