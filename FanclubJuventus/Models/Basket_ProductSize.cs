using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FanclubJuventus.Models
{
    public class Basket_ProductSize
    {
        public int ID { get; set; }
        public int BasketID { get; set; }
        public virtual Basket Basket { get; set; }
        public int ProductSizeID { get; set; }
        public virtual ProductSize ProductSize { get; set; }

        
        public string Image { get; set; }
    }
}