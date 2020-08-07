using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FanclubJuventus.Models
{
    public class ProductSize
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public virtual Product product { get; set; }
        public int SizeID { get; set; }
        public virtual Size size { get; set; }

    }
}