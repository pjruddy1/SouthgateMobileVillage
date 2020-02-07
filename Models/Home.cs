using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouthgateMobileVillage.Models
{
    public enum Amenity
    {
        NONE, AIR, TRASH, SHED, WASHER, DRYER, DISHWASHER
    }
    public class Home
    {
        public int ID { get; set; }
        public int Bedroom { get; set; }
        public int Bathroom { get; set; }
        public int SqrFeet { get; set; }
        public int Year { get; set; }
        public virtual ICollection<Graphic> Photo { get; set; }
        public virtual ICollection<Resident> Resident { get; set; }
        public virtual ICollection<Amenity> Amenity { get; set; }
    }
}