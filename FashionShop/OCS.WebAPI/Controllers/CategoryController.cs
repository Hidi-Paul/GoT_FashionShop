using OCS.BusinessLayer.Models;
using OCS.BusinessLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace OCS.WebAPI.Controllers
{
    [Authorize]
    [EnableCors("*", "*", "*")]
    [System.Web.Mvc.RequireHttps]
    public class CategoryController : ApiController
    {
        private readonly ICategoryServices categServices;

        public CategoryController(ICategoryServices categServices)
        {
            this.categServices = categServices;
        }

        [HttpGet]
        [Route("GetAllCategories")]
        public IHttpActionResult GetAllCategories()
        {
            try
            {
                IEnumerable<CategoryModel> categs = this.categServices.GetAll();
                return this.Ok(categs);
            }
            catch (Exception e)
            {
                return this.InternalServerError(e);
            }
        }
    }
}