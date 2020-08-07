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
using Microsoft.AspNetCore.Mvc.Rendering;
using PurchaseC.Data;
using PurchaseC.Models;



namespace PurchaseC.Pages.Computers
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly PurchaseC.Data.PurchaseCContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public CreateModel(PurchaseC.Data.PurchaseCContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _hostingEnvironment = environment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Computer Computer { get; set; }
        public IFormFile ComputerImages { get; set; }
        
        

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (ComputerImages != null)
            {
                var fileName = GetUniqueName(ComputerImages.FileName);
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                var filePath = Path.Combine(uploads, fileName);
                ComputerImages.CopyTo(new FileStream(filePath, FileMode.Create));
                Computer.Images = fileName; // Set the file name
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
        private string GetUniqueName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                   + "_" + Guid.NewGuid().ToString().Substring(0, 4)
                   + Path.GetExtension(fileName);
        }
    }
}
