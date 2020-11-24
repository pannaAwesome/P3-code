using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseInterfaces
{
    public interface IQIPRepository
    {
        Task<IEnumerable<Qip>> GetQIPs();
        Task<Qip> GetQIP(int QIPId);
        Task<Qip> AddQIP(Qip QIP);
        Task<Qip> UpdateQIP(Qip QIP);
        void DeleteQIPAsync(int QIPId);
    }
}