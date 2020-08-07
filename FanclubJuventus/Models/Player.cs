using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FanclubJuventus.Models
{
    public class Player
    {
        public int Id { get; set; }
        
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        
      
        public int Age { get; set; }
        public string Country { get; set; }
        public int Number { get; set; }
        public string position { get; set; }
        public int Rating { get; set; }

        public string Image { get; set; }
        public int ClubID { get; set; }
        public virtual  Club Club { get; set; }

    }
}