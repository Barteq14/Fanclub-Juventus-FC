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
using System.IO;
using System.Diagnostics;

namespace FanclubJuventus.Controllers
{
    public class MatchesController : Controller
    {
        private FanclubContext db = new FanclubContext();

        // GET: Matches
        public ActionResult Index()
        {
            var matches = db.Matches.Include(m => m.club).Include(m => m.club2);
            return View(matches.ToList());
        }

        // GET: Matches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        // GET: Matches/Create
        public ActionResult Create()
        {
            ViewBag.ClubID = new SelectList(db.Clubs, "ID", "Name");
            ViewBag.Club2ID = new SelectList(db.Clubs, "ID", "Name");
            return View();
        }

        // POST: Matches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClubID,Club2ID,Result1,Result2,Status,MatchDate,Image1,Image2")] Match match)
        {
            HttpPostedFileBase file = Request.Files["plikZObrazkiem"];
            if (file != null && file.ContentLength > 0)
            {
                match.Image1 = file.FileName;
                file.SaveAs(HttpContext.Server.MapPath("~/Images/") + match.Image1);
                match.Image2 = file.FileName;
                file.SaveAs(HttpContext.Server.MapPath("~/Images/") + match.Image2);
            }
            if (ModelState.IsValid)
            {
                db.Matches.Add(match);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClubID = new SelectList(db.Clubs, "ID", "Name", match.ClubID);
            ViewBag.Club2ID = new SelectList(db.Clubs, "ID", "Name", match.Club2ID);
            return View(match);
        }

        // GET: Matches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            string Image1 = match.Image1;
            string Image2 = match.Image2;
            if (match == null)
            {
                return HttpNotFound();
            }
            
            
            ViewBag.ClubID = new SelectList(db.Clubs, "ID", "Name", match.ClubID);
            ViewBag.Club2ID = new SelectList(db.Clubs, "ID", "Name", match.Club2ID);
            return View(match);
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClubID,Club2ID,Result1,Result2,Status,MatchDate,Image1,Image2")] Match match)
        {
            HttpPostedFileBase file = Request.Files["plikZObrazkiem"];
            if (file != null && file.ContentLength > 0)
            {
                match.Image1 = file.FileName;
                file.SaveAs(HttpContext.Server.MapPath("~/Images/") + match.Image1);
                match.Image2 = file.FileName;
                file.SaveAs(HttpContext.Server.MapPath("~/Images/") + match.Image2);
            }
           
            if (ModelState.IsValid)
            {
                db.Entry(match).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClubID = new SelectList(db.Clubs, "ID", "Name", match.ClubID);
            ViewBag.Club2ID = new SelectList(db.Clubs, "ID", "Name", match.Club2ID);
            return View(match);
        }

        // GET: Matches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Match match = db.Matches.Find(id);
            db.Matches.Remove(match);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult Bet(int? id)
        {
            List<Betting> b = new List<Betting>();
            //wyszukanie meczu o danym id 

            var ma = db.Betting.Select(m => m).Where(m => m.MatchID == id);
            
            Match match = db.Matches.Find(id);
            ViewBag.MatchID = match.Id;

            ViewBag.Club1 = match.club.Name;
            ViewBag.Club2 = match.club2.Name;

            return View();
        }


        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult Bet()
        {
            //wyszukanie usera
            var profile = db.Profiles.Select(p => p).Where(p => p.UserName == User.Identity.Name);
            Profile prof = null;

            foreach (var item in profile)
            {
                prof = item;
            }

            //odebranie z formularza wyniku i id meczu
            var matchID = Request.Form["id"];
            int id = Int32.Parse(matchID);

            var result1 = Request.Form["Result1"];
            int r1 = Int32.Parse(result1);
            var result2 = Request.Form["Result2"];
            int r2 = Int32.Parse(result2);

            //dodanie do tabeli betting i do listy 
            Betting bet = new Betting { Profile = prof, MatchID = id, Result1 = r1, Result2 = r2 };
            db.Betting.Add(bet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ViewResult LookBet()
        {
            List<Betting> bets = new List<Betting>();
            //wyszukanie usera
            var profile = db.Profiles.Select(p => p).Where(p => p.UserName == User.Identity.Name);
            Profile prof = null;

            foreach (var item in profile)
            {
                prof = item;
            }
            var query = db.Betting.Select(q => q).Where(q => q.Profile.UserName == User.Identity.Name);
            Betting be = null;
            foreach (var item in query)
            {
                be = item;
                bets.Add(be);
            }
            return View(bets);
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
