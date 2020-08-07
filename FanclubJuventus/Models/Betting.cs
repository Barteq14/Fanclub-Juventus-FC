using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FanclubJuventus.Models
{
    public class Betting
    {
        public int ID { get; set; }
        public int ProfileID { get; set; }
        public virtual Profile Profile { get; set; }
        public int MatchID { get; set; }
        public virtual Match Match { get; set; }

        [Range(0, 7)]
        public int Result1 { get; set; }
        [Range(0, 7)]
        public int Result2 { get; set; }

    }
}