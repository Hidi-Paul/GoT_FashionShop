using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCS.MVC.Controllers
{
    [AccessDeniedAuthorize]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        //Post: Admin/Create
        public ActionResult Create()
        {
            return View();
        }
    }
}