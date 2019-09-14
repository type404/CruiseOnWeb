namespace CruiseOnWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Booking
    {
        public int BookingId { get; set; }

        public int UsId { get; set; }

        public int CId { get; set; }

        [Column(TypeName = "date")]
        [Required(ErrorMessage = "Please enter a valid start date")]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        [Required(ErrorMessage = "Please enter a valid end date")]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Please enter the number of people")]
        [Display(Name = "Number of people")]
        public int NumberOfPeople { get; set; }

        [Display(Name = "Total Price")]
        public int TotalPrice { get; set; }

        public virtual Cruis Cruis { get; set; }

        public virtual User User { get; set; }
    }
}
