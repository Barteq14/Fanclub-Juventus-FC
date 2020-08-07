using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FanclubJuventus.Models
{
    public class Basket_Product
    {
        public int ID { get; set; }
        public int BasketID { get; set; }
        public virtual Basket Basket { get; set; }
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }

        public int StatusID { get; set; }
        public virtual Status Status { get; set; }
        public string Image { get; set; }
    }
}