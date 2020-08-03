using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class IndexModel : PageModel
    {
        private readonly PurchaseC.Data.PurchaseCContext _context;

        public IndexModel(PurchaseC.Data.PurchaseCContext context)
        {
            _context = context;
        }

        public IList<Computer> Computer { get; set; }
        [BindProperty(SupportsGet = true)]

        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Entered Text contain Invalid characters")]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        //public SelectList Genres { get; set; }
        //[BindProperty(SupportsGet = true)]
        //public string MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            var computers = from c in _context.Computer
                            select c;
            if (!string.IsNullOrEmpty(SearchString))
            {
                computers = computers.Where(s => s.Name.Contains(SearchString));
            }

            Computer = await computers.ToListAsync();
        }
    }
}
