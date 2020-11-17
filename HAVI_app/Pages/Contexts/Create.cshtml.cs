using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HAVI_app.Data;
using HAVI_app.Models;

namespace HAVI_app.Pages.Contexts
{
    public class CreateModel : PageModel
    {
        private readonly HAVI_app.Data.ArticleContext _context;

        public CreateModel(HAVI_app.Data.ArticleContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ArticleInformationID"] = new SelectList(_context.Set<ArticleInformation>(), "ID", "ID");
        ViewData["CountryID"] = new SelectList(_context.Set<Country>(), "ID", "ID");
        ViewData["InternalArticleInformationID"] = new SelectList(_context.Set<InternalArticleInformation>(), "ID", "ID");
        ViewData["PurchaserID"] = new SelectList(_context.Set<Purchaser>(), "ID", "ID");
        ViewData["SupplierID"] = new SelectList(_context.Set<Supplier>(), "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Article Article { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Articles.Add(Article);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
