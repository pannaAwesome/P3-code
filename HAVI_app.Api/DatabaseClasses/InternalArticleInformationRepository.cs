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

        public async Task<InternalArticleInformation> DeleteInternalArticleInformationAsync(int internalArticleId)
        {
            var result = await _context.InternalArticleInformations.FirstOrDefaultAsync(s => s.Id == internalArticleId);
            if (result != null)
            {
                _context.InternalArticleInformations.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<InternalArticleInformation> GetInternalArticleInformation(int internalArticleId)
        {
            return await _context.InternalArticleInformations
                                        .Include(i => i.Sapplants)
                                        .Include(i => i.Bundles)
                                        .Include(i => i.Qips)
                                        .FirstOrDefaultAsync(s => s.Id == internalArticleId);
        }

        public async Task<IEnumerable<InternalArticleInformation>> GetInternalArticleInformations()
        {
            return await _context.InternalArticleInformations
                                        .Include(i => i.Sapplants)
                                        .Include(i => i.Bundles)
                                        .Include(i => i.Qips)
                                        .ToListAsync();
        }

        public async Task<InternalArticleInformation> UpdateInternalArticleInformation(InternalArticleInformation internalArticle)
        {
            var resultInternalArticleInformation = await _context.InternalArticleInformations
                                                        .Include(s => s.Sapplants)
                                                        .Include(q => q.Qips)
                                                        .Include(b => b.Bundles)
                                                        .FirstOrDefaultAsync(s => s.Id == internalArticle.Id);
            

            if (resultInternalArticleInformation != null)
            {
                resultInternalArticleInformation.Bosnumber = internalArticle.Bosnumber;
                resultInternalArticleInformation.Carlanumber = internalArticle.Carlanumber;
                resultInternalArticleInformation.ClassificationCode = internalArticle.ClassificationCode;
                resultInternalArticleInformation.CompanyCode = internalArticle.CompanyCode;
                resultInternalArticleInformation.CurrencyRate = internalArticle.CurrencyRate;
                resultInternalArticleInformation.DepartmentId = internalArticle.DepartmentId;
                resultInternalArticleInformation.Eannumber = internalArticle.Eannumber;
                resultInternalArticleInformation.Grinnumber = internalArticle.Grinnumber;
                resultInternalArticleInformation.Gtinnumber = internalArticle.Gtinnumber;
                resultInternalArticleInformation.Iloscategory = internalArticle.Iloscategory;
                resultInternalArticleInformation.IlosorderPickGroup = internalArticle.IlosorderPickGroup;
                resultInternalArticleInformation.IlossortGroup = internalArticle.IlossortGroup;
                resultInternalArticleInformation.InnerPackingIlos = internalArticle.InnerPackingIlos;
                resultInternalArticleInformation.InsertBosSap = internalArticle.InsertBosSap;
                resultInternalArticleInformation.InsertEanSap = internalArticle.InsertEanSap;
                resultInternalArticleInformation.InsertGrinSap = internalArticle.InsertGrinSap;
                resultInternalArticleInformation.Lrinnumber = internalArticle.Lrinnumber;
                resultInternalArticleInformation.NewIlosarticleNumber = internalArticle.NewIlosarticleNumber;
                resultInternalArticleInformation.PackagingGroup = internalArticle.PackagingGroup;
                resultInternalArticleInformation.PriceInCountryCurrency = internalArticle.PriceInCountryCurrency;
                resultInternalArticleInformation.PrimaryDcIloscode = internalArticle.PrimaryDcIloscode;
                resultInternalArticleInformation.ReferenceIlosnumber = internalArticle.ReferenceIlosnumber;
                resultInternalArticleInformation.ReferenceSapmaterial = internalArticle.ReferenceSapmaterial;
                resultInternalArticleInformation.RegisterShelfLife = internalArticle.RegisterShelfLife;
                resultInternalArticleInformation.RemainShelfStore = internalArticle.RemainShelfStore;
                resultInternalArticleInformation.Sprnnumber = internalArticle.Sprnnumber;
                resultInternalArticleInformation.SupplierDeliveryUnit = internalArticle.SupplierDeliveryUnit;
                resultInternalArticleInformation.SupplierIdIlos = internalArticle.SupplierIdIlos;
                resultInternalArticleInformation.TextPurchaseNumber = internalArticle.TextPurchaseNumber;
                resultInternalArticleInformation.TransitTimeForHavi = internalArticle.TransitTimeForHavi;
                resultInternalArticleInformation.VatTaxcode = internalArticle.VatTaxcode;
                await _context.SaveChangesAsync();

                foreach(Sapplant plant in resultInternalArticleInformation.Sapplants)
                {
                    var resultPlant = await _context.Sapplants.FirstOrDefaultAsync(s => s.Id == plant.Id);
                    resultPlant.SapplantName = plant.SapplantName;
                    resultPlant.SapplantValue = plant.SapplantValue;
                    await _context.SaveChangesAsync();
                }

                foreach(Qip qip in resultInternalArticleInformation.Qips)
                {
                    var resultQIP = await _context.Qips.FirstOrDefaultAsync(q => q.Id == qip.Id);
                    resultQIP.QipanswerOptions = qip.QipanswerOptions;
                    resultQIP.Qipdescription = qip.Qipdescription;
                    resultQIP.Qipfrequency = qip.Qipfrequency;
                    resultQIP.QipfrequencyType = qip.QipfrequencyType;
                    resultQIP.QiphighBoundary = qip.QiphighBoundary;
                    resultQIP.QiplowBoundary = qip.QiplowBoundary;
                    resultQIP.QipnameNumber = qip.QipnameNumber;
                    resultQIP.Qipokvalue = qip.Qipokvalue;
                    resultQIP.QipsetAnswer = qip.QipsetAnswer;
                    await _context.SaveChangesAsync();
                }

                foreach (Bundle bundle in resultInternalArticleInformation.Bundles)
                {
                    var resultBundle = await _context.Bundles.FirstOrDefaultAsync(b => b.Id == bundle.Id);
                    resultBundle.ArticleBundle = bundle.ArticleBundle;
                    resultBundle.ArticleBundleQuantity = bundle.ArticleBundleQuantity;
                    await _context.SaveChangesAsync();
                }
                return resultInternalArticleInformation;
            }

            return null;
        }
    }
}
