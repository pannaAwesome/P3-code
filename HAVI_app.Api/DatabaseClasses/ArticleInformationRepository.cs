
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class ArticleInformationRepository
    {
        private readonly HAVIdatabaseContext _context;
        public ArticleInformationRepository(HAVIdatabaseContext context)
        {
            _context = context;
        }
        public async Task<ArticleInformation> AddArticleInformation(ArticleInformation articleInformation)
        {
            var result = await _context.ArticleInformations.AddAsync(articleInformation);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<ArticleInformation> GetArticleInformation(int articleInformationId)
        {
            return await _context.ArticleInformations.Include(a => a.OtherCostsForArticles)
                                                     .FirstOrDefaultAsync(a => a.Id == articleInformationId);
        }

        public async Task<IEnumerable<ArticleInformation>> GetArticleInformations()
        {
            return await _context.ArticleInformations.Include(a => a.OtherCostsForArticles).ToListAsync();
        }

        public async Task<ArticleInformation> UpdateArticleInformation(ArticleInformation articleInformation)
        {
            var result = await _context.ArticleInformations.Include(a => a.OtherCostsForArticles)
                                                           .FirstOrDefaultAsync(a => a.Id == articleInformation.Id);
            if (result != null)
            {
                result.CompanyLocation = articleInformation.CompanyLocation;
                result.CompanyName = articleInformation.CompanyName;
                result.FreightResponsibility = articleInformation.FreightResponsibility;
                result.PalletExchange = articleInformation.PalletExchange;
                result.ArticlesPerSalesunit = articleInformation.ArticlesPerSalesunit;
                result.CartonsPerLayer = articleInformation.CartonsPerLayer;
                result.CartonsPerPallet = articleInformation.CartonsPerPallet;
                result.Class = articleInformation.Class;
                result.ClassificationCode = articleInformation.ClassificationCode;
                result.CountryOfOrigin = articleInformation.CountryOfOrigin;
                result.DangerousGoods = articleInformation.DangerousGoods;
                result.Email = articleInformation.Email;
                result.GrossWeightPrSalesunit = articleInformation.GrossWeightPrSalesunit;
                result.Gtinnumber = articleInformation.Gtinnumber;
                result.HeightPrSalesunit = articleInformation.HeightPrSalesunit;
                result.ImportedFrom = articleInformation.ImportedFrom;
                result.LeadTime = articleInformation.LeadTime;
                result.LengthPrSalesunit = articleInformation.LengthPrSalesunit;
                result.MinimumOrderQuantity = articleInformation.MinimumOrderQuantity;
                result.MinimumShelflife = articleInformation.MinimumShelflife;
                result.NetWeightPrSalesunit = articleInformation.NetWeightPrSalesunit;
                result.OrganicArticle = articleInformation.OrganicArticle;
                result.OtherCosts = articleInformation.OtherCosts;
                result.PurchasePrice = articleInformation.PurchasePrice;
                result.Salesunit = articleInformation.Salesunit;
                result.SetCurrency = articleInformation.SetCurrency;
                result.Shelflife = articleInformation.Shelflife;
                result.SpecialInformation = articleInformation.SpecialInformation;
                result.SupplierArticleName = articleInformation.SupplierArticleName;
                result.ArticleName = articleInformation.ArticleName;
                result.TemperatureStorageMax = articleInformation.TemperatureStorageMax;
                result.TemperatureStorageMin = articleInformation.TemperatureStorageMin;
                result.TemperatureTransportationMax = articleInformation.TemperatureTransportationMax;
                result.TemperatureTransportationMin = articleInformation.TemperatureTransportationMin;
                result.TollTarifNumber = articleInformation.TollTarifNumber;
                result.TransitTime = articleInformation.TransitTime;
                result.TransportBooking = articleInformation.TransportBooking;
                result.WidthPrSalesunit = articleInformation.WidthPrSalesunit;
                await _context.SaveChangesAsync();

                foreach(OtherCostsForArticle cost in articleInformation.OtherCostsForArticles)
                {
                    var resultCost = await _context.OtherCostsForArticles.FirstOrDefaultAsync(c => c.Id == cost.Id);

                    if(resultCost != null)
                    {
                        resultCost.Amount = cost.Amount;
                        resultCost.InformCostType = cost.InformCostType;
                    }
                    else
                    {
                        await _context.OtherCostsForArticles.AddAsync(cost);
                    }
                    await _context.SaveChangesAsync();
                }

                return result;
            }

            return null;
        }
    }
}
