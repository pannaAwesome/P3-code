using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseInterfaces
{
    public interface IILOSCategoryRepository
    {
        Task<IEnumerable<Iloscategory>> GetILOSCategories();
        Task<Iloscategory> AddILOSCategory(Iloscategory iloscategory);
        Task<Iloscategory> UpdateILOSCategory(Iloscategory iloscategory);
        Task<Iloscategory> DeleteILOSCategoryAsync(int iloscategoryId);
    }
}
