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
    public class IndexModel : PageModel
    {
        private readonly HAVI_app.Models.HAVIdatabaseContext _context;

        public IndexModel(HAVI_app.Models.HAVIdatabaseContext context)
        {
            _context = context;
        }

        public IList<Supplier> Supplier { get;set; }

        public async Task OnGetAsync()
        {
            Supplier = await _context.Suppliers
                .Include(s => s.Profile).ToListAsync();
        }
    }
}
