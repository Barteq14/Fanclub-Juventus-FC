using FanclubJuventus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FanclubJuventus.DAL;

namespace FanclubJuventus.Controllers
{
    public class AdminOrderController : Controller
    {
        private FanclubContext db = new FanclubContext();
        // GET: AdminOrder
       
        public ViewResult Index()
        {


            
         List<Basket> orders = new List<Basket>();
            //pobranie zamowien o statusie oczekujaczym

            var ord = db.Baskets.Select(o => o);
            
            
            Basket bskp = null;

            foreach (var item in ord)
            {

                bskp = item;
                orders.Add(bskp);
            }

           
            
          

            return View(orders);
        
    }
        //zmiana statusu na zaakceptowany nie dziala mi to do konca :/ 
        public ActionResult Accept(int? id)
        {

            List<Basket> accepted = new List<Basket>();
            // Basket_Product bbbppp = db.Basket_Product.Find(id);

            //pobranie statusu "Accepted" i "Expentant"
            var stat = db.Status.Find(1);
            var stat2 = db.Status.Find(2);
            
           /* var status = db.Status.Select(s => s).Where(s => s.Name == "Accepted");
            Status ss = null;
            
            foreach(var item in status)
            {
                ss = item;
            }*/

            var query = from bp in db.Baskets where bp.ID == id &&  bp.Status.Name == "Expectant" select bp;
            //var basprod = db.Basket_Product.Select(b => b).Where(b => b.ID == id);
            //var bbpp = db.Basket_Product.Find(id).Status.Name == "Expectant";
            //nie zamienia mi tego statusu :/
            foreach(var item in query)
            {
              
                    item.Status = stat2;
                
            }
            
            db.SaveChanges();



            return RedirectToAction("Index");
           
        }
    }
}