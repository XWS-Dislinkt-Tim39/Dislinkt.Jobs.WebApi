using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dislinkt.Jobs.Core.Repositories;
using MediatR;

namespace Dislinkt.Jobs.Application.RemoveSkill.Commands
{
    public class RemoveSkillHandler : IRequestHandler<RemoveSkillCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public RemoveSkillHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(RemoveSkillCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _userRepository.RemoveSkillAsync(request.Request.UserId, request.Request.SkillId);
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
