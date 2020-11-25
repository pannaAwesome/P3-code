using HAVI_app.Api.DatabaseInterfaces;
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class ILOSCategoryRepository : IILOSCategoryRepository
    {
        private readonly HAVIdatabaseContext _context;
        public ILOSCategoryRepository(HAVIdatabaseContext context)
        {
            _context = context;
        }
        public async Task<Iloscategory> AddILOSCategory(Iloscategory category)
        {
            var result = await _context.Iloscategories.AddAsync(category);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Iloscategory> DeleteILOSCategoryAsync(int categoryId)
        {
            var result = await _context.Iloscategories.FirstOrDefaultAsync(s => s.Id == categoryId);
            if (result != null)
            {
                _context.Iloscategories.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Iloscategory>> GetILOSCategories()
        {
            return await _context.Iloscategories.ToListAsync();
        }

        public async Task<Iloscategory> GetILOSCategory(int id)
        {
            return await _context.Iloscategories.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Iloscategory> UpdateILOSCategory(Iloscategory category)
        {
            var result = await _context.Iloscategories.FirstOrDefaultAsync(s => s.Id == category.Id);
            if (result != null)
            {
                result.Category = category.Category;
                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}
