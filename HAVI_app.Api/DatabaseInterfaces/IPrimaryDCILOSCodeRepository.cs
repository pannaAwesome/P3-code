using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseInterfaces
{
    public interface IPrimaryDCILOSCodeRepository
    {
        Task<IEnumerable<PrimaryDciloscode>> GetPrimaryDCILOSCodes();
        Task<PrimaryDciloscode> AddPrimaryDCILOSCode(PrimaryDciloscode primaryDciloscode);
        Task<PrimaryDciloscode> UpdatePrimaryDCILOSCode(PrimaryDciloscode primaryDciloscode);
        Task<PrimaryDciloscode> DeletePrimaryDCILOSCodeAsync(int primaryDciloscodeId);
    }
}