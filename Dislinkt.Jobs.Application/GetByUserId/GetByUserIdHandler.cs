using Dislinkt.Jobs.Core.Repositories;
using Dislinkt.Jobs.Domain.Jobs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Jobs.Application.GetByUserId
{
    public class GetByUserIdHandler : IRequestHandler<GetByUserIdCommand, IReadOnlyCollection<Job>>
    {
        private readonly IJobRepository _jobRepository;
        public GetByUserIdHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }
        public async Task<IReadOnlyCollection<Job>> Handle(GetByUserIdCommand request, CancellationToken cancellationToken)
        {

            var jobs = await _jobRepository.GetByUserId(request.UserId);

            return jobs;
        }
    }
}
