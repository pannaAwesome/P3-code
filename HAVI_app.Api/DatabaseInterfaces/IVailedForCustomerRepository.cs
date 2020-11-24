using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseInterfaces
{
    public interface IVailedForCustomerRepository
    {
        Task<IEnumerable<VailedForCustomer>> GetVailedForCustomers();
        Task<VailedForCustomer> AddVailedForCustomer(VailedForCustomer vailedForCustomer);
        Task<VailedForCustomer> UpdateVailedForCustomer(VailedForCustomer vailedForCustomer);
        Task<VailedForCustomer> DeleteVailedForCustomerAsync(int vailedForCustomerId);
    }
}