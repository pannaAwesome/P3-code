using HAVI_app.Api.DatabaseInterfaces;
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class ArticleBundleRepository : IArticleBundleRepository
    {
        private readonly HAVIdatabaseContext _context;
        public ArticleBundleRepository(HAVIdatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ArticleBundle>> GetArticleBundles()
        {
            return await _context.ArticleBundles.ToListAsync();
        }
    }
}
