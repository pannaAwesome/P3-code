using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseInterfaces
{
    public interface IPrimaryDCILOSCodeRepository
    {
        Task<IEnumerable<PrimaryDciloscode>> GetPrimaryDCILOScodes();
        Task<PrimaryDciloscode> AddPrimaryDCILOScode(PrimaryDciloscode primaryDciloscode);
        Task<PrimaryDciloscode> UpdatePrimaryDCILOScode(PrimaryDciloscode primaryDciloscode);
        void DeletePrimaryDciloscodeAsync(int primaryDciloscodeId);
    }
}