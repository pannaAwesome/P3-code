using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseInterfaces
{
    public interface IArticleInformationRepository
    {
        Task<IEnumerable<ArticleInformation>> GetArticleInformations();
        Task<ArticleInformation> GetArticleInformation(int articleInformationId);
        Task<ArticleInformation> AddArticleInformation(ArticleInformation articleInformation);
        Task<ArticleInformation> UpdateArticleInformation(ArticleInformation articleInformation);
    }
}
