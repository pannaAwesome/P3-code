
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class ArticleRepository
    {
        private readonly HAVIdatabaseContext _context;
        public ArticleRepository(HAVIdatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Article>> GetArticlesWithCertainState(int state, int countryId)
        {
            return await _context.Articles
                                 .Where(a => a.ArticleState == state && a.CountryId == countryId)
                                 .Include(a => a.Purchaser).ThenInclude(p => p.Profile)
                                 .Include(a => a.ArticleInformation)
                                 .Include(a => a.InternalArticleInformation)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Article>> GetArticlesForCountry(int countryId)
        {
            return await _context.Articles
                                 .Where(a => a.CountryId == countryId)
                                 .Include(a => a.Purchaser).ThenInclude(p => p.Profile)
                                 .Include(a => a.ArticleInformation)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Article>> GetArticlesForSupplier(int supplierId)
        {
            return await _context.Articles
                                 .Where(a => a.SupplierId == supplierId)
                                 .Include(a => a.Purchaser).ThenInclude(p => p.Profile)
                                 .Include(a => a.ArticleInformation)
                                 .ToListAsync();
        }

        public async Task<Article> GetArticle(int articleId)
        {
            return await _context.Articles.Include(a => a.InternalArticleInformation)
                                          .Include(a => a.ArticleInformation).ThenInclude(a => a.OtherCostsForArticles)
                                          .FirstOrDefaultAsync(s => s.Id == articleId);
        }

        public async Task<Article> AddArticle(Article article)
        {
            await _context.ArticleInformations.AddAsync(article.ArticleInformation);
            await _context.SaveChangesAsync();

            await _context.InternalArticleInformations.AddAsync(article.InternalArticleInformation);
            await _context.SaveChangesAsync();

            var result = await _context.Articles.AddAsync(article);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Article> DeleteArticleAsync(int articleId)
        {
            var article = await _context.Articles.FirstOrDefaultAsync(s => s.Id == articleId);
            var internalInfo = await _context.InternalArticleInformations.FirstOrDefaultAsync(i => i.Id == article.InternalArticleInformationId);
            var articleInfo = await _context.ArticleInformations.FirstOrDefaultAsync(a => a.Id == article.ArticleInformationId);

            if (article != null && internalInfo != null && articleInfo != null)
            {
                _context.Articles.Remove(article);
                await _context.SaveChangesAsync();

                _context.ArticleInformations.Remove(articleInfo);
                await _context.SaveChangesAsync();

                _context.InternalArticleInformations.Remove(internalInfo);
                await _context.SaveChangesAsync();

                return article;
            }
            return null;
        }

        public async Task<IEnumerable<Article>> GetArticles()
        {
            return await _context.Articles.Include(a => a.Purchaser).ThenInclude(p => p.Profile)
                                          .Include(a => a.InternalArticleInformation)
                                          .Include(a => a.ArticleInformation)
                                          .ToListAsync();
        }

        public async Task<Article> UpdateArticle(Article article)
        {
            var result = await _context.Articles.FirstOrDefaultAsync(s => s.Id == article.Id);
            if (result != null)
            {
                result.ArticleInformationCompleted = article.ArticleInformationCompleted;
                result.ArticleState = article.ArticleState;
                result.ErrorMessage = article.ErrorMessage;
                result.ErrorOwner = article.ErrorOwner;
                result.ErrorReported = article.ErrorReported;
                result.InternalArticalInformationCompleted = article.InternalArticalInformationCompleted;
                result.PurchaserId = article.PurchaserId;
                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}
