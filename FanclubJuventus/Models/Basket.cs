using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FanclubJuventus.Models
{
    public class Basket
    {
        public int ID { get; set; }
        
        public double Price { get; set; }
        public int ProfileID { get; set; }
        public virtual Profile Profile { get; set; }

       
        public DateTime DateOrder { get; set; }
        public int StatusID { get; set; }
        public virtual Status Status { get; set; }
        public double DeliveryPrice { get; set; }

        public double AllPrice { get; set; }
        
        public virtual ICollection<Basket_ProductSize> Baskets_ProductSize  { get; set; }
    }  
}