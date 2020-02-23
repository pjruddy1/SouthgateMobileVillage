using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SouthgateMobileVillage.Models
{
    public class Resident
    {
        public int ID { get; set; }

        [Index]
        [Display(Name = "Home ID")]
        public int HomeID { get; set; }

        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Please Enter a Valid Name")]
        public string FirstName { get; set; }

        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Please Enter a Valid Name")]
        public string LastName { get; set; }
        public virtual Home Home { get; set; }
    }
}