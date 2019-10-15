namespace CruiseWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Microsoft.AspNet.Identity;

    public partial class Booking
    {
        public int BookingId { get; set; }

        public string Username { get; set; }
        
        [Required(ErrorMessage = "Please enter a cruise name.")]
        [StringLength(256)]
        public string CruiseName { get; set; }

        [Required(ErrorMessage = "Please enter start date.")]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

/*        [Required(ErrorMessage = "Please enter end date.")]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]*/
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Please enter the total number of people.")]
        [Range(1, 100, ErrorMessage = "Please select the number of people between 1-100.")]
        public int NumberOfPeople { get; set; }

/*        [Required]
        [Range(0, 100000, ErrorMessage = "Invalid price")]*/
        public double TotalPrice { get; set; }

    }
}
