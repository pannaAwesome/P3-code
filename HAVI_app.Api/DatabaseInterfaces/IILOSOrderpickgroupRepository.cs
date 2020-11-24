using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseInterfaces
{
    public interface IILOSOrderpickgroupRepository
    {
        Task<IEnumerable<Ilosorderpickgroup>> GetIlosOrderpickgroupes();
        Task<Ilosorderpickgroup> AddIlosOrderpickgroup(Ilosorderpickgroup ilosorderpickgroup);
        Task<Ilosorderpickgroup> UpdateIlosOrderpickgroup(Ilosorderpickgroup ilosorderpickgroup);
        void DeleteIlosOrderpickgroupAsync(int ilosorderpickgroupId);
    }
}
