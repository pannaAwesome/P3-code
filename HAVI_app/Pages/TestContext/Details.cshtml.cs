using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HAVI_app.Models;

namespace HAVI_app.Pages.TestContext
{
    public class DetailsModel : PageModel
    {
        private readonly HAVI_app.Models.HAVIdatabaseContext _context;

        public DetailsModel(HAVI_app.Models.HAVIdatabaseContext context)
        {
            _context = context;
        }

        public Supplier Supplier { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Supplier = await _context.Suppliers
                .Include(s => s.Profile).FirstOrDefaultAsync(m => m.Id == id);

            if (Supplier == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
