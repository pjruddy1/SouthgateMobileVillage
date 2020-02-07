using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouthgateMobileVillage.Models
{
    public class Graphic
    {
        public int ID { get; set; }
        public int HomeID { get; set; }
        public string Photo { get; set; }
        public string AltText { get; set; }
        public virtual Home Home { get; set; }
    }
}