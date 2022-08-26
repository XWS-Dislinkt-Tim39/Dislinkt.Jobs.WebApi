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
        private readonly IJobRepository _jobRepository;

        public GetJobRecommendationsHandler(IUserRepository userRepository,IJobRepository jobRepository)
        {
            _userRepository = userRepository;
            _jobRepository = jobRepository;
        }

        public async Task<IReadOnlyList<Job>> Handle(GetJobRecommendationsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var fullJobs =new List<Job>();
                var recommended= await _userRepository.GetJobRecommendationsAsync(request.SourceId);
                foreach (var job in recommended)
                {
                    fullJobs.Add(_jobRepository.GetById(job.Id).Result);
                }

                return fullJobs;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
                return null;
            }
        }
    }
}
