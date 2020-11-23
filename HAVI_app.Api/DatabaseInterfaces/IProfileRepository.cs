using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseInterfaces
{
    public interface IProfileRepository
    {
        Task<IEnumerable<Profile>> GetProfiles();
        Task<Profile> GetProfile(int profileId);
        Task<Profile> AddProfile(Profile profile);
        Task<Profile> UpdateProfile(Profile profile);
        void DeleteProfileAsync(int profileId);
    }
}
