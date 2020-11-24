using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseInterfaces
{
    public interface IPurchaserRepository
    {
        Task<IEnumerable<Purchaser>> GetPurchasers();
        Task<Purchaser> GetPurchaser(int purchaserId);
        Task<Purchaser> AddPurchaser(Purchaser purchaser);
        Task<Purchaser> UpdatePurchaser(Purchaser purchaser);
        void DeletePurchaserAsync(int purchaserId);
    }
}