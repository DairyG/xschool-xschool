﻿using XSchool.Repositories;
using XShop.GCenter.Model;
using XShop.GCenter.Repositories.Extensions;

namespace XShop.GCenter.Repositories
{
    public class CompanyRepository : Repository<Company>
    {
        public CompanyRepository(GCenterDbContext dbContext) : base(dbContext) { }
    }
}