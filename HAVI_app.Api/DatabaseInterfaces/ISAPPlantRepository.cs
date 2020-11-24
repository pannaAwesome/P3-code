using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseInterfaces
{
    public interface ISAPPlantRepository
    {
        Task<IEnumerable<Sapplant>> GetSAPPlants();
        Task<Sapplant> GetSAPPlant(int SAPPlantId);
        Task<Sapplant> AddSAPPlant(Sapplant SAPPlant);
        Task<Sapplant> UpdateSAPPlant(Sapplant SAPPlant);
        Task<Sapplant> DeleteSAPPlantAsync(int SAPPlantId);
    }
}