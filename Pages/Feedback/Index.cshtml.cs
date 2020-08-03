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
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly PurchaseC.Data.PurchaseCContext _context;

        public IndexModel(PurchaseC.Data.PurchaseCContext context)
        {
            _context = context;
        }

        public IList<FeedbackForm> FeedbackForm { get;set; }

        public async Task OnGetAsync()
        {
            FeedbackForm = await _context.FeedbackForm.ToListAsync();
        }
    }
}
