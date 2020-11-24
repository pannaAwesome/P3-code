using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseInterfaces
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetArticles();
        Task<Article> GetArticle(int articleId);
        Task<Article> AddArticle(Article article);
        Task<Article> UpdateArticle(Article article);
        Task<Article> DeleteArticleAsync(int articleId);
    }
}
