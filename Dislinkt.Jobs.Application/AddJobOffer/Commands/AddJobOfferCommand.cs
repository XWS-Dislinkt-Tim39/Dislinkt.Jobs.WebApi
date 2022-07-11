using Dislinkt.Jobs.Domain.Jobs;
using MediatR;

namespace Dislinkt.Jobs.Application.AddJobOffer.Commands
{
    public class AddJobOfferCommand : IRequest<Job>
    {
        public AddJobOfferCommand(JobOfferData jobOfferData)
        {
            this.Request = jobOfferData;
        }
        public JobOfferData Request; 
    }
}
