using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Dislinkt.Jobs.Application.RemoveSkill.Commands
{

    public class RemoveSkillCommand : IRequest<bool>
    {
        public RemoveSkillCommand(AssignSkillData assignSkillData)
        {
            Request = assignSkillData;
        }
        public AssignSkillData Request;
    }
}
