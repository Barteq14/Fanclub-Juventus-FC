using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FanclubJuventus.Models
{
    public class DreamTeamProfile
    {
        public int ID { get; set; }
        public int ProfileID { get; set; }
        public virtual Profile Profile { get; set; }

        public string FullNamePlayer { get; set; }
    }
}