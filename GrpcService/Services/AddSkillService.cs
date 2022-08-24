using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dislinkt.Jobs.Core.Repositories;
using GrpcAddSkillService;

namespace GrpcService.Services
{
    public class AddSkillService : AddSkillGreeter.AddSkillGreeterBase
    {
        private readonly ILogger<AddSkillService> _logger;
        private readonly IUserRepository _userRepository;
        public AddSkillService(ILogger<AddSkillService> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public override async Task<AddSkillReply> AddSkill(AddSkillRequest request, ServerCallContext context)
        {
            try
            {
                await _userRepository.AddSkillAsync(Guid.Parse(request.UserId), Guid.Parse(request.SkillId));
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Failed to assign skill {request.SkillId} to User {request.UserId}");
                Debug.WriteLine(e.ToString());
                return null;
            }
            return await Task.FromResult(new AddSkillReply
            {
                Message = "Skill: ",
                Successful = true
            });
        }
    }
}
