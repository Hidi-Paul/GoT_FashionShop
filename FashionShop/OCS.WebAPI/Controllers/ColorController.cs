using OCS.BusinessLayer.Models;
using OCS.BusinessLayer.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace OCS.WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    [System.Web.Mvc.RequireHttps]
    public class ColorController : ApiController
    {
        private readonly IColorServices colorServices;

        public ColorController(IColorServices colorServices)
        {
            this.colorServices = colorServices;
        }

        [HttpGet]
        [Route("GetAllBrands")]
        public IHttpActionResult GetAllColors()
        {
            try
            {
                IEnumerable<ColorModel> colors = this.colorServices.GetAll();
                return this.Ok(colors);
            }
            catch (Exception e)
            {
                return this.InternalServerError();
            }
        }
    }
}
