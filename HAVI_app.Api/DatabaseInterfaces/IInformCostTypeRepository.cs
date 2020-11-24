using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseInterfaces
{
    public interface IInformCostTypeRepository
    {
        Task<IEnumerable<InformCostType>> GetInformCostTypes();
        Task<InformCostType> AddInformCostType(InformCostType informCostType);
        Task<InformCostType> UpdateInformCostType(InformCostType informCostType);
        void DeleteInformCostTypeAsync(int informCostTypeId);
    }
}
