using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Dislinkt.Jobs.Application.AssignSkill.Commands
{
    public class AssignSkillCommand : IRequest<bool>
    {
        public AssignSkillCommand(AssignSkillData assignSkillData)
        {
            Request = assignSkillData;
        }
        public AssignSkillData Request;
    }
}
