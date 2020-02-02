using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouthgateMobileVillage.Models
{
    public class Home4Sale
    {
        public double Price { get; set; }
        public int Bedroom { get; set; }
        public int Bathroom { get; set; }
        public int SqrFeet { get; set; }
        public int Lot { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
    }
}