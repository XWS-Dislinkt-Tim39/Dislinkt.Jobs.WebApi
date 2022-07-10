using Dislinkt.Jobs.Domain.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Jobs.Persistence.Neo4j.Entities
{
    public class SkillEntity : BaseEntity
    {
        public string Name { get; set; }
        public Skill ToSkill()
            => new Skill(this.Id, this.Name);
        public static SkillEntity ToSkillEntity(Skill skill)
        {
            return new SkillEntity
            {
                Id = skill.Id,
                Name = skill.Name
            };
        }
    }
}
