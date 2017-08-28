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
    public class ShoppingCartController : ApiController
    {
        private readonly IShoppingCartServices services;

        public ShoppingCartController(IShoppingCartServices services)
        {
            this.services = services;
        }

        [HttpGet]
        [Route("GetShoppingCart")]
        public IHttpActionResult GetShoppingCart()
        {
            string user = RequestContext.Principal.Identity.Name;

            ShoppingCartModel model = services.GetShoppingCartByUser(user);

            if (model != null)
            {
                return this.Ok(model);
            }
            return this.InternalServerError(new Exception("Could not return shopping cart"));
        }

        [HttpPost]
        [Route("AddProductToShoppingCart")]
        public IHttpActionResult AddProductToShoppingCart(ShoppingCartItemModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid order");
            }

            string user = RequestContext.Principal.Identity.Name;

            try
            {
                services.AddProduct(model, user);

                ShoppingCartModel cart = services.GetShoppingCartByUser(user);

                return this.Ok(cart);
            }
            catch(Exception e)
            {
                return this.InternalServerError(e);
            }


        }

    }
}
