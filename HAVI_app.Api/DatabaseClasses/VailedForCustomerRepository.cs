using HAVI_app.Api.DatabaseInterfaces;
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class VailedForCustomerRepository : IVailedForCustomerRepository
    {
        private readonly HAVIdatabaseContext _context;
        public VailedForCustomerRepository(HAVIdatabaseContext context)
        {
            _context = context;
        }
        public async Task<VailedForCustomer> AddVailedForCustomer(VailedForCustomer customer)
        {
            var result = await _context.VailedForCustomers.AddAsync(customer);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async void DeleteVailedForCustomerAsync(int customerId)
        {
            var result = await _context.VailedForCustomers.FirstOrDefaultAsync(s => s.Id == customerId);
            if (result != null)
            {
                _context.VailedForCustomers.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<VailedForCustomer>> GetVailedForCustomers()
        {
            return await _context.VailedForCustomers.ToListAsync();
        }

        public async Task<VailedForCustomer> UpdateVailedForCustomer(VailedForCustomer customer)
        {
            var result = await _context.VailedForCustomers.FirstOrDefaultAsync(s => s.Id == customer.Id);
            if (result != null)
            {
                result.Customer = customer.Customer;
                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}
