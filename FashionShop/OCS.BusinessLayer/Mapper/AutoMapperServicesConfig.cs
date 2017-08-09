using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace OCS.BusinessLayer.Mapping
{
    public class AutoMapperServicesConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                //cfg.CreateMap<Product,ProductModel>(); 
                //cfg.CreateMap<ProductModel,Product>();


            });
        }
    }
}
