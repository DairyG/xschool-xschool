﻿using XSchool.GCenter.Model;
using XSchool.GCenter.Repositories.Extensions;
using XSchool.Repositories;

namespace XSchool.GCenter.Repositories
{
    public class AnnouncementRepository : Repository<Announcement>
    {
        public AnnouncementRepository(GCenterDbContext dbContext) : base(dbContext)
        {

        }
    }
}
