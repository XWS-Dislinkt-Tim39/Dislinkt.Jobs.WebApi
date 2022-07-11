using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Jobs
{
    public class RequireSkillData
    {
        /// <summary>
        /// ID of the skill that's being required.
        /// </summary>
        public Guid SkillId { get; set; }
        /// <summary>
        /// ID of the job the skill is being required from.
        /// </summary>
        public Guid JobId { get; set; }
    }
}
