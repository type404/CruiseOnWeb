namespace CruiseWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cruises")]
    public partial class Cruis
    {
        [Key]
        public int CruiseId { get; set; }

        [StringLength(256)]
        [Required(ErrorMessage = "Please enter a cruise name.")]
        [Display(Name = "Cruise Name")]
        public string CruiseName { get; set; }

        [Required(ErrorMessage = "Please enter the departure port name.")]
        [Display(Name = "Departure Port Name")]
        public string CruiseDepPortName { get; set; }

        [Required(ErrorMessage = "Please enter the arrival port name.")]
        [Display(Name = "Arrival Port Name")]
        public string CruiseArrPortName { get; set; }

        [Required(ErrorMessage = "Please enter the cost per night.")]
        [Display(Name = "Cost")]
        [Range(0,1000, ErrorMessage ="Cost limit per night should be 0 to 1000.")]
        public double CostPerNight { get; set; }

        [Required(ErrorMessage = "Please enter the cruise duration.")]
        [Display(Name = "Duration")]
        [Range(1, 10, ErrorMessage = "Cruise duration should be between 1 - 10 days.")]
        public int Duration { get; set; }
    }
}
