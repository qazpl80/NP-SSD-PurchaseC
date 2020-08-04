using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;
namespace PurchaseC.Models
{
    public class ApplicationUser : IdentityUser
    {
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }

        [DisplayName("Contact Number")]
        public int ContactNo { get; set; }

        [DisplayName("Home Address")]
        public string HomeAddress { get; set; }

        public string Country { get; set; }

        public string Citizenship { get; set; }

        public string Gender { get; set; }
    }
}