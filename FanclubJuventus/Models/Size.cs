using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FanclubJuventus.Models
{
    public class Size
    {
        public int ID { get; set; }
        public string SizeOfProduct { get; set; }

        public virtual ICollection<ProductSize> Product_Size { get; set; }
    }
}