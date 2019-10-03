namespace CruiseWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Cruise_Models : DbContext
    {
        public Cruise_Models()
            : base("name=Cruise_Models")
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Cruis> Cruises { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
