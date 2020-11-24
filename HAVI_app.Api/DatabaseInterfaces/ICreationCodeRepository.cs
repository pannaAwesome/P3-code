using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseInterfaces
{
    public interface ICreationCodeRepository
    {
        Task<IEnumerable<CreationCode>> GetCreationCodes();
        Task<CreationCode> GetCreationCode(int creationCodeId);
        Task<CreationCode> AddCreationCode(CreationCode creationCode);
        Task<CreationCode> UpdateCreationCode(CreationCode creationCode);
        void DeleteCreationCodeAsync(int creationCodeId);
    }
}
