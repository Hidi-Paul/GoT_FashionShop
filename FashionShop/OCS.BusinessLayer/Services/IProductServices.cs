using OCS.BusinessLayer.Models;
using OCS.DataAccess;
using System;
using System.Collections.Generic;

namespace OCS.BusinessLayer.Services
{
    public interface IProductServices
    {
        IEnumerable<ProductModel> GetAll();

        ProductModel GetByID(Guid id);

        void AddProduct(ProductModel productModel);

        IEnumerable<ProductModel> SearchProduct(string searchString);

        IEnumerable<ProductModel> Filter(string[] category, string[] brand);

        IEnumerable<ProductModel> FilteredSearch(string searchString, string[] category = null, string[] brand = null);


    }
}