using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dislinkt.Jobs.Core.Repositories;
using MediatR;

namespace Dislinkt.Jobs.Application.AssignSkill.Commands
{
    public class AssignSkillHandler : IRequestHandler<AssignSkillCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public AssignSkillHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(AssignSkillCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _userRepository.AddSkillAsync(request.Request.UserId, request.Request.SkillId);
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
