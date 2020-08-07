using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FanclubJuventus.ViewModels
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)]
        public int? IdCategory { get; set; }

        public int ProductCount { get; set; }
    }
}