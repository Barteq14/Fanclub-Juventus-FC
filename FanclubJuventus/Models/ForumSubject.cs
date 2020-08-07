using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FanclubJuventus.Models
{
    public class ForumSubject
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public int ForumCategoryID { get; set; }
      
        public virtual ForumCategory ForumCategory { get; set; }

        public virtual IEnumerable<Comment> Comments { get; set; }
    }
}