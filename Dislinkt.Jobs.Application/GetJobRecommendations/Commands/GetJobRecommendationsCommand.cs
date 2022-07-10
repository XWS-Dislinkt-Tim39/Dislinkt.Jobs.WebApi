using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dislinkt.Jobs.Domain.Jobs;
using MediatR;

namespace Dislinkt.Jobs.Application.GetJobRecommendations.Commands
{
    public class GetJobRecommendationsCommand : IRequest<IReadOnlyList<Job>>
    {
        public GetJobRecommendationsCommand(Guid sourceId)
        {
            SourceId = sourceId;
        }
        public Guid SourceId;
    }
}
