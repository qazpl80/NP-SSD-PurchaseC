using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        private readonly IWebHostEnvironment _hostingEnvironment;

        public DetailsModel(PurchaseC.Data.PurchaseCContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _hostingEnvironment = environment;
        }

        public Computer Computer { get; set; }
        public string imgfile { get; set; }

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
            if (Computer.Images != null)//_hostingEnvironment.WebRootPath,
            {
                var fileName = Computer.Images;
                var uploads = Path.Combine("\\uploads\\");
                var file = Path.Combine(uploads, fileName);
                imgfile = file;
            }
            return Page();
        }
        
    }
}
