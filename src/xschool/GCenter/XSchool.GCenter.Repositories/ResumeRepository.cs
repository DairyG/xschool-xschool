﻿using XSchool.GCenter.Model;
using XSchool.GCenter.Repositories.Extensions;
using XSchool.Repositories;

namespace XSchool.GCenter.Repositories
{
    public class ResumeRepository : Repository<Resume>
    {
        public ResumeRepository(GCenterDbContext dbContext) : base(dbContext) { }
    }
}
