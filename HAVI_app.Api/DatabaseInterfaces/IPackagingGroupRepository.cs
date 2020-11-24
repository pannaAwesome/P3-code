using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseInterfaces
{
    interface IPackagingGroupRepository
    {
        Task<IEnumerable<PackagingGroup>> GetPackagingGroups();
    }
}
