using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SouthgateMobileVillage.Models;

namespace SouthgateMobileVillage.DAL
{
    public class ResidentInitalizer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ResidentContext>
    {
        protected override void Seed(ResidentContext context)
        {
            var Homes = new List<Home>
            {
                new Home{ Bedroom=2, Bathroom=2, SqrFeet=900, Year=1978},
                new Home{ Bedroom=2, Bathroom=1, SqrFeet=650, Year=1982},
                new Home{ Bedroom=3, Bathroom=2, SqrFeet=1100, Year=1983},
                new Home{ Bedroom=3, Bathroom=2, SqrFeet=1000, Year=1985},
                new Home{ Bedroom=1, Bathroom=1, SqrFeet=500, Year=1978},
                new Home{ Bedroom=2, Bathroom=2, SqrFeet=950, Year=1988},
                new Home{ Bedroom=2, Bathroom=2, SqrFeet=800, Year=1984},
                new Home{ Bedroom=2, Bathroom=2, SqrFeet=850, Year=1977}
            };

            Homes.ForEach(x => context.Homes.Add(x));
            context.SaveChanges();

            var residents = new List<Resident>
            {
                new Resident{ FirstName="Billy",LastName="Bob", HomeID=1},
                new Resident{ FirstName="Jill",LastName="Babcock", HomeID=2},
                new Resident{ FirstName="John",LastName="Godamski", HomeID=3},
                new Resident{ FirstName="Jason",LastName="Godamski", HomeID=3},
                new Resident{ FirstName="Bruce",LastName="Lee", HomeID=4},
                new Resident{ FirstName="Jimmy",LastName="Johnston", HomeID=5},
                new Resident{ FirstName="Janet",LastName="Lilly", HomeID=6},
                new Resident{ FirstName="Sarah",LastName="Hastings", HomeID=8}
            };

            residents.ForEach(x => context.Residents.Add(x));
            context.SaveChanges();

            var graphics = new List<Graphic>
            {
                new Graphic{ HomeID=1, AltText="1978 Home", Photo="~/Content/Images/RTrailor1.jpg"},
                new Graphic{ HomeID=2, AltText="1982 Home", Photo="~/Content/Images/RTrailor1.jpg"},
                new Graphic{ HomeID=3, AltText="1983 Home", Photo="~/Content/Images/RTrailor1.jpg"},
                new Graphic{ HomeID=4, AltText="1985 Home", Photo="~/Content/Images/RTrailor1.jpg"},
                new Graphic{ HomeID=5, AltText="1978 Home", Photo="~/Content/Images/RTrailor1.jpg"},
                new Graphic{ HomeID=6, AltText="1988 Home", Photo="~/Content/Images/RTrailor1.jpg"},
                new Graphic{ HomeID=7, AltText="1984 Home", Photo="~/Content/Images/RTrailor1.jpg"},
                new Graphic{ HomeID=8, AltText="1977 Home", Photo="~/Content/Images/RTrailor1.jpg"},
            };

            graphics.ForEach(x => context.Graphics.Add(x));
            context.SaveChanges();
        }
    }
}