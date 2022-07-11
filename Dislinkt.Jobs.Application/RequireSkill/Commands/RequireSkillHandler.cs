using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dislinkt.Jobs.Core.Repositories;
using MediatR;

namespace Dislinkt.Jobs.Application.RequireSkill.Commands
{
    public class RequireSkillHandler : IRequestHandler<RequireSkillCommand, bool>
    {
        private readonly IJobGraphRepository _jobGraphRepository;

        public RequireSkillHandler(IJobGraphRepository jobGraphRepository)
        {
            _jobGraphRepository = jobGraphRepository;
        }

        public async Task<bool> Handle(RequireSkillCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _jobGraphRepository.RequireSkillAsync(request.Request.SkillId, request.Request.JobId);
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
                return false;
            }

            return true;
        }
    }
}
