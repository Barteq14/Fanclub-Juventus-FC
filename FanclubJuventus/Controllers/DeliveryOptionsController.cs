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
    public class DeliveryOptionsController : Controller
    {
        private FanclubContext db = new FanclubContext();

        // GET: DeliveryOptions
        public ActionResult Index()
        {
            var deliveryOption = db.DeliveryOption.Include(d => d.KindOfDelivery);
            return View(deliveryOption.ToList());
        }

        // GET: DeliveryOptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryOption deliveryOption = db.DeliveryOption.Find(id);
            if (deliveryOption == null)
            {
                return HttpNotFound();
            }
            return View(deliveryOption);
        }

        // GET: DeliveryOptions/Create
        public ActionResult Create()
        {
            ViewBag.KindOfDeliveryID = new SelectList(db.KindOfDelivery, "ID", "Name");
            return View();
        }

        // POST: DeliveryOptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Image,KindOfDeliveryID")] DeliveryOption deliveryOption)
        {
            HttpPostedFileBase file = Request.Files["plikZObrazkiem"];
            if (file != null && file.ContentLength > 0)
            {
                deliveryOption.Image = file.FileName;
                file.SaveAs(HttpContext.Server.MapPath("~/Images/") + deliveryOption.Image);
            }
            if (ModelState.IsValid)
            {
                db.DeliveryOption.Add(deliveryOption);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KindOfDeliveryID = new SelectList(db.KindOfDelivery, "ID", "Name", deliveryOption.KindOfDeliveryID);
            return View(deliveryOption);
        }

        // GET: DeliveryOptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryOption deliveryOption = db.DeliveryOption.Find(id);
            if (deliveryOption == null)
            {
                return HttpNotFound();
            }
            ViewBag.KindOfDeliveryID = new SelectList(db.KindOfDelivery, "ID", "Name", deliveryOption.KindOfDeliveryID);
            return View(deliveryOption);
        }

        // POST: DeliveryOptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Image,KindOfDeliveryID")] DeliveryOption deliveryOption)
        {

            HttpPostedFileBase file = Request.Files["plikZObrazkiem"];
            string img = deliveryOption.Image;
            if (file != null && file.ContentLength > 0)
            {
                deliveryOption.Image = file.FileName;
                file.SaveAs(HttpContext.Server.MapPath("~/Images/") + deliveryOption.Image);
            }
            else
            {
                deliveryOption.Image = img;
            }
            if (ModelState.IsValid)
            {
                db.Entry(deliveryOption).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KindOfDeliveryID = new SelectList(db.KindOfDelivery, "ID", "Name", deliveryOption.KindOfDeliveryID);
            return View(deliveryOption);
        }

        // GET: DeliveryOptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryOption deliveryOption = db.DeliveryOption.Find(id);
            if (deliveryOption == null)
            {
                return HttpNotFound();
            }
            return View(deliveryOption);
        }

        // POST: DeliveryOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeliveryOption deliveryOption = db.DeliveryOption.Find(id);
            db.DeliveryOption.Remove(deliveryOption);
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
