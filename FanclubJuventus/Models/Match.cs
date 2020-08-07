using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FanclubJuventus.Models
{
    public class Match
    {
        public int Id { get; set; }
        //dorobic jeszcze!
      //mozliwosc obstawiania meczy 
      //przegladanie skladu druzyny 
       
       
        public int ClubID { get; set; }

       
        public virtual Club club { get; set; }

        public int Club2ID { get; set; }
        public virtual Club club2 { get; set; }
        [Range(0, 7)]
        public int Result1 { get; set; }
        [Range(0, 7)]
        public int Result2 { get; set; }

        public string Status { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime? MatchDate { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }


    }
}