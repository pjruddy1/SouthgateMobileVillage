using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouthgateMobileVillage.Models
{
    public class Resident
    {
        public int ID { get; set; }
        public int HomeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual Home Home { get; set; }
    }
}