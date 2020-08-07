using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FanclubJuventus.Models
{
    public class OrderDetails
    {
        public int ID { get; set; }
        public double TotalPrice { get; set; }

        public int Basket_ProductSizeID { get; set; }
        public virtual Basket_ProductSize Basket_ProductSize { get; set; }
        public int DeliveryOptionID { get; set; }
        public virtual  DeliveryOption DeliveryOption { get; set; }
    }
}