using Dislinkt.Jobs.Core.Repositories;
using Dislinkt.Jobs.Domain.Jobs;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Jobs.Application.SearchJobs.Commands
{
    public class SearchJobsHandler : IRequestHandler<SearchJobsCommand, IReadOnlyList<Job>>
    {
        private readonly IJobRepository _jobRepository;
        public SearchJobsHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }
        public async Task<IReadOnlyList<Job>> Handle(SearchJobsCommand request, CancellationToken cancellationToken)
        {
            var result = await _jobRepository.SearchJobs(request.Request);

            return result;
        }
    }
}
