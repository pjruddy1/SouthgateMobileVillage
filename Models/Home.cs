using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SouthgateMobileVillage.Models
{
    public enum Amenity
    {
        NONE, AIR, TRASH, SHED, WASHER, DRYER, DISHWASHER
    }
    [Table("HomeInfo")]
    public class Home
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter the amount of bedrooms.")]
        [Range(1,10, ErrorMessage = "must be between 1 and 10 bedrooms")]
        public int Bedroom { get; set; }

        [Required(ErrorMessage = "Please enter the amount of Bathrooms.")]
        [Range(1, 10, ErrorMessage = "must be between 1 and 10 Bathrooms")]
        public int Bathroom { get; set; }

        [Required(ErrorMessage = "Please enter the amount of Square Feet.")]
        [Display(Name = "Square Feet")]
        public int SqrFeet { get; set; }
       
        [Required(ErrorMessage = "Please enter the Year of the home.")]
        [Range(1950, 2020, ErrorMessage = "Please Enter a Valid Year")]
        public int Year { get; set; }

        public virtual ICollection<Graphic> Photo { get; set; }
        public virtual ICollection<Resident> Resident { get; set; }
        public virtual ICollection<Amenity> Amenity { get; set; }
    }
}