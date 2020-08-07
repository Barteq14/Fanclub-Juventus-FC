 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FanclubJuventus.Models
{
    public class Club
    {
        public int ID { get; set; }
       [Required(ErrorMessage = "An Club must be choosen!")]
        public string Name { get; set; }

        public double Points { get; set; }
        public string Image { get; set; }
        public string Country { get; set; }
        public int CoachId { get; set; }
      
        public virtual Coach Coach { get; set; }

        public virtual ICollection<Player> Player { get; set; }
       
    }
}