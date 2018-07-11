using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContactsApplication.Models
{
    /// <summary>
    /// Contact view model properties
    /// </summary>
    public class ContactViewModel 
    {
        [Key]
        public int ContactID { get; set; }

        [Display(Name = "First Name")]
        [StringLength(20)]
        [Required(ErrorMessage = "The first name is required.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(20)]
        [Required(ErrorMessage = "The last name is required.")]
        public string LastName { get; set; }

        [Display(Name = "Email ID")]
        [Required(ErrorMessage = "The email id is required.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email ID is not valid.")]
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "Email ID is not valid")]
        public string EmailID { get; set; }

        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "You must provide a mobile number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Not a valid mobile number")]
        public string MobileNumber { get; set; }

        [Display(Name = "Active/Inactive")]
        [Required(ErrorMessage = "Please select status.")]
        public bool Status { get; set; }
    }
}