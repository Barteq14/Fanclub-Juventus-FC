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
    public class ForumCategoriesController : Controller
    {
        private FanclubContext db = new FanclubContext();

        // GET: ForumCategories
        public ActionResult Index()
        {
            
            return View(db.ForumCategories.ToList());
        }

        // GET: ForumCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumCategory forumCategory = db.ForumCategories.Find(id);
            if (forumCategory == null)
            {
                return HttpNotFound();
            }
            return View(forumCategory);
        }

        // GET: ForumCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ForumCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title")] ForumCategory forumCategory)
        {
            if (ModelState.IsValid)
            {
                db.ForumCategories.Add(forumCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(forumCategory);
        }

        // GET: ForumCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumCategory forumCategory = db.ForumCategories.Find(id);
            if (forumCategory == null)
            {
                return HttpNotFound();
            }
            return View(forumCategory);
        }

        // POST: ForumCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title")] ForumCategory forumCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forumCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(forumCategory);
        }

        // GET: ForumCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumCategory forumCategory = db.ForumCategories.Find(id);
            if (forumCategory == null)
            {
                return HttpNotFound();
            }
            return View(forumCategory);
        }

        // POST: ForumCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ForumCategory forumCategory = db.ForumCategories.Find(id);
            db.ForumCategories.Remove(forumCategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // TEMATY!!!!!!!!!
       
        public ActionResult Subject(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var s = db.ForumCategories.Find(id);
            ViewBag.CategoryTitle = s.Title;

            List<ForumSubject> forumSubjects = new List<ForumSubject>();


            var fs = db.ForumSubjects.Select(f => f).Where(f => f.ForumCategory.ID == id);
            ForumSubject fors = null;
            foreach (var item in fs)
            {
                fors = item;
                forumSubjects.Add(fors);
            }
            

            return View(forumSubjects);
        }


        //dodawanie tematow do kategorii
        //GET
        public ActionResult CreateSubject(int? id)
        {
            var fc = db.ForumCategories.Find(id);
            ViewBag.ForumCategoryID = fc.ID;


            return View();
        }//przekazuje do widoku id kategorii , teraz trzeba to wstawic do odpowiedniego pola w formularzu i przesłac postem :)

        //POST
        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSubject()
        {
            
            var id = Request.Form["Category"];
            int m = Int32.Parse(id);
            var t = Request.Form["Title"];

            ForumSubject fs = new ForumSubject { ForumCategoryID = m , Title = t };
            db.ForumSubjects.Add(fs);
            db.SaveChanges();
            
            return RedirectToAction("Index");
            //po kliknieciu na przycisk create zle przechodzi mi na widok mam blad 404 not found :/
        }

        //KOMENTARZE !!!!!!!!!!!!!!!!!!!!!!!!

        public ActionResult Comment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var f = db.ForumSubjects.Find(id);
            ViewBag.SubjectTitle = f.Title;
            ViewBag.SubjectID = f.ID;
           
            
           
           
            List <Comment> comments = new List<Comment>();


            var fs = db.Comment.Select(c => c).Where(c => c.ForumSubject.ID == id);
           
            Comment comm = null;
            foreach (var item in fs)
            {
                comm = item;
                comments.Add(comm);
               
            }


            return View(comments);
        }

        //dodawanie komentarzy do tematow
        //poprawic dodawanie komentarzy jeszcze!
        //GET
       /* public ActionResult CreateComment(int? id)
        {
            var fs = db.ForumSubjects.Find(id);
            ViewBag.ForumSubjectID = fs.ID;


            return View();
        }//przekazuje do widoku id kategorii , teraz trzeba to wstawic do odpowiedniego pola w formularzu i przesłac postem :)
        */
        //POST
        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult Comment()
        {
            //pobranie zalogownego uzytkownika
            var pf = db.Profiles.Select(u => u).Where(u => u.UserName == User.Identity.Name);
            Profile profile = null;


            foreach (var item in pf)
            {
                profile = item;
            }

           //trzeba jakos wyszukac id tematu i tyle 

            var id = Request.Form["Subject"];
            int m = int.Parse(id);
            var t = Request.Form["Content"];

            ViewBag.Err = "Musisz wpisać komentarz!";

          if(t.Equals(null))
            {
                return RedirectToAction("Index");
            }else
            {
                Comment cc = new Comment { Content = t, Profile = profile, ForumSubjectID = m, CommentDate = DateTime.Now };
                db.Comment.Add(cc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
       
        }
        public ActionResult DeleteComment(int? id)
        {
            Comment c = db.Comment.Find(id);

            db.Comment.Remove(c);
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

        //przy kazdej kategorii jest zakladka z tematami i jesli user w nia wejdzie to pojawiaja sie wsyzstkie tematy z tej kategorii , uzytkownik bedzie 
        //mogl dodac temat do tej kategorii , w tematach znow bedzie zakladka tylko teraz z komentarzami i tam tez wysiwetla sie te komentarze ktore sa powiazane
        //z danym tematem i jak user doda komentarz to wstawi sie on do odpowiedniego tematu
    }
}
