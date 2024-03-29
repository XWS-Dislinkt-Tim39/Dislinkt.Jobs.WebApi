﻿using Dislinkt.Jobs.Core.Repositories;
using Dislinkt.Jobs.Domain.Jobs;
using Dislinkt.Jobs.Persistence.Neo4j.Common;
using Dislinkt.Jobs.Persistence.Neo4j.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Jobs.Persistence.Neo4j.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly IQueryExecutor _queryExecutor;

        public SkillRepository(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        public async Task AddSkill(Skill skill)
        {
            await _queryExecutor.CreateAsync<SkillEntity>(SkillEntity.ToSkillEntity(skill), "SKILL");
        }
    }
}
