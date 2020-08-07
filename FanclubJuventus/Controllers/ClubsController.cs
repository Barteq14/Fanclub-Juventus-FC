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
    
    public class ClubsController : Controller
    {
        private FanclubContext db = new FanclubContext();
        private static List<Club> cl1 = new List<Club>();
        private static double p1;
        private static double p2;
        //private static List<Club> cl2 = new List<Club>();
        //private static Club c1 = new Club();
        //private static Club c2 = new Club();
        // GET: Clubs
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";
            ViewBag.CoachSortParm = sortOrder == "Coach" ? "coach_desc" : "Coach";
            ViewBag.CountrySortParm = sortOrder == "Country" ? "country_desc" : "Country";
            ViewBag.PointsSortParm = sortOrder == "Points" ? "points_desc" : "Points";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var clubs = from s in db.Clubs
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                clubs = clubs.Where(s => s.Name.Contains(searchString)
                                       || s.Country.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    clubs = clubs.OrderByDescending(s => s.Name);
                    break;
                case "Coach":
                    clubs = clubs.OrderBy(s => s.Coach);
                    break;
                case "coach_desc":
                    clubs = clubs.OrderByDescending(s => s.Coach);
                    break;
                case "Country":
                    clubs = clubs.OrderBy(s => s.Country);
                    break;
                case "country_desc":
                    clubs = clubs.OrderByDescending(s => s.Country);
                    break;
                case "Name":
                    clubs = clubs.OrderBy(s => s.Name);
                    break;
                case "points_desc":
                    clubs = clubs.OrderByDescending(s => s.Points);
                    break;
                default:
                    clubs = clubs.OrderBy(s => s.Points);
                    break;
            }

            var clubss = db.Clubs.Include(c => c.Coach);

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(clubs.ToPagedList(pageNumber, pageSize));
        }

        // GET: Clubs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club club = db.Clubs.Find(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View(club);
        }

        // GET: Clubs/Create
        public ActionResult Create()
        {
            ViewBag.CoachId = new SelectList(db.Coaches, "ID", "FirstName");
            return View();
        }

        // POST: Clubs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Points,Country,Image,CoachId")] Club club)
        {
            HttpPostedFileBase file = Request.Files["plikZObrazkiem"];
            if (file != null && file.ContentLength > 0)
            {
                club.Image = file.FileName;
                file.SaveAs(HttpContext.Server.MapPath("~/Images/") + club.Image);
            }
            if (ModelState.IsValid)
            {
                db.Clubs.Add(club);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CoachId = new SelectList(db.Coaches, "ID", "FirstName", club.CoachId);
            return View(club);
        }

        // GET: Clubs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Club club = db.Clubs.Find(id);
            string Image = club.Image;
            if (club == null)
            {
                return HttpNotFound();
            }
            ViewBag.CoachId = new SelectList(db.Coaches, "ID", "FirstName", club.CoachId);
            return View(club);
        }

        // POST: Clubs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Points,Country,Image,CoachId")] Club club)
        {

            HttpPostedFileBase file = Request.Files["plikZObrazkiem"];
            if (file != null && file.ContentLength > 0)
            {
                club.Image = file.FileName;
                file.SaveAs(HttpContext.Server.MapPath("~/Images/") + club.Image);
            }
            if (ModelState.IsValid)
            {
                db.Entry(club).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CoachId = new SelectList(db.Coaches, "ID", "FirstName", club.CoachId);
            return View(club);
        }

        // GET: Clubs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) 
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club club = db.Clubs.Find(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View(club);
        }

        // POST: Clubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Club club = db.Clubs.Find(id);
            db.Clubs.Remove(club);
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

        public ActionResult Simulation()
        {
            var simulation = db.Clubs.Select(s => s);
            ViewBag.ListOfClientIDs1 = new SelectList(db.Clubs, "ClubId", "Name");
            ViewBag.ListOfClientIDs2 = new SelectList(db.Clubs, "ClubId", "Name");
            List<Club> newList = new List<Club>();

            ViewBag.Team1 = simulation.Select(t =>t.Name);
            ViewBag.Team2 = simulation.Select(t =>t.Name);

            if (cl1 == null)
            {
                return View(simulation.ToList());
            }

            foreach (var item in cl1)
            {
                if (item.ID == 1)
                {
                    ViewBag.club1 = item.Name;
                    ViewBag.photo = item.Image;
                }else if(item.ID != 1)
                {
                    ViewBag.club2 = item.Name;
                    ViewBag.Photo1 = item.Image;
                   
                }
            }
            return View(simulation.ToList());
        }

        public ActionResult SelectTeam(int? id)
        {
            
            var team = db.Clubs.Find(id);
            cl1.Add(team);
            
          
            return RedirectToAction("Simulation");
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult SimulationGame()
        {
            List<Club> club = new List<Club>();
            var cls = db.Clubs.Select(g => g);
            
            string firstTeam = "";
            string secondTeam = "";

            //pobieranie wartości z pól formularza
            var team1 = Request.Form["Team1"];
            var team2 = Request.Form["Team2"];

            firstTeam = team1;
            secondTeam = team2;

            //warunek zabezpieczajacy przed wybraniem dwóch takich samych drużyn
            if(firstTeam != secondTeam)
            {
                ViewBag.T1 = firstTeam;
                ViewBag.T2 = secondTeam;

                var query1 = db.Clubs.Select(o => o).Where(o => o.Name == firstTeam);
                var query2 = db.Clubs.Select(o => o).Where(o => o.Name == secondTeam);

                //zmienna przechowujaca punkty druzyn
                double pointsFirstClub = 0.0;
                double pointsSecondClub = 0.0;

                //pobieranie klubów i dodawnaie ich do listy
                Club objectClub = null;
                foreach (var item in cls)
                {
                    objectClub = item;
                    club.Add(objectClub);
                }

                //pobieranie punktów zawodników
                var downloadedPointsFirstClub = db.Players.Where(a => a.Club.Name == objectClub.Name).Select(g => g.Rating);
                //pobieranie wszystkich zawodnikow
                var downloadedPlayers = db.Players.Select(p => p);
                //pobranie klubow z listy
                var firstClub = club[0];
                var secondClub = club[1];

                //pobieranie i sumowanie punktow zawodnikow danej ekipy
                foreach (var item in downloadedPlayers)
                {
                    if (item.Club.Name == firstClub.Name)
                    {
                        pointsFirstClub = pointsFirstClub + item.Rating;
                        ViewBag.P1 = pointsFirstClub;
                        ViewBag.Points = pointsFirstClub/11;
                        p1 = pointsFirstClub/11;
                        //zmienna pomocnicza trzymająca nazwe klubu
                        ViewBag.NameClub1 = item.Club.Name;
                    }

                    if (item.Club.Name == secondClub.Name)
                    {
                        pointsSecondClub = pointsSecondClub + item.Rating;
                        ViewBag.P2 = pointsSecondClub;
                        ViewBag.Points2 = pointsSecondClub/11;
                        p2 = pointsSecondClub/11;
                        //zmienna pomocnicza trzymająca nazwe klubu
                        ViewBag.NameClub2 = item.Club.Name;
                    }
                }

                int pp1 = (int)p1;
                int pp2 = (int)p2;

               if((p1 - p2) <= 10)
                {
                    ViewBag.Po1 = pp1 / 50;
                    ViewBag.Po2 = pp2 / 50;
                }else
                {
                    ViewBag.Po1 = pp1 / 50;
                    ViewBag.Po2 = pp2 / 50;
                }

                //pobieranie nazwy zdjecia obu druzyn
                foreach (var item in query1)
                {
                    ViewBag.photo1 = item.Image;
                }
                foreach (var item in query2)
                {
                    ViewBag.photo2 = item.Image;
                }
                    return View();
            }else
            {
                ViewBag.err2 = "Error";
                ViewBag.Err = "Nie możesz wybrać tych samych drużyn! Wróć proszę na poprzednią stronę :)";
                return View();
            } 
        }

        public ActionResult SerieA(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";
            ViewBag.CoachSortParm = sortOrder == "Coach" ? "coach_desc" : "Coach";
            ViewBag.CountrySortParm = sortOrder == "Country" ? "country_desc" : "Country";
            ViewBag.PointsSortParm = sortOrder == "Points" ? "points_desc" : "Points";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var clubs = from s in db.Clubs where s.Country == "Italy"
                        select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                clubs = clubs.Where(s => s.Name.Contains(searchString)
                                       || s.Country.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    clubs = clubs.OrderByDescending(s => s.Name);
                    break;
                case "Coach":
                    clubs = clubs.OrderBy(s => s.Coach);
                    break;
                case "coach_desc":
                    clubs = clubs.OrderByDescending(s => s.Coach);
                    break;
                case "Country":
                    clubs = clubs.OrderBy(s => s.Country);
                    break;
                case "country_desc":
                    clubs = clubs.OrderByDescending(s => s.Country);
                    break;
                case "Name":
                    clubs = clubs.OrderBy(s => s.Name);
                    break;
                case "points_desc":
                    clubs = clubs.OrderByDescending(s => s.Points);
                    break;
                default:
                    clubs = clubs.OrderBy(s => s.Points);
                    break;
            }

            var clubss = db.Clubs.Include(c => c.Coach);

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(clubs.ToPagedList(pageNumber, pageSize));
        }

    }
}
