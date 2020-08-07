using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FanclubJuventus.DAL;
using FanclubJuventus.Models;
using PagedList;

namespace FanclubJuventus.Controllers
{
    
    public class ProductsController : Controller
    {
        private FanclubContext db = new FanclubContext();

        //[Authorize]
        // GET: Products
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "Price_desc" : "Price";
            ViewBag.CategorySortParm = sortOrder == "Category_Name" ? "Category_Name_Desc" : "Category_Name";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var products = from p in db.Products
                           select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.Name.Contains(searchString)
                                       || p.Category.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    products = products.OrderByDescending(s => s.Name);
                    break;
                case "Category_Name":
                    products = products.OrderBy(s => s.Price);
                    break;
                case "Category_Name_Desc":
                    products = products.OrderByDescending(s => s.Price);
                    break;
                case "Price":
                    products = products.OrderBy(s => s.Price);
                    break;
                case "Price_desc":
                    products = products.OrderByDescending(s => s.Price);
                    break;
                default:
                    products = products.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(products.ToPagedList(pageNumber, pageSize));
        }

   

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }


        //[Authorize(Roles = "Admin")]
        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "ID", "Name");
            return View();
        }

        //[Authorize(Roles = "Admin")]
        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Price,Image,CategoryId")] Product product)
        {
            HttpPostedFileBase file = Request.Files["plikZObrazkiem"];
            if(file != null && file.ContentLength > 0)
            {
                product.Image = file.FileName;
                file.SaveAs(HttpContext.Server.MapPath("~/Images/") + product.Image);
            }
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            ViewBag.CategoryId = new SelectList(db.Categories, "ID", "Name", product.CategoryId);
            return View(product);
        }

        //[Authorize(Roles = "Admin")]
        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "ID", "Name", product.CategoryId);
            return View(product);
        }

        //[Authorize(Roles = "Admin")]
        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Price,Image,CategoryId")] Product product)
        {
            HttpPostedFileBase file = Request.Files["plikZObrazkiem"];
            string img = product.Image;
            if (file != null && file.ContentLength > 0)
            {
                product.Image = file.FileName;
                file.SaveAs(HttpContext.Server.MapPath("~/Images/") + product.Image);
            }
            else
            {
                product.Image = img;
            }
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }


           
            ViewBag.CategoryId = new SelectList(db.Categories, "ID", "Name", product.CategoryId);
            return View(product);
        }


        //[Authorize(Roles = "Admin")]
        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //[Authorize(Roles = "Admin")]
        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //metoda do pobrania wszystkich rozmiarow dla danego productu :)
        public ViewResult ChooseSize(int? id)
        {

            var pf = db.Profiles.Select(u => u).Where(u => u.UserName == User.Identity.Name);
            Profile profile = null;

            foreach (var item in pf)
            {
                profile = item;
            }

            ViewBag.E = "Please fill in your details";
            Product product = db.Products.Find(id);
            var ps = db.ProductSize.Select(l => l).Where(l => l.ProductID == id);
            List<ProductSize> productsSize = new List<ProductSize>();
            ProductSize psize = null;
            if (profile.PhoneNumber == null)
            {
                ViewBag.Error = "error";
            }
            else
            {
                ViewBag.Error = "good";
                foreach (var item in ps)
                {
                    psize = item;
                    productsSize.Add(psize);
                }

            }
            
            return View(productsSize);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

       
    }
}
