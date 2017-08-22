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

    [Authorize]
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
                return this.InternalServerError(e);
            }
        }

        [HttpGet]
        [Route("GetProductByID")]
        public IHttpActionResult GetProductById(Guid? id)
        {
            if (id == null)
            {
                return BadRequest("Please specify the product Id");
            }
            try
            {
                ProductModel product = this.productServices.GetByID((Guid)id);
                if (product != null)
                {
                    return this.Ok(product);
                }
                return this.NotFound();
            }
            catch (Exception e)
            {
                return this.InternalServerError(e);
            }
        }

        [HttpPost]
        [Route("PostProduct")]
        public IHttpActionResult PostProduct([FromBody] ProductModel product)
        {
            //!HERE!
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
                    return InternalServerError(e);
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
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [Route("Filter")]
        public IHttpActionResult Filter([FromUri]VM model)
        {
            try
            {
                IEnumerable<ProductModel> products = this.productServices.Filter(model.category, model.brand);
                return this.Ok(products);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        public class VM {
            public string[] category { get; set; }
            public string[] brand { get; set; }
        }

        [HttpGet]
        [Route("FilteredSearch")]
        public IHttpActionResult FilteredSearch(string searchString, [FromUri]VM model)
        {
            try
            {
                IEnumerable<ProductModel> products = this.productServices.FilteredSearch(searchString,model.category,model.brand);
                return this.Ok(products);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
