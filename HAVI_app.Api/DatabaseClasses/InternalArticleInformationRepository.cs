using HAVI_app.Api.DatabaseInterfaces;
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class InternalArticleInformationRepository : IInternalArticleInformationRepository
    {
        private readonly HAVIdatabaseContext _context;
        public InternalArticleInformationRepository(HAVIdatabaseContext context)
        {
            _context = context;
        }
        public async Task<InternalArticleInformation> AddInternalArticleInformation(InternalArticleInformation internalArticle)
        {
            var result = await _context.InternalArticleInformations.AddAsync(internalArticle);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async void DeleteInternalArticleInformationAsync(int internalArticleId)
        {
            var result = await _context.InternalArticleInformations.FirstOrDefaultAsync(s => s.Id == internalArticleId);
            if (result != null)
            {
                _context.InternalArticleInformations.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<InternalArticleInformation> GetInternalArticleInformation(int internalArticleId)
        {
            return await _context.InternalArticleInformations.FirstOrDefaultAsync(s => s.Id == internalArticleId);
        }

        public async Task<IEnumerable<InternalArticleInformation>> GetInternalArticleInformations()
        {
            return await _context.InternalArticleInformations.ToListAsync();
        }

        public async Task<InternalArticleInformation> UpdateInternalArticleInformation(InternalArticleInformation internalArticle)
        {
            var result = await _context.InternalArticleInformations.FirstOrDefaultAsync(s => s.Id == internalArticle.Id);
            if (result != null)
            {
                result.Bosnumber = internalArticle.Bosnumber;
                result.Carlanumber = internalArticle.Carlanumber;
                result.ClassificationCode = internalArticle.ClassificationCode;
                result.CompanyCode = internalArticle.CompanyCode;
                result.CurrencyRate = internalArticle.CurrencyRate;
                result.DepartmentId = internalArticle.DepartmentId;
                result.Eannumber = internalArticle.Eannumber;
                result.Grinnumber = internalArticle.Grinnumber;
                result.Gtinnumber = internalArticle.Gtinnumber;
                result.Iloscategory = internalArticle.Iloscategory;
                result.IlosorderPickGroup = internalArticle.IlosorderPickGroup;
                result.IlossortGroup = internalArticle.IlossortGroup;
                result.InnerPackingIlos = internalArticle.InnerPackingIlos;
                result.InsertBosSap = internalArticle.InsertBosSap;
                result.InsertEanSap = internalArticle.InsertEanSap;
                result.InsertGrinSap = internalArticle.InsertGrinSap;
                result.Lrinnumber = internalArticle.Lrinnumber;
                result.NewIlosarticleNumber = internalArticle.NewIlosarticleNumber;
                result.PackagingGroup = internalArticle.PackagingGroup;
                result.PriceInCountryCurrency = internalArticle.PriceInCountryCurrency;
                result.PrimaryDcIloscode = internalArticle.PrimaryDcIloscode;
                result.ReferenceIlosnumber = internalArticle.ReferenceIlosnumber;
                result.ReferenceSapmaterial = internalArticle.ReferenceSapmaterial;
                result.RegisterShelfLife = internalArticle.RegisterShelfLife;
                result.RemainShelfStore = internalArticle.RemainShelfStore;
                result.Sprnnumber = internalArticle.Sprnnumber;
                result.SupplierDeliveryUnit = internalArticle.SupplierDeliveryUnit;
                result.SupplierIdIlos = internalArticle.SupplierIdIlos;
                result.TextPurchaseNumber = internalArticle.TextPurchaseNumber;
                result.TransitTimeForHavi = internalArticle.TransitTimeForHavi;
                result.VatTaxcode = internalArticle.VatTaxcode;
                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}
