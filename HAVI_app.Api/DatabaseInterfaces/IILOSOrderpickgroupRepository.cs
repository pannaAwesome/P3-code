using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseInterfaces
{
    public interface IILOSOrderpickgroupRepository
    {
        Task<Ilosorderpickgroup> GetILOSOrderpickgroup(int ilosOrderpickgroupId)
        Task<IEnumerable<Ilosorderpickgroup>> GetILOSOrderpickgroups();
        Task<Ilosorderpickgroup> AddILOSOrderpickgroup(Ilosorderpickgroup ilosOrderpickgroup);
        Task<Ilosorderpickgroup> UpdateILOSOrderpickgroup(Ilosorderpickgroup ilosOrderpickgroup);
        Task<Ilosorderpickgroup> DeleteILOSOrderpickgroupAsync(int ilosOrderpickgroupId);
    }
}
