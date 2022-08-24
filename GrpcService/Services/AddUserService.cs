using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dislinkt.Jobs.Core.Repositories;
using Dislinkt.Jobs.Domain.Jobs;
using Dislinkt.Jobs.Domain.Users;
using Grpc.Core;
using GrpcAddUserJobsService;
using Microsoft.Extensions.Logging;
using GrpcService;

namespace GrpcService.Services
{
    public class AddUserService : AddUserJobsGreeter.AddUserJobsGreeterBase
    {
        private readonly ILogger<AddUserService> _logger;
        private readonly IUserRepository _userRepository;
        public AddUserService(ILogger<AddUserService> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public override async Task<AddUserJobsReply> AddUserJobs(AddUserJobsRequest request, ServerCallContext context)
        {
            try
            {
                await _userRepository.AddUserAsync(new User
                {
                    Id = Guid.Parse(request.Id),
                    Seniority = (Seniority)request.Seniority,
                    Username = request.Name
                });
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Failed to add user {request.Name}.");
                Debug.WriteLine(e.ToString());
                return null;
            }
            return await Task.FromResult(new AddUserJobsReply
            {
                Message = $"User: {request.Id} | {request.Name} | {(Seniority)request.Seniority}",
                Successful = true
            });
        }
    }
}
