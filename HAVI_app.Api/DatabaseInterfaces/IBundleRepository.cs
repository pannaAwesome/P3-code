using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseInterfaces
{
    public interface IBundleRepository
    {
        Task<IEnumerable<Bundle>> GetBundles();
        Task<Bundle> GetBundle(int bundleId);
        Task<Bundle> AddBundle(Bundle bundle);
        Task<Bundle> UpdateBundle(Bundle bundle);
        Task<Bundle> DeleteBundleAsync(int bundleId);
    }
}
