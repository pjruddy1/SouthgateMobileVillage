using SouthgateMobileVillage.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SouthgateMobileVillage.DAL
{
    public class ResidentContext : DbContext
    {

        public ResidentContext() : base("ResidentContext")
        {
        }

        public DbSet<Resident> Residents { get; set; }
        public DbSet<Graphic> Graphics { get; set; }
        public DbSet<Home> Homes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}