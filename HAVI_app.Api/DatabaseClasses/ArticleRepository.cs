using HAVI_app.Api.DatabaseInterfaces;
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly HAVIdatabaseContext _context;
        public ArticleRepository(HAVIdatabaseContext context)
        {
            _context = context;
        }
        public async Task<Article> AddArticle(Article article)
        {
            var result = await _context.Articles.AddAsync(article);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async void DeleteArticleAsync(int articleId)
        {
            var result = await _context.Articles.FirstOrDefaultAsync(s => s.Id == articleId);
            if (result != null)
            {
                _context.Articles.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Article> GetArticle(int articleId)
        {
            return await _context.Articles.FirstOrDefaultAsync(s => s.Id == articleId);
        }

        public async Task<IEnumerable<Article>> GetArticles()
        {
            return await _context.Articles.ToListAsync();
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
