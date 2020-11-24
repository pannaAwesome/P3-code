using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseInterfaces
{
    public interface IVatTaxCodeRepository
    {
        Task<IEnumerable<VatTaxCode>> GetVatTaxCodes();
        Task<VatTaxCode> AddVatTaxCode(VatTaxCode vatTaxCode);
        Task<VatTaxCode> UpdateVatTaxCode(VatTaxCode vatTaxCode);
        Task<VatTaxCode> DeleteVatTaxCodeAsync(int vatTaxCodeId);
    }
}
