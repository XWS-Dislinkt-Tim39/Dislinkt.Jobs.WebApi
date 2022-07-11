using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Dislinkt.Jobs.Application.RequireSkill.Commands
{
    public class RequireSkillCommand : IRequest<bool>
    {

        public RequireSkillCommand(RequireSkillData requireSkillData)
        {
            Request = requireSkillData;
        }

        public RequireSkillData Request;
    }
}
