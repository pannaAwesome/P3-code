using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseInterfaces
{
    public interface IOtherCostsForArticleRepository
    {
        Task<IEnumerable<OtherCostsForArticle>> GetOtherCostsForArticles();
        Task<OtherCostsForArticle> GetOtherCostsForArticle(int otherCostsForArticleId);
        Task<OtherCostsForArticle> AddOtherCostsForArticle(OtherCostsForArticle otherCostsForArticle);
        Task<OtherCostsForArticle> UpdateOtherCostsForArticle(OtherCostsForArticle otherCostsForArticle);
        void DeleteOtherCostsForArticleAsync(int otherCostsForArticleId);
    }
}