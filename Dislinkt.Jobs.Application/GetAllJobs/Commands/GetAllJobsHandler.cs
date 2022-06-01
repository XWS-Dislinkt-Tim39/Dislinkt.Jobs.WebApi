using Dislinkt.Jobs.Core.Repositories;
using Dislinkt.Jobs.Domain.Jobs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Jobs.Application.GetAllJobs.Commands
{
    public class GetAllJobsHandler : IRequestHandler<GetAllJobsCommand, IReadOnlyCollection<Job>>
    {
        private readonly IJobRepository _jobRepository;
        public GetAllJobsHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }
        public async Task<IReadOnlyCollection<Job>> Handle(GetAllJobsCommand request, CancellationToken cancellationToken)
        {
            return await _jobRepository.GetAllAsync();
        }
    }
}
