namespace CruiseWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Booking
    {
        public int BookingId { get; set; }

        [Required]
        [StringLength(256)]
        public string Username { get; set; }

        [Required]
        [StringLength(256)]
        public string CruiseName { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        public int NumberOfPeople { get; set; }

        public double TotalPrice { get; set; }
    }
}
