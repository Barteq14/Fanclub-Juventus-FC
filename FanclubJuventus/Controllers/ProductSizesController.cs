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

namespace FanclubJuventus.Controllers
{
    public class ProductSizesController : Controller
    {
        private FanclubContext db = new FanclubContext();

        // GET: ProductSizes
        public ActionResult Index()
        {
            var productSize = db.ProductSize.Include(p => p.product).Include(p => p.size);
            return View(productSize.ToList());
        }

        // GET: ProductSizes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSize productSize = db.ProductSize.Find(id);
            if (productSize == null)
            {
                return HttpNotFound();
            }
            return View(productSize);
        }

        // GET: ProductSizes/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name");
            ViewBag.SizeID = new SelectList(db.Size, "ID", "SizeOfProduct");
            return View();
        }

        // POST: ProductSizes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProductID,SizeID")] ProductSize productSize)
        {
            if (ModelState.IsValid)
            {
                db.ProductSize.Add(productSize);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name", productSize.ProductID);
            ViewBag.SizeID = new SelectList(db.Size, "ID", "SizeOfProduct", productSize.SizeID);
            return View(productSize);
        }

        // GET: ProductSizes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSize productSize = db.ProductSize.Find(id);
            if (productSize == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name", productSize.ProductID);
            ViewBag.SizeID = new SelectList(db.Size, "ID", "SizeOfProduct", productSize.SizeID);
            return View(productSize);
        }

        // POST: ProductSizes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProductID,SizeID")] ProductSize productSize)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productSize).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name", productSize.ProductID);
            ViewBag.SizeID = new SelectList(db.Size, "ID", "SizeOfProduct", productSize.SizeID);
            return View(productSize);
        }

        // GET: ProductSizes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSize productSize = db.ProductSize.Find(id);
            if (productSize == null)
            {
                return HttpNotFound();
            }
            return View(productSize);
        }

        // POST: ProductSizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductSize productSize = db.ProductSize.Find(id);
            db.ProductSize.Remove(productSize);
            db.SaveChanges();
            return RedirectToAction("Index");
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
