using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseInterfaces
{
    public interface IInternalArticleInformationRepository
    {
        Task<IEnumerable<InternalArticleInformation>> GetInternalArticleInformations();
        Task<InternalArticleInformation> GetInternalArticleInformation(int internalArticleInformationId);
        Task<InternalArticleInformation> AddInternalArticleInformation(InternalArticleInformation internalArticleInformation);
        Task<InternalArticleInformation> UpdateInternalArticleInformation(InternalArticleInformation internalArticleInformation);
        Task<InternalArticleInformation> DeleteInternalArticleInformationAsync(int internalArticleInformationId);
    }
}