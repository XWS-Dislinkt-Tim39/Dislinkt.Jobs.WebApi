﻿using Dislinkt.Jobs.Domain.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Jobs.Core.Repositories
{
    public interface ISkillRepository
    {
        Task AddSkill(Skill skill);
    }
}
