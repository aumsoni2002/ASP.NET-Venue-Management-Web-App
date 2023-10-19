using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AAS2237A1.Models
{
    public class VenueEditFormViewModel : VenueEditViewModel
    {
        [Required]
        [StringLength(80)]
        public string Company { get; set; }
    }
}