using MediatR;

namespace Dislinkt.Jobs.Application.AddJobOffer.Commands
{
    public class AddJobOfferCommand : IRequest<bool>
    {
        public AddJobOfferCommand(JobOfferData jobOfferData)
        {
            this.Request = jobOfferData;
        }
        public JobOfferData Request; 
    }
}
