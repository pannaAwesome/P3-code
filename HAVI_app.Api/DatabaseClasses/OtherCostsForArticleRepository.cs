using HAVI_app.Api.DatabaseInterfaces;
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class OtherCostsForArticleRepository : IOtherCostsForArticleRepository
    {
        private readonly HAVIdatabaseContext _context;
        public OtherCostsForArticleRepository(HAVIdatabaseContext context)
        {
            _context = context;
        }
        public async Task<OtherCostsForArticle> AddOtherCostsForArticle(OtherCostsForArticle otherCost)
        {
            var result = await _context.OtherCostsForArticles.AddAsync(otherCost);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<OtherCostsForArticle> DeleteOtherCostsForArticleAsync(int otherCostId)
        {
            var result = await _context.OtherCostsForArticles.FirstOrDefaultAsync(s => s.Id == otherCostId);
            if (result != null)
            {
                _context.OtherCostsForArticles.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<OtherCostsForArticle> GetOtherCostsForArticle(int otherCostId)
        {
            return await _context.OtherCostsForArticles.FirstOrDefaultAsync(s => s.Id == otherCostId);
        }

        public async Task<IEnumerable<OtherCostsForArticle>> GetOtherCostsForArticles()
        {
            return await _context.OtherCostsForArticles.ToListAsync();
        }

        public async Task<OtherCostsForArticle> UpdateOtherCostsForArticle(OtherCostsForArticle otherCost)
        {
            var result = await _context.OtherCostsForArticles.FirstOrDefaultAsync(s => s.Id == otherCost.Id);
            if (result != null)
            {
                result.Amount = otherCost.Amount;
                result.InformCostType = otherCost.InformCostType;
                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}
