using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FanclubJuventus.Models
{
    public class ForumCategory
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public virtual ICollection<ForumSubject> ForumSubject { get; set; }
    }
}