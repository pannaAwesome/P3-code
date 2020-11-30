
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class BundleRepository
    {
        private readonly HAVIdatabaseContext _context;
        public BundleRepository(HAVIdatabaseContext context)
        {
            _context = context;
        }
        public async Task<Bundle> AddBundle(Bundle bundle)
        {
            var result = await _context.Bundles.AddAsync(bundle);
            await _context.SaveChangesAsync();

            return result.Entity;
        }


        public async Task<Bundle> GetBundle(int bundleId)
        {
            return await _context.Bundles.FirstOrDefaultAsync(s => s.Id == bundleId);
        }

        public async Task<IEnumerable<Bundle>> GetBundles()
        {
            return await _context.Bundles.ToListAsync();
        }

        public async Task<Bundle> UpdateBundle(Bundle bundle)
        {
            var result = await _context.Bundles.FirstOrDefaultAsync(s => s.Id == bundle.Id);
            if (result != null)
            {
                result.ArticleBundle = bundle.ArticleBundle;
                result.ArticleBundleQuantity = bundle.ArticleBundleQuantity;
                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}
