using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OCS.MVC.Models;
using Microsoft.AspNet.Identity;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace OCS.MVC.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
       // GET: Product
        public async Task<ActionResult> Index()
        {
            var token = HttpContext.Request.Cookies["Token"].Value;
            
            HttpRequestHelper.SetAuthToken(token);
            var response = await HttpRequestHelper.GetAsync("GetAllProducts");

            List<ProductModel> products = new List<ProductModel>();
            if (response.IsSuccessStatusCode)
            {
                products = await response.Content.ReadAsAsync<List<ProductModel>>();
            }
            else
            {
                throw new ApplicationException(response.Content.ToString());
            }
            
            return View(products);
        }

        //// GET: Product/Details/5
        //public ActionResult Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ProductModel productModel = db.ProductModels.Find(id);
        //    if (productModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(productModel);
        //}

        //// GET: Product/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Product/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ProductID,ProductName,ProductPrice,Gender,Color,Brand,Category")] ProductModel productModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        productModel.ProductID = Guid.NewGuid();
        //        db.ProductModels.Add(productModel);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(productModel);
        //}

        //// GET: Product/Edit/5
        //public ActionResult Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ProductModel productModel = db.ProductModels.Find(id);
        //    if (productModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(productModel);
        //}

        //// POST: Product/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ProductID,ProductName,ProductPrice,Gender,Color,Brand,Category")] ProductModel productModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(productModel).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(productModel);
        //}

        //// GET: Product/Delete/5
        //public ActionResult Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ProductModel productModel = db.ProductModels.Find(id);
        //    if (productModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(productModel);
        //}

        //// POST: Product/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(Guid id)
        //{
        //    ProductModel productModel = db.ProductModels.Find(id);
        //    db.ProductModels.Remove(productModel);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}