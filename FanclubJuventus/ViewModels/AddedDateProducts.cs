using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FanclubJuventus.ViewModels
{
    public class AddedDateProducts
    {
        [DataType(DataType.Date)]
        public DateTime? EnrollmentDate { get; set; }
    }
}