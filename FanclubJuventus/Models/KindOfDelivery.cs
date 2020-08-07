using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FanclubJuventus.Models
{
    public class KindOfDelivery
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int PriceForDelivery { get; set; }
        public virtual ICollection<DeliveryOption> DeliveryOption { get; set; }
    }
}