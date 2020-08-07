using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FanclubJuventus.Models
{
    public class DeliveryOption
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        
        public int KindOfDeliveryID { get; set; }
        public virtual KindOfDelivery KindOfDelivery { get; set; }
        
    }
}