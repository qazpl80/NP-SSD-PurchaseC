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

namespace PurchaseC.Pages.Computers
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly PurchaseC.Data.PurchaseCContext _context;

        public DetailsModel(PurchaseC.Data.PurchaseCContext context)
        {
            _context = context;
        }

        public Computer Computer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Computer = await _context.Computer.FirstOrDefaultAsync(m => m.ID == id);

            if (Computer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
