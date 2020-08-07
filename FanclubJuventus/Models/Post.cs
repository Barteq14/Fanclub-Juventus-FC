using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FanclubJuventus.Models
{
    public class Post
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }

        public string Image { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime? PostDate { get; set; }

    }
}