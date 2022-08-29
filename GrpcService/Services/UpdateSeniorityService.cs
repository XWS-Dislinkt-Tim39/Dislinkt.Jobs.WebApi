using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Dislinkt.Jobs.Core.Repositories;
using Dislinkt.Jobs.Domain.Jobs;
using Grpc.Core;
using GrpcUpdateSeniorityService;
using Microsoft.Extensions.Logging;

namespace GrpcService.Services
{
    public class UpdateSeniorityService : UpdateSeniorityGreeter.UpdateSeniorityGreeterBase
    {
        private readonly ILogger<UpdateSeniorityService> _logger;
        private readonly IUserRepository _userRepository;
        public UpdateSeniorityService(ILogger<UpdateSeniorityService> logger, IUserRepository userRepository) 
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public override async Task<UpdateSeniorityReply> UpdateSeniority(UpdateSeniorityRequest request, ServerCallContext context)
        {
            try
            {
                await _userRepository.UpdateSeniorityById(Guid.Parse(request.Id), (Seniority)request.Seniority);
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
            return await Task.FromResult(new UpdateSeniorityReply
            {
                Message = $"User: {request.Id} | new seniority: {(Seniority)request.Seniority}",
                Successful = true
            });
        }
    }
}

