using System;
using Microsoft.AspNetCore.Identity;
namespace PurchaseC.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public int ContactNo { get; set; }
        public string HomeAddress { get; set; }
        public string Country { get; set; }
        public string Citizenship { get; set; }
        public string Gender { get; set; }
    }
}