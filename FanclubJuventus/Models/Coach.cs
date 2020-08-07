using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FanclubJuventus.Models
{
    public class Coach
    {
        public int ID { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return LastName + ", " + LastName; }
        }

        public int Age { get; set; }
        public string EmployedSince { get; set; }
        public string EmployedTo { get; set; }
        public string Description { get; set; }


        public virtual ICollection<Club> clubs { get; set; }

      
    }
}