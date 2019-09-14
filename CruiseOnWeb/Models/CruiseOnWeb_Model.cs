namespace CruiseOnWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CruiseOnWeb_Model : DbContext
    {
        public CruiseOnWeb_Model()
            : base("name=CruiseOnWeb_Model")
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Cruis> Cruises { get; set; }
        public virtual DbSet<Port> Ports { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cruis>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Cruis)
                .HasForeignKey(e => e.CId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Cruises)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UsId)
                .WillCascadeOnDelete(false);
        }
    }
}
