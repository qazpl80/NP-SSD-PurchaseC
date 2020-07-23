using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PurchaseC.Data;
using PurchaseC.Models;

namespace PurchaseC.Pages.Feedback
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly PurchaseC.Data.PurchaseCContext _context;

        public DeleteModel(PurchaseC.Data.PurchaseCContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FeedbackForm FeedbackForm { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FeedbackForm = await _context.FeedbackForm.FirstOrDefaultAsync(m => m.ID == id);

            if (FeedbackForm == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FeedbackForm = await _context.FeedbackForm.FindAsync(id);

            if (FeedbackForm != null)
            {
                _context.FeedbackForm.Remove(FeedbackForm);
                if (await _context.SaveChangesAsync() > 0)
                {
                    var auditrecord = new AuditRecord();
                    auditrecord.AuditActionType = "Feedback Form Deleted";
                    auditrecord.DateTimeStamp = DateTime.Now;
                    auditrecord.ComputerID = FeedbackForm.ID;
                    var userID = User.Identity.Name.ToString();
                    auditrecord.Username = userID;
                    _context.AuditRecords.Add(auditrecord);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
