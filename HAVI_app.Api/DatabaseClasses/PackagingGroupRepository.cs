﻿
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class PackagingGroupRepository
    {
        private readonly HAVIdatabaseContext _context;
        public PackagingGroupRepository(HAVIdatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PackagingGroup>> GetPackagingGroups()
        {
            return await _context.PackagingGroups.ToListAsync();
        }
    }
}
