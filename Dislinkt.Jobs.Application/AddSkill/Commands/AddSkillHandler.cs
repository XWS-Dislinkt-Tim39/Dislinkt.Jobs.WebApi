using Dislinkt.Jobs.Core.Repositories;
using Dislinkt.Jobs.Domain.Jobs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Jobs.Application.AddSkill.Commands
{
    public class AddSkillHandler : IRequestHandler<AddSkillCommand, bool>
    {
        private readonly ISkillRepository _skillRepository;

        public AddSkillHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<bool> Handle(AddSkillCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Skill skill = new Skill(request.Request.Id, request.Request.Name);
                await _skillRepository.AddSkill(skill);
                return true;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
                return false;
            }
        }
    }
}
