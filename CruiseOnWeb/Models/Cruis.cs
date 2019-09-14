namespace CruiseOnWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cruises")]
    public partial class Cruis
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cruis()
        {
            Bookings = new HashSet<Booking>();
        }

        [Key]
        public int CruiseId { get; set; }

        public int UsId { get; set; }

        [Required(ErrorMessage = "Please enter a cruise name.")]
        [Display(Name = "Cruise Name")]
        public string CruiseName { get; set; }

        [Required(ErrorMessage = "Please enter the departure port name.")]
        [Display(Name = "Departure Port Name")]
        public string CruiseDepPortName { get; set; }

        [Required(ErrorMessage = "Please enter the arrival port name.")]
        [Display(Name = "Arrival Port Name")]
        public string CruiseArrPortName { get; set; }

        [Required(ErrorMessage = "Please enter the cost.")]
        [Display(Name = "Cost")]
        public int Cost { get; set; }

        [Required(ErrorMessage = "Please enter the cruise stay duration.")]
        [Display(Name = "Duration")]
        public int Duration { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual User User { get; set; }
    }
}
