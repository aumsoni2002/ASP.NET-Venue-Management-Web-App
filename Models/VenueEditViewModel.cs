using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;

namespace AAS2237A1.Models
{
    public class VenueEditViewModel
    {
        [Key]
        public int VenueId { get; set; }

        [StringLength(70)]
        public string Address { get; set; }

        [StringLength(40)]
        public string City { get; set; }

        [StringLength(40)]
        public string State { get; set; }

        [StringLength(40)]
        public string Country { get; set; }

        [StringLength(10)]
        [Display(Name = "Postal Code")]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        [StringLength(24)]
        public string Fax { get; set; }

        [StringLength(60)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(60)]
        [DataType(DataType.Url)]
        public string Website { get; set; }

        [Display(Name = "Date Opened")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? OpenDate { get; set; }


        // below should not get saved in the database
        [DataType(DataType.Password)]
        [Display(Name = "Advance Ticket Sale Password")]
        public string TicketSalePassword { get; set; }

        [RegularExpression("[A-Z]{2}\\d{3}", ErrorMessage = "must contain the format “LLNNN” where “L” represents a capital letter and “N” represents a number (0-9)")]
        [Display(Name = "Promo Code")]
        public string PromoCode { get; set; }

        [Range(1, 1000, ErrorMessage ="Capacity must range from 1 to 1000")]
        public int Capacity { get; set; }
    }
}