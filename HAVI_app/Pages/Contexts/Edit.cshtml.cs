using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HAVI_app.Data;
using HAVI_app.Models;

namespace HAVI_app.Pages.Contexts
{
    public class EditModel : PageModel
    {
        private readonly HAVI_app.Data.ArticleContext _context;

        public EditModel(HAVI_app.Data.ArticleContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Article Article { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Article = await _context.Articles
                .Include(a => a.ArticleInformation)
                .Include(a => a.Country)
                .Include(a => a.InternalArticleInformation)
                .Include(a => a.Purchaser)
                .Include(a => a.Supplier).FirstOrDefaultAsync(m => m.ID == id);

            if (Article == null)
            {
                return NotFound();
            }
           ViewData["ArticleInformationID"] = new SelectList(_context.Set<ArticleInformation>(), "ID", "ID");
           ViewData["CountryID"] = new SelectList(_context.Set<Country>(), "ID", "ID");
           ViewData["InternalArticleInformationID"] = new SelectList(_context.Set<InternalArticleInformation>(), "ID", "ID");
           ViewData["PurchaserID"] = new SelectList(_context.Set<Purchaser>(), "ID", "ID");
           ViewData["SupplierID"] = new SelectList(_context.Set<Supplier>(), "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Article).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(Article.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.ID == id);
        }
    }
}
