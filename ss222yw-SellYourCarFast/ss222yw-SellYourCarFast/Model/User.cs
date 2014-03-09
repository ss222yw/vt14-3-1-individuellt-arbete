using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ss222yw_SellYourCarFast.Model
{
    public class User
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "Ett namn måste anges.")]
        [StringLength(40, ErrorMessage = "Namnet kan bestå av som mest 40 tecken.")]
        public string Name { get; set; }
    }
}