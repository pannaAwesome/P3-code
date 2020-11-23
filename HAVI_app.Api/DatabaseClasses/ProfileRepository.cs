using HAVI_app.Api.DatabaseInterfaces;
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class ProfileRepository : IProfileRepository 
    {
        private readonly HAVIdatabaseContext _context;
        public ProfileRepository(HAVIdatabaseContext context)
        {
            _context = context;
        }
        public async Task<Profile> AddProfile(Profile profile)
        {
            var result = await _context.Profiles.AddAsync(profile);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async void DeleteProfileAsync(int profileId)
        {
            var result = await _context.Profiles.FirstOrDefaultAsync(s => s.Id == profileId);
            if (result != null)
            {
                _context.Profiles.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Profile> GetProfile(int profileId)
        {
            return await _context.Profiles.FirstOrDefaultAsync(s => s.Id == profileId);
        }

        public async Task<IEnumerable<Profile>> GetProfiles()
        {
            return await _context.Profiles.ToListAsync();
        }

        public async Task<Profile> UpdateProfile(Profile profile)
        {
            var result = await _context.Profiles.FirstOrDefaultAsync(s => s.Id == profile.Id);
            if (result != null)
            {
                result.Username = profile.Username;
                result.Password = profile.Password;
                result.Usertype = profile.Usertype;
                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}

