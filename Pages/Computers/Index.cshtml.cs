using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PurchaseC.Data;
using PurchaseC.Models;

namespace PurchaseC.Pages.Computers
{
    public class IndexModel : PageModel
    {
        private readonly PurchaseC.Data.PurchaseCContext _context;

        public IndexModel(PurchaseC.Data.PurchaseCContext context)
        {
            _context = context;
        }

        public IList<Computer> Computer { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        

        public async Task OnGetAsync()
        {
            var computers = from m in _context.Computer
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                computers = computers.Where(s => s.Name.Contains(SearchString));
            }

            Computer = await _context.Computer.ToListAsync();
        }
    }
}
