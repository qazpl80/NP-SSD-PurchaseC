using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace PurchaseC.Models
{
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; }

        [DisplayName("Date Created")]
        public DateTime CreatedDate { get; set; }

        [DisplayName("IP Address")]
        public string IPAddress { get; set; }
    }
}
