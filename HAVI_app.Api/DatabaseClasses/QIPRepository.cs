
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class QIPRepository
    {
        private readonly HAVIdatabaseContext _context;
        public QIPRepository(HAVIdatabaseContext context)
        {
            _context = context;
        }
        public async Task<Qip> AddQIP(Qip qip)
        {
            var result = await _context.Qips.AddAsync(qip);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Qip> DeleteQIPAsync(int qipId)
        {
            var result = await _context.Qips.FirstOrDefaultAsync(s => s.Id == qipId);
            if (result != null)
            {
                _context.Qips.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Qip> GetQIP(int qipId)
        {
            return await _context.Qips.FirstOrDefaultAsync(s => s.Id == qipId);
        }

        public async Task<IEnumerable<Qip>> GetQIPs()
        {
            return await _context.Qips.ToListAsync();
        }

        public async Task<Qip> UpdateQIP(Qip qip)
        {
            var result = await _context.Qips.FirstOrDefaultAsync(s => s.Id == qip.Id);
            if (result != null)
            {
                result.QipanswerOptions = qip.QipanswerOptions;
                result.Qipdescription = qip.Qipdescription;
                result.Qipfrequency = qip.Qipfrequency;
                result.QipfrequencyType = qip.QipfrequencyType;
                result.QiphighBoundary = qip.QiphighBoundary;
                result.QiplowBoundary = qip.QiplowBoundary;
                result.QipnameNumber = qip.QipnameNumber;
                result.Qipokvalue = qip.Qipokvalue;
                result.QipsetAnswer = qip.QipsetAnswer;
                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}
