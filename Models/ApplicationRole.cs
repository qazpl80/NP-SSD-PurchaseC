using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PurchaseC.Models
{
    public class ApplicationRole : IdentityRole
    {
        [RegularExpression(@"[a-zA-Z0-9]*", ErrorMessage = "Description should contain alphabets and numbers only")]
        public string Description { get; set; }

        [DisplayName("Date Created")]
        public DateTime CreatedDate { get; set; }

        [DisplayName("IP Address")]
        public string IPAddress { get; set; }
    }
}
