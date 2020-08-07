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
    public class PostsController : Controller
    {
        private FanclubContext db = new FanclubContext();

        // GET: Posts
        public ActionResult Index()
        {
            return View(db.Posts.ToList());
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            ViewBag.postDate = DateTime.Now;
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult Create2(Post post)
        {
            //odbieranie daty
             var date = Request.Form["PostDate"];
            DateTime date2 = DateTime.Parse(date);

            var h = Request.Form["Header"];
            var c = Request.Form["Content"];
            var t = Request.Form["Title"];

            HttpPostedFileBase file = Request.Files["plikZObrazkiem"];
            if (file != null && file.ContentLength > 0)
            {
                post.Image = file.FileName;
                file.SaveAs(HttpContext.Server.MapPath("~/Images/") + post.Image);
            }

            post = new Post { Title = t ,Header = h, Content = c , Image = post.Image ,PostDate = date2 };
            db.Posts.Add(post);
            db.SaveChanges();

            return RedirectToAction("Index");

            
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Header,Content,Image,PostDate")] Post post)
        {
            HttpPostedFileBase file = Request.Files["plikZObrazkiem"];
            string img = post.Image;
            if (file != null && file.ContentLength > 0)
            {
                post.Image = file.FileName;
                file.SaveAs(HttpContext.Server.MapPath("~/Images/") + post.Image);
            }
            else
            {
                post.Image = img;
            }
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
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
