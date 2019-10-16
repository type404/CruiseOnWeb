namespace CruiseWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Rating
    {
        public int RatingId { get; set; }

        [Column("Rating")]
        [Display(Name = "Rating Star")]
        public int Rating1 { get; set; }

        public int BookingId { get; set; }
        [Display(Name = "Booking Id")]
        [ForeignKey("BookingId")]
       public virtual Booking Booking { get; set; }

        [Required]
        public string Comments { get; set; }
    }
}
