using System;
using System.Collections.Generic;
using System.Web.Mvc;
using OCS.MVC.Models;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http;

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

            IEnumerable<ProductViewModel> products = await GetProducts();
            IEnumerable<CategoryViewModel> categories = await GetCategories();
            IEnumerable<BrandViewModel> brands = await GetBrands();

            var filtersViewModel = new FiltersViewModel()
            {
                SearchString = "",
                Categories = categories,
                Brands = brands
            };
            var productsPageViewModel = new ProductsPageViewModel()
            {
                FiltersViewModel = filtersViewModel,
                Products = products
            };

            return View(productsPageViewModel);
        }

        // GET: Filtered Results
        [HttpPost]
        public async Task<ActionResult> ProductListPartial(FiltersViewModel model)
        {
            var token = HttpContext.Request.Cookies["Token"].Value;
            HttpRequestHelper.SetAuthToken(token);



            HttpResponseMessage response = await HttpRequestHelper.GetAsync("GetAllProducts");

            List<ProductViewModel> products = new List<ProductViewModel>();
            if (response.IsSuccessStatusCode)
            {
                products = await response.Content.ReadAsAsync<List<ProductViewModel>>();
            }
            else
            {
                throw new ApplicationException(response.Content.ToString());
            }

            return PartialView("ProductListPartial", products);
        }
        
        // POST: Filters
        [HttpPost]
        public async Task<ActionResult> Filters(FiltersViewModel model)
        {
            var token = HttpContext.Request.Cookies["Token"].Value;
            HttpRequestHelper.SetAuthToken(token);


            HttpResponseMessage response = await HttpRequestHelper.GetAsync("GetAllProducts");

            List<ProductViewModel> products = new List<ProductViewModel>();
            if (response.IsSuccessStatusCode)
            {
                products = await response.Content.ReadAsAsync<List<ProductViewModel>>();
            }
            else
            {
                throw new ApplicationException(response.Content.ToString());
            }

            return View("Index", products);
        }

        #region HttpClientCallers
        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            HttpResponseMessage response = await HttpRequestHelper.GetAsync("GetAllProducts");
            List<ProductViewModel> products = new List<ProductViewModel>();
            if (response.IsSuccessStatusCode)
            {
                products = await response.Content.ReadAsAsync<List<ProductViewModel>>();
            }
            else
            {
                throw new ApplicationException(response.Content.ToString());
            }
            return products;
        }
        public async Task<IEnumerable<CategoryViewModel>> GetCategories()
        {
            HttpResponseMessage response = await HttpRequestHelper.GetAsync("GetAllCategories");
            List<CategoryViewModel> categories = new List<CategoryViewModel>();
            if (response.IsSuccessStatusCode)
            {
                categories = await response.Content.ReadAsAsync<List<CategoryViewModel>>();
            }
            else
            {
                throw new ApplicationException(response.Content.ToString());
            }
            return categories;
        }
        public async Task<IEnumerable<BrandViewModel>> GetBrands()
        {
            HttpResponseMessage response = await HttpRequestHelper.GetAsync("GetAllBrands");
            List<BrandViewModel> brands = new List<BrandViewModel>();
            if (response.IsSuccessStatusCode)
            {
                brands = await response.Content.ReadAsAsync<List<BrandViewModel>>();
            }
            else
            {
                throw new ApplicationException(response.Content.ToString());
            }
            return brands;
        }
        #endregion HttpClientCallers
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