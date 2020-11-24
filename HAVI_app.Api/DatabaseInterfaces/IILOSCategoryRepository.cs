using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseInterfaces
{
    public interface IILOSCategoryRepository
    {
        Task<IEnumerable<Iloscategory>> GetIloscategories();
        Task<Iloscategory> AddIloscategory(Iloscategory iloscategory);
        Task<Iloscategory> UpdateIloscategory(Iloscategory iloscategory);
        void DeleteIloscategoryAsync(int iloscategoryId);
    }
}
