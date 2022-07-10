using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dislinkt.Jobs.Core.Repositories;
using Dislinkt.Jobs.Domain.Jobs;
using MediatR;

namespace Dislinkt.Jobs.Application.GetJobRecommendations.Commands
{
    public class GetJobRecommendationsHandler : IRequestHandler<GetJobRecommendationsCommand, IReadOnlyList<Job>>
    {
        private readonly IUserRepository _userRepository;

        public GetJobRecommendationsHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IReadOnlyList<Job>> Handle(GetJobRecommendationsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _userRepository.GetJobRecommendationsAsync(request.SourceId);
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
                return null;
            }
        }
    }
}
