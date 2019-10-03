namespace CruiseWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Profile
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your country of residence.")]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [StringLength(128)]
        public string ProfileId { get; set; }
    }
}
