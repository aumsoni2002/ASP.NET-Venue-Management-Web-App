using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AAS2237A1.Models
{
    public class VenueAddViewModel
    {
        public VenueAddViewModel()
        {
            OpenDate = DateTime.Now.AddYears(-23);
        }

        [Required]
        [StringLength(80)]
        public string Company { get; set; }

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

        [Display(Name = "Years Old")]
        public string YearsOld
        {
            get
            {
                if (OpenDate.HasValue)
                {
                    var age = Math.Floor((DateTime.Now - OpenDate.Value).TotalDays / 365.0);
                    if (age < 1.0)
                    {
                        return "Recently opened";
                    }
                    else
                    {
                        return $"{age:n0} years old";
                    }
                }
                else
                {
                    return null;
                }
            }
        }
    }

}