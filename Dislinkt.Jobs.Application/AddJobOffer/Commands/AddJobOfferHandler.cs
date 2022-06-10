using Dislinkt.Jobs.Core.Repositories;
using Dislinkt.Jobs.Domain.Jobs;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Jobs.Application.AddJobOffer.Commands
{
    public class AddJobOfferHandler : IRequestHandler<AddJobOfferCommand, bool>
    {
        private readonly IJobRepository _jobRepository;

        public AddJobOfferHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<bool> Handle(AddJobOfferCommand request, CancellationToken cancellationToken)
        {
            await _jobRepository.AddJobAsync(new Job(Guid.NewGuid(), request.Request.StartDateTime, request.Request.EndDateTime, request.Request.PublisherId,
                request.Request.PositionName, request.Request.Description, request.Request.DailyActivities, request.Request.Requirements));

            return true;
        }
    }
}
