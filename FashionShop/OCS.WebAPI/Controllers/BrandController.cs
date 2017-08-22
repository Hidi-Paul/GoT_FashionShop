using OCS.BusinessLayer.Models;
using OCS.BusinessLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace OCS.WebAPI.Controllers
{
    [Authorize]
    [EnableCors("*", "*", "*")]
    [System.Web.Mvc.RequireHttps]
    public class BrandController : ApiController
    {
        private readonly IBrandServices brandServices;

        public BrandController(IBrandServices brandServices)
        {
            this.brandServices = brandServices;
        }

        [HttpGet]
        [Route("GetAllBrands")]
        public IHttpActionResult GetAllBrands()
        {
            try
            {
                IEnumerable<BrandModel> brands = this.brandServices.GetAll();
                return this.Ok(brands);
            }
            catch (Exception e)
            {
                return this.InternalServerError(e);
            }
        }
    }
}
