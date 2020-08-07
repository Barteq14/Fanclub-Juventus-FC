using FanclubJuventus.DAL;
using FanclubJuventus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data.SqlClient;
using System.Web.UI;
using System.IO;
using System.Diagnostics;

namespace FanclubJuventus.Controllers
{
    public class BasketController : Controller
    {
        // GET: Basket
        //metoda dodajaca do koszyka zakupiony product
        //GET Basket
        private FanclubContext db = new FanclubContext();
        public static List<Product> listProductsInBasket = new List<Product>();
        public static List<ProductSize> listProductsSize = new List<ProductSize>();
        public static double Price;
        public static List<DeliveryOption> deliversOptions = new List<DeliveryOption>();
        public static bool isNull;
        public static double DeliveryPrice;

        public ViewResult Index(int? id)
        {
            
            var prs = db.ProductSize.Select(p => p).Where(p => p.ID == id);
            ProductSize productSize = db.ProductSize.Find(id);
            //pobranie domyslnej opcji dostawy
            var delivers = db.DeliveryOption.Select(d => d);
            DeliveryOption dos = null;
            foreach (var item in delivers)
            {
                if (item.ID == 3)
                {
                    dos = item;
                }
            }
            ViewBag.ERROR = "Wybierz opcje dostawy!";
            if(deliversOptions == null)
            {
                ViewBag.DeliveryName = dos.Name;
                ViewBag.DeliveryKindName = dos.KindOfDelivery.Name;
                ViewBag.DeliveryKindPrice = dos.KindOfDelivery.PriceForDelivery;

            }
            double price2;
            DeliveryOption delo = null;
            foreach(var item in deliversOptions)
            {
                delo = item;
                ViewBag.DeliveryName = delo.Name;
                ViewBag.DeliveryKindName = delo.KindOfDelivery.Name;
                ViewBag.DeliveryKindPrice = delo.KindOfDelivery.PriceForDelivery;
                
            price2 = Price + delo.KindOfDelivery.PriceForDelivery;
            ViewBag.AllPrice2 = price2;
                DeliveryPrice = delo.KindOfDelivery.PriceForDelivery;
               
                
            }

            if (ModelState.IsValid)
            {
                ViewBag.SuccessMessage = "Zapisano!";
            }else
            {
                ViewBag.SuccessMessage = "Wybierz dostawę!";
            }

            if (productSize == null)
            {
                
                ViewBag.AllPrice = Price;
                return View(listProductsSize);

            }else if(productSize != null) {
                Price = productSize.product.Price;
                ViewBag.AllPrice = Price;
                foreach (var item in listProductsSize)
                {
                    Price = Price + item.product.Price;
                    ViewBag.AllPrice = Price;
                }

              
                
            }
            isNull = false;

            // listProductsInBasket.Add(product);
            listProductsSize.Add(productSize);
            return View(listProductsSize);
        }
     
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return View(listProductsSize);
            }

            ProductSize bsk = db.ProductSize.Find(id);
            Price = Price - bsk.product.Price;

            if (listProductsSize == null)
            {
                return HttpNotFound();
                //return View(listProductsInBasket);
            }
            // return View(listProductsInBasket);

            return View(bsk);
        }
     
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            foreach (var item in listProductsSize)
            {
                if (item.ID == id)
                {
                    listProductsSize.Remove(item);
                    break;
                }
            }

            return RedirectToAction("Index", "Basket", listProductsSize);

        }
        public ActionResult Done()
        {

            if(DeliveryPrice == '-')
            {
                ViewBag.Text = "Wybierz opcje dostawy!";
                RedirectToAction("Index");
            }

            if (listProductsSize.Count == 0)
            {
                return View(listProductsSize);
            }

            //pobieranie ceny przesylki
           
        

            foreach(var item in deliversOptions)
            {
                //poprawic
                Price += item.KindOfDelivery.PriceForDelivery;
                
            }

            //pobieranie zalogowanego użytkownika

            var pf = db.Profiles.Select(u => u).Where(u => u.UserName == User.Identity.Name);
            Profile profile = null;

            foreach (var item in pf)
            {
                profile = item;
            }

            //pobranie odpowiedniego statusu

            var st = db.Status.Select(s => s).Where(s => s.Name == "Expectant");

            Status status = null;
            foreach (var item in st)
            {
                status = item;
            }

            //tworzenie zamowienia

            Basket basket = new Basket { Price = Price, Profile = profile, DateOrder = DateTime.Now , Status = status , DeliveryPrice = DeliveryPrice , AllPrice = Price};

            db.Baskets.Add(basket);
            db.SaveChanges();

            

            //tworzenie basket_products
            //pobieranie produktu ktore nalezy do zamowienia
            ProductSize prod = null;
            foreach (var item in listProductsSize)
            {
                var product = db.ProductSize.Select(p => p).Where(p => p.ID == item.ID);
                foreach (var item2 in product)
                {
                    prod = item2;
                }

                Basket_ProductSize bp = new Basket_ProductSize { Basket = basket, ProductSize = prod };
                db.Basket_ProductSize.Add(bp);
                db.SaveChanges();
            }
            //wyzerowanie wartosci w koszyku
            listProductsSize.Clear();
            deliversOptions.Clear();
            Price = 0;

            var apikey = "efIWNWVx6pDzBF1oeNti8XBv0mjAoeykjY2RYWv4";

            var address = "https://api.smsapi.pl/sms.do?access_token=";
            var id1 = basket.Profile;

            var numer = "48" + profile.PhoneNumber;
            var email = profile.UserName;

            var message = "Thank you for your order :) ~ JUVENUS REGEM";


            var url = address + apikey + "&to=" + numer + "&message=" + message + "&sender=" + "&fast=1&format=json";

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            Debug.WriteLine(results);
            sr.Close();

            return View("Done", listProductsSize);
        }

      

        public ViewResult Bought_P()
        {
            List<Basket> orders = new List<Basket>();

            var ord = db.Baskets.Select(o => o).Where(o => o.Profile.UserName == User.Identity.Name);

            Basket bsk = null;

            foreach(var item in ord)
            {
                bsk = item;
                orders.Add(bsk);
            }
            
         //   orders.Clear();

            return View(orders);
        }
        public ActionResult Details(int? id)
        {
            List<Basket_ProductSize> bapp = new List<Basket_ProductSize>();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var orders_pr = db.Basket_ProductSize.Select(o => o).Where(o => o.BasketID == id);

            ViewBag.ID = id;
            Basket_ProductSize bap = null;

            foreach (var item in orders_pr)
            {
                
                bap = item;
               // ViewBag.Price2 = TotalPrice;
                bapp.Add(bap);
                
            }
           

            DateTime date = DateTime.Now;
            ViewBag.Date2 = date;

            //pobieranie danych o uzytkowniku
            foreach (var item in bapp)
            {
                ViewBag.UserName2 = item.Basket.Profile.UserName;
                ViewBag.Name2 = item.Basket.Profile.FirstName;
                ViewBag.SurName2 = item.Basket.Profile.SurName;
                ViewBag.City2 = item.Basket.Profile.City;
                ViewBag.Street2 = item.Basket.Profile.Street;
                ViewBag.Number2 = item.Basket.Profile.Number;
              

            }

            //pobieranie danych o kwocie ktora user musi zaplacic 

            var basket = db.Baskets.Select(o => o).Where(o =>o.ID == id);

            foreach (var item in basket)
            {
                ViewBag.TotalPrice = item.AllPrice;
                ViewBag.DeliveryPrice = item.DeliveryPrice;
            
            }
            return View(bapp);
        }

        public ActionResult ShowPDF(int? id)
        {
            List<Basket_ProductSize> bapp = new List<Basket_ProductSize>();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var orders_pr = db.Basket_ProductSize.Select(o => o).Where(o => o.BasketID == id);

            ViewBag.ID = id;
            Basket_ProductSize bap = null;

            foreach (var item in orders_pr)
            {

                bap = item;
                // ViewBag.Price2 = TotalPrice;
                bapp.Add(bap);

            }


            DateTime date = DateTime.Now;
            ViewBag.Date2 = date;

            //pobieranie danych o uzytkowniku
            foreach (var item in bapp)
            {
                ViewBag.UserName2 = item.Basket.Profile.UserName;
                ViewBag.Name2 = item.Basket.Profile.FirstName;
                ViewBag.SurName2 = item.Basket.Profile.SurName;
                ViewBag.City2 = item.Basket.Profile.City;
                ViewBag.Street2 = item.Basket.Profile.Street;
                ViewBag.Number2 = item.Basket.Profile.Number;


            }

            //pobieranie danych o kwocie ktora user musi zaplacic 

            var basket = db.Baskets.Select(o => o).Where(o => o.ID == id);

            foreach (var item in basket)
            {
                ViewBag.TotalPrice = item.AllPrice;
                ViewBag.DeliveryPrice = item.DeliveryPrice;

            }
            return View(bapp);
        }

        public ActionResult ChooseDelivery()
        {
            List<DeliveryOption> delivers = new List<DeliveryOption>();

            var deliversss = db.DeliveryOption.Select(d => d);
            DeliveryOption delo = null;

            foreach(var item in deliversss)
            {
                delo = item;
                delivers.Add(delo);
            }
            isNull = false;
            TempData["success"] = "Udało się!";
            TempData["dangerous"] = "Wybierz dostawę!";
            return View(delivers);
        }

        public ActionResult SelectDelivery(int? id)
        {
            //POBIERANIE wybranej dostawy  - poprawic
            

            DeliveryOption delo = db.DeliveryOption.Find(id);
       


            deliversOptions.Add(delo);
            isNull = false;

            return RedirectToAction("Index");
        }

        public ActionResult PrintPDF(int? id)
        {
            var report = new Rotativa.ActionAsPdf("ShowPDF",new { id = id});

            return report;
        }

    }



}
