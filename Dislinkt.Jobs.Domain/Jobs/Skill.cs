using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Jobs.Domain.Jobs
{
    public class Skill
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public Skill(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
