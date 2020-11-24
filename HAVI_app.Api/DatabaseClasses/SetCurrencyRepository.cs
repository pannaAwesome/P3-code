using HAVI_app.Api.DatabaseInterfaces;
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class SetCurrencyRepository : ISetCurrencyRepository
    {
        private readonly HAVIdatabaseContext _context;
        public SetCurrencyRepository(HAVIdatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SetCurrency>> GetFreightResponsibility()
        {
            return await _context.SetCurrencies.ToListAsync();
        }
    }
}
