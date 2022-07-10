using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Jobs.Application.AddSkill.Commands
{
    public class AddSkillCommand : IRequest<bool>
    {
        public AddSkillCommand(SkillData skillData)
        {
            Request = skillData;
        }

        public SkillData Request;
    }
}
