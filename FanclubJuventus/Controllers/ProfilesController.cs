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
    public class ProfilesController : Controller
    {
        private FanclubContext db = new FanclubContext();

        // GET: Profiles
       
        public ActionResult Index()
        {
            //pobranie zalogowanego usera
             List<Profile> listOfUsers = new List<Profile>();
            var pf = db.Profiles.Select(u => u).Where(u => u.UserName == User.Identity.Name);
            Profile profile = null;

            foreach (var item in pf)
            {
                profile = item;
                // dodac do listy userow 
                listOfUsers.Add(profile);
            }

            return View(listOfUsers);
        }

        // GET: Profiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // GET: Profiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserName,FirstName,SurName,City,Street,Number")] Profile profile)
        {
            HttpPostedFileBase file = Request.Files["plikZObrazkiem"];
            if (file != null && file.ContentLength > 0)
            {
                profile.Image = file.FileName;
                file.SaveAs(HttpContext.Server.MapPath("~/Images/") + profile.Image);
            }
            if (ModelState.IsValid)
            {
                db.Profiles.Add(profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profile);
        }

        // GET: Profiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserName,FirstName,SurName,City,Street,Number,PhoneNumber,Image")] Profile profile)
        {

            HttpPostedFileBase file = Request.Files["plikZObrazkiem"];
            string img = profile.Image;
            if (file != null && file.ContentLength > 0)
            {
                profile.Image = file.FileName;
                file.SaveAs(HttpContext.Server.MapPath("~/Images/") + profile.Image);
            }
            else
            {
                profile.Image = img;
            }
            if (ModelState.IsValid)
            {
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profile);
        }

        // GET: Profiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profile profile = db.Profiles.Find(id);
            db.Profiles.Remove(profile);
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
