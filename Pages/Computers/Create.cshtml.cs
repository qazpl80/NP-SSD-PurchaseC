using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PurchaseC.Data;
using PurchaseC.Models;

namespace PurchaseC.Pages.Computers
{
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
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
