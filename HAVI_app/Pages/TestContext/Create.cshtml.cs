using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HAVI_app.Models;

namespace HAVI_app.Pages.TestContext
{
    public class CreateModel : PageModel
    {
        private readonly HAVI_app.Models.HAVIdatabaseContext _context;

        public CreateModel(HAVI_app.Models.HAVIdatabaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ProfileId"] = new SelectList(_context.Profiles, "Id", "Password");
            return Page();
        }

        [BindProperty]
        public Supplier Supplier { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Suppliers.Add(Supplier);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
