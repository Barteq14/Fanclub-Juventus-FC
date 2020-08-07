using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FanclubJuventus.Models
{
    public class FirstSquad
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public int Number { get; set; }
        public string position { get; set; }
        public int Rating { get; set; }

        public string Image { get; set; }
    }
}