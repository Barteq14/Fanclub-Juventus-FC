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
    public class PlayersController : Controller
    {
        private FanclubContext db = new FanclubContext();
        Club club22 = new Club();

        // GET: Players
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var goalkeepers = db.Players.Where(p => p.position.Equals("Goalkeeper"));
            var defencers = db.Players.Select(p => p).Where(p => p.position.Equals("Defencer"));
            var helpers = db.Players.Select(p => p).Where(p => p.position.Equals("Helper"));
            var attackers = db.Players.Select(p => p).Where(p => p.position.Equals("Attacker"));

            ViewBag.goalkeppers = goalkeepers;
            ViewBag.defencers = defencers;
            ViewBag.helpers = helpers;
            ViewBag.attackers = attackers;

            ViewBag.CurrentSort = sortOrder;
            ViewBag.FirstNameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.LastNameSortParm = sortOrder == "LastName" ? "LN_desc" : "LastName";
            ViewBag.AgeSortParm = sortOrder == "Age" ? "Age_desc" : "Age";
            ViewBag.RatingSortParm = sortOrder == "Rating" ? "Rating_desc" : "Rating";
            ViewBag.CountrySortParm = sortOrder == "Country" ? "Country_desc" : "Country";
            ViewBag.PositionSortParm = sortOrder == "Position"? "Position_desc" : "Position";
            ViewBag.NumberSortParm = sortOrder == "Number" ? "Number_desc" : "Number";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var players = from p in db.Players where p.Club.ID == 1
                           select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                players = players.Where(p => p.FirstName.Contains(searchString) 
                                       || p.LastName.Contains(searchString) ||
                                       p.Country.Contains(searchString) ||
                                       p.position.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    players = players.OrderByDescending(s => s.FirstName);
                    break;
                case "LastName":
                    players = players.OrderBy(s => s.LastName);
                    break;
                case "LN_desc":
                    players = players.OrderByDescending(s => s.LastName);
                    break;
                case "Age":
                    players = players.OrderBy(s => s.Age);
                    break;
                case "Age_desc":
                    players = players.OrderByDescending(s => s.Age);
                    break;
                case "Rating":
                    players = players.OrderBy(s => s.Rating);
                    break;
                case "Rating_desc":
                    players = players.OrderByDescending(s => s.Rating);
                    break;
                case "Country":
                    players = players.OrderBy(s => s.Country);
                    break;
                case "Country_desc":
                    players = players.OrderByDescending(s => s.Country);
                    break;
                case "Position":
                    players = players.OrderBy(s => s.position);
                    break;
                case "Position_desc":
                    players = players.OrderByDescending(s => s.position);
                    break;
                case "Number":
                    players = players.OrderBy(s => s.Number);
                    break;
                case "Number_desc":
                    players = players.OrderByDescending(s => s.Number);
                    break;

                default:
                    players = players.OrderBy(s => s.FirstName);
                    break;
            }
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(players.ToPagedList(pageNumber, pageSize));
        }

        // GET: Players/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // GET: Players/Create
        public ActionResult Create()
        {

            ViewBag.ClubID = new SelectList(db.Clubs, "ID", "Name");
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Number,Age,Country,position,Image,ClubID")] Player player)
        {
            HttpPostedFileBase file = Request.Files["plikZObrazkiem"];
            if (file != null && file.ContentLength > 0)
            {
                player.Image = file.FileName;
                file.SaveAs(HttpContext.Server.MapPath("~/Images/") + player.Image);
            }
            if (ModelState.IsValid)
            {
                db.Players.Add(player);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClubID = new SelectList(db.Clubs, "ID", "Name",player.ClubID);
            return View(player);
        }

        // GET: Players/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            string Image = player.Image;
            if (player == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClubID = new SelectList(db.Clubs, "ID", "Name", player.ClubID);
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Number,Age,Country,position,Image,ClubID")] Player player)
        {
            HttpPostedFileBase file = Request.Files["plikZObrazkiem"];
            if (file != null && file.ContentLength > 0)
            {
                player.Image = file.FileName;
                file.SaveAs(HttpContext.Server.MapPath("~/Images/") + player.Image);
            }
            if (ModelState.IsValid)
            {
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClubID = new SelectList(db.Clubs, "ID", "Name", player.ClubID);
            return View(player);
        }

        // GET: Players/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Player player = db.Players.Find(id);
            db.Players.Remove(player);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FirstSquad(int? id)
        {
            Player pl = db.Players.Find(id);

            FirstSquad fs = new FirstSquad { Image = pl.Image, FirstName = pl.FirstName , LastName = pl.LastName , Age = pl.Age , Country = pl.Country , position = pl.position , Number = pl.Number , Rating = pl.Rating };
           
            db.FirstSquad.Add(fs);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
       
        public ViewResult FirstSquad1()
        {
            List<FirstSquad> firstSquadPlayers = new List<FirstSquad>();
            var squad = db.FirstSquad.Select(s => s);

            FirstSquad fs = null;
            foreach(var item in squad)
            {
                fs = item;
                firstSquadPlayers.Add(fs);
            }
            return View(firstSquadPlayers);
        }
        public ActionResult DeleteSquad(int? id)
        {
            FirstSquad fs = db.FirstSquad.Find(id);
  
            db.FirstSquad.Remove(fs);
            db.SaveChanges();

            return RedirectToAction("FirstSquad1");
        }
        public ViewResult Squads(int? id)
        {
            string nazwa = "Juventus FC";
            int idtemp = 1;
            if(idtemp == 1)
            {
                var goalkeepers = db.Players.Where(p => p.position.Equals("Goalkeeper") && p.ClubID == 1);
                var defencers = db.Players.Select(p => p).Where(p => p.position.Equals("Defender") && p.ClubID == 1);
                var helpers = db.Players.Select(p => p).Where(p => p.position.Equals("Helper") && p.ClubID == 1);
                var attackers = db.Players.Select(p => p).Where(p => p.position.Equals("Attacker") && p.ClubID == 1);

                List<Player> pl = new List<Player>();
                foreach (var item in goalkeepers)
                {
                    pl.Add(item);
                }


                ViewBag.goalkeppers = goalkeepers;
                ViewBag.defencers = defencers;
                ViewBag.helpers = helpers;
                ViewBag.attackers = attackers;

            }
/*tutaj trzeba jakoś ogarnąć żeby tylko z juve brało zawodników , bo zapytanie zwraca bramkarzy ze wszystkich drużyn itp...*/

            var club = db.Clubs.Find(id);

            List<Player> players = new List<Player>();
            var pls = db.Players.Select(p => p).Where(p => p.Club.ID == id);
            Player player = null;

            foreach(var item in pls)
            {
                player = item;
                players.Add(item);
            }

            return View(players);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult DreamTeam()
        {
            //potrzebne tymczasowe listy do przechowywania zawodników, którzy grają na danych pozycjach
            List<Player> goalkeepers = new List<Player>();
            List<Player> defencers = new List<Player>();
            List<Player> helpers = new List<Player>();
            List<Player> attackers = new List<Player>();
            //pobieranie zawodnikow juventusu
            var juve = db.Players.Select(o => o).Where(o => o.Club.Name.Equals("Juventus FC"));
            //pobieranie graczy na konkretnych pozycjach
            foreach (var item in juve)
            {
                if (item.position.Equals("Goalkeeper"))
                {
                    goalkeepers.Add(item);
                }else if (item.position.Equals("Defender"))
                {
                    defencers.Add(item);
                }else if (item.position.Equals("Helper"))
                {
                    helpers.Add(item);
                }else if (item.position.Equals("Attacker"))
                {
                    attackers.Add(item);
                }
            }

            ViewBag.Goalkeepers = goalkeepers.Select(o => o.FullName );
            ViewBag.Defencers = defencers.Select(o => o.FullName);
            ViewBag.Helpers = helpers.Select(o => o.FullName);
            ViewBag.Attackers = attackers.Select(o => o.FullName);

            return View();
        }
        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult SaveDreamTeam()
        {

            //pobranie zalogowanego uzytkownika
            var pf = db.Profiles.Select(u => u).Where(u => u.UserName == User.Identity.Name);
            Profile profile = null;

            foreach (var item in pf)
            {
                profile = item;
            }

            //listy
            List<Player> g = new List<Player>();
            List<Player> d = new List<Player>();
            List<Player> h = new List<Player>();
            List<Player> a = new List<Player>();

            var goalkeepers = "";
            var defencers = "";
            var helpers = "";
            var attackers = "";

            var glk = Request.Form["Goalkeepers"];
            var dfc = Request.Form["Defencers"];
            var hlp = Request.Form["Helpers"];
            var atc = Request.Form["Attackers"];

            goalkeepers = glk;
            defencers = dfc;
            helpers = hlp;
            attackers = atc;

            DreamTeamProfile drp = new DreamTeamProfile { Profile = profile, FullNamePlayer = goalkeepers };
            DreamTeamProfile drp2 = new DreamTeamProfile { Profile = profile, FullNamePlayer = defencers };
            DreamTeamProfile drp3 = new DreamTeamProfile { Profile = profile, FullNamePlayer = helpers };
            DreamTeamProfile drp4 = new DreamTeamProfile { Profile = profile, FullNamePlayer = attackers };

            ViewBag.G = goalkeepers;
            ViewBag.D = defencers;
            ViewBag.H = helpers;
            ViewBag.A = attackers;

            /* foreach(var item in dfc)
              {
                  if((dfc[0] == dfc[1]) || (dfc[0] == dfc[2]) || (dfc[0] == dfc[3]) || (dfc[1] == dfc[2]) || (dfc[1] == dfc[3]) || (dfc[2] == dfc[3]))
                  {
                      ViewBag.Err = "Error!";
                      return View();
                  }
                  else
                  {
                      DreamTeamProfile drp = new DreamTeamProfile { Profile = profile, FullNamePlayer = goalkeepers };
                      DreamTeamProfile drp2 = new DreamTeamProfile { Profile = profile, FullNamePlayer = defencers };
                      DreamTeamProfile drp3 = new DreamTeamProfile { Profile = profile, FullNamePlayer = helpers };
                      DreamTeamProfile drp4 = new DreamTeamProfile { Profile = profile, FullNamePlayer = attackers };

                      ViewBag.G = goalkeepers;
                      ViewBag.D = defencers;
                      ViewBag.H = helpers;
                      ViewBag.A = attackers;

                      return View();
                  }
             */
            return View();
        }      
    }
}
