﻿using PurchaseC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PurchaseC.Data
{
    public class PurchaseCContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public PurchaseCContext (DbContextOptions<PurchaseCContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }


        public DbSet<PurchaseC.Models.Computer> Computer { get; set; }
        public DbSet<PurchaseC.Models.AuditRecord> AuditRecords { get; set; }
        public DbSet<PurchaseC.Models.FeedbackForm> FeedbackForm { get; set; }
    }
}
