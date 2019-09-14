namespace CruiseOnWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Port
    {
        [Key]
        public int PId { get; set; }

        [Required(ErrorMessage = "Please enter the port name.")]
        [Display(Name = "Port Name")]
        public string PortName { get; set; }

        [Required(ErrorMessage = "Please enter the port latitude.")]
        [Display(Name = "Port Latitude")]
        public double PortLati { get; set; }

        [Required(ErrorMessage = "Please enter the port longitude.")]
        [Display(Name = "Port Longitude")]
        public double PortLongi { get; set; }

        [Required(ErrorMessage = "Please enter the port longitude.")]
        [Display(Name = "Port Country")]
        public string PortCountry { get; set; }
    }
}
