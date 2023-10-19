using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AAS2237A1.Models
{
    public class VenueBaseViewModel : VenueAddViewModel
    {
        [Key]
        public int VenueId { get; set; }
    }
}