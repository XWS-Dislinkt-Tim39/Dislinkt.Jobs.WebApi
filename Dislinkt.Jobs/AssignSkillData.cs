using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Jobs
{
    public class AssignSkillData
    {
        /// <summary>
        /// ID of the skill that's being assigned.
        /// </summary>
        public Guid SkillId { get; set; }
        /// <summary>
        /// ID of the users the skill is being assigned to.
        /// </summary>
        public Guid UserId { get; set; }

    }
}
