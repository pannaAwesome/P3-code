using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HAVI_app.Data;
using HAVI_app.Models;

namespace HAVI_app.Pages.Contexts
{
    public class IndexModel : PageModel
    {
        private readonly HAVI_app.Data.ArticleContext _context;

        public IndexModel(HAVI_app.Data.ArticleContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; }

        public async Task OnGetAsync()
        {
            Article = await _context.Articles
                .Include(a => a.ArticleInformation)
                .Include(a => a.Country)
                .Include(a => a.InternalArticleInformation)
                .Include(a => a.Purchaser)
                .Include(a => a.Supplier).ToListAsync();
        }
    }
}
