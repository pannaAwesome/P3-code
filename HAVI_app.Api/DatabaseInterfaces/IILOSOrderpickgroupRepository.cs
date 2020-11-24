using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseInterfaces
{
    public interface IILOSOrderpickgroupRepository
    {
        Task<IEnumerable<Ilosorderpickgroup>> GetILOSOrderpickgroups();
        Task<Ilosorderpickgroup> AddILOSOrderpickgroup(Ilosorderpickgroup ilosorderpickgroup);
        Task<Ilosorderpickgroup> UpdateILOSOrderpickgroup(Ilosorderpickgroup ilosorderpickgroup);
        Task<Ilosorderpickgroup> DeleteILOSOrderpickgroupAsync(int ilosorderpickgroupId);
    }
}
