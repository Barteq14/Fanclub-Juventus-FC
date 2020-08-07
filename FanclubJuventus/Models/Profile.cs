using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FanclubJuventus.Models
{
    public class Profile  
    {
       

        public int ID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }

        [Display(Name = "Home Phone")]
        [DataType(DataType.PhoneNumber)]
        [Phone(ErrorMessage ="Wrong phone number!")]
        public string PhoneNumber { get; set; }
        public string Image { get; set; }

        

        public virtual ICollection<Comment> Comments { get; set;}
        public virtual ICollection<Basket> Baskets { get; set; }

    }
}