using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SouthgateMobileVillage.Models
{
    public class Graphic
    {
        public int ID { get; set; }

        [Index]
        [Display(Name = "Home ID")]
        public int HomeID { get; set; }
        public string Photo { get; set; }
        public string AltText { get; set; }
        public virtual Home Home { get; set; }
    }
}