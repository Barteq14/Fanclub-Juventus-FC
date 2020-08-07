using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FanclubJuventus.Models
{
    public class Comment
    {
        public int ID { get; set; }
        [Required]
        public string Content { get; set; }
        
        public int ProfileID { get; set; }
     
        public virtual Profile Profile { get; set; }
 
        public int ForumSubjectID { get; set; }
        
        public virtual ForumSubject ForumSubject { get; set; }
        public DateTime CommentDate { get; set; }
    }
}