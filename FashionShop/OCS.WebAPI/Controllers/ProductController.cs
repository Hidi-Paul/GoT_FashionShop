using OCS.BusinessLayer.Models;
using OCS.BusinessLayer.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace OCS.WebAPI.Controllers
{
    public class ProductController : ApiController
    {
        public ProductController() : base()
        { }

        private readonly IProductServices productServices;

        public ProductController(IProductServices productServices)
        {
            this.productServices = productServices;
        }

        [HttpGet]
        public IHttpActionResult GetAllProducts()
        {
            try
            {
                IEnumerable<ProductModel> products = this.productServices.GetAll();
                return this.Ok(products);
            }
            catch (Exception e)
            {
                return this.InternalServerError();
            }
        }

        [HttpGet]
        public IHttpActionResult GetProductById(Guid id)
        {
            try
            {
                ProductModel product = this.productServices.GetByID(id);
                return this.Ok(product);
            }
            catch (Exception e)
            {
                return this.InternalServerError();
            }
        }

        [HttpPost]
        public IHttpActionResult PostProduct([FromBody] ProductModel product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            else
            {
                try
                {
                    productServices.AddProduct(product);
                    return Created(Request.RequestUri + $"/{product.ProductID}", product);
                }
                catch (Exception e)
                {
                    return InternalServerError();
                }
            }
        }

    }
}
