using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PurchaseC.Data;
using PurchaseC.Models;
using Microsoft.AspNetCore.Authorization;

namespace PurchaseC.Pages.Computers
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly PurchaseC.Data.PurchaseCContext _context;

        public CreateModel(PurchaseC.Data.PurchaseCContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Computer Computer { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Computer.Add(Computer);
            if (await _context.SaveChangesAsync() > 0)
            {
                var auditrecord = new AuditRecord();
                auditrecord.AuditActionType = "Created Computer Record";
                auditrecord.DateTimeStamp = DateTime.Now;
                auditrecord.ComputerID = Computer.ID;
                var userID = User.Identity.Name.ToString();
                auditrecord.Username = userID;
                _context.AuditRecords.Add(auditrecord);
                await _context.SaveChangesAsync();
            }


            return RedirectToPage("./Index");
        }
    }
}
