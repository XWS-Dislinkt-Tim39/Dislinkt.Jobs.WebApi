using Dislinkt.Jobs.Core.Repositories;
using Dislinkt.Jobs.Domain.Jobs;
using MediatR;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Jobs.Application.AddJobOffer.Commands
{
    public class AddJobOfferHandler : IRequestHandler<AddJobOfferCommand, Job>
    {
        private readonly IJobRepository _jobRepository;
        private readonly IJobGraphRepository _jobGraphRepository;

        public AddJobOfferHandler(IJobRepository jobRepository, IJobGraphRepository jobGraphRepository)
        {
            _jobRepository = jobRepository;
            _jobGraphRepository = jobGraphRepository;
        }

        public async Task<Job> Handle(AddJobOfferCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Job job = new Job(Guid.NewGuid(), request.Request.StartDateTime, request.Request.EndDateTime,
                    request.Request.PublisherId,
                    request.Request.PositionName, request.Request.Description, request.Request.DailyActivities,
                    request.Request.Requirements, request.Request.Seniority);
                await _jobRepository.AddJobAsync(job);
                await _jobGraphRepository.AddJobAsync(job);
                return job;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
                return null;
            }
        }
    }
}
