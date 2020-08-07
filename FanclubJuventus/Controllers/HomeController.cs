using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FanclubJuventus.DAL;
using FanclubJuventus.ViewModels;
using System.Web.Mvc;

namespace FanclubJuventus.Controllers
{
 
    public class HomeController : Controller
    {
        private FanclubContext db = new FanclubContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            IQueryable<EnrollmentDateGroup> data = from FanclubContext in db.Products
                                                   group FanclubContext by FanclubContext.CategoryId into categoryGroup
                                                   select new EnrollmentDateGroup()
                                                   {
                                                       IdCategory = categoryGroup.Key,
                                                       ProductCount = categoryGroup.Count()
                                                   };
            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}