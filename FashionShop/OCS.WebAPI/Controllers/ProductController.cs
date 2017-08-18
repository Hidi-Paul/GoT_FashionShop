using OCS.BusinessLayer.Models;
using OCS.BusinessLayer.Services;
using OCS.DataAccess;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web;
using System.Web.Http.Cors;

namespace OCS.WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    [System.Web.Mvc.RequireHttps]
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
        [Route("GetAllProducts")]
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
        [Route("GetProductByID")]
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
        [Route("PostProduct")]
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

        [HttpGet]
        [Route("Search")]
        public IHttpActionResult Search(string searchString)
        {
            try
            {
                IEnumerable<ProductModel> products = this.productServices.SearchProduct(searchString);
                return this.Ok(products);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("Filter")]
        public IHttpActionResult Filter(List<Category> category = null, List<Brand> brand = null)
        {
            try
            {
                IEnumerable<ProductModel> products = this.productServices.Filter(category, brand);
                return this.Ok(products);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("FilteredSearch")]
        public IHttpActionResult FilteredSearch(string searchString, List<Category> category = null, List<Brand> brand = null)
        {
            try
            {
                IEnumerable<ProductModel> products = this.productServices.FilteredSearch(searchString,category,brand);
                return this.Ok(products);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }
    }
}
