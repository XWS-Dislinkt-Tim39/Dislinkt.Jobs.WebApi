using Dislinkt.Jobs.Domain.Jobs;
using MediatR;
using System.Collections.Generic;

namespace Dislinkt.Jobs.Application.SearchJobs.Commands
{
    public class SearchJobsCommand : IRequest<IReadOnlyList<Job>>
    {
        public SearchJobsCommand(string searchParameter)
        {
            this.Request = searchParameter;
        }
        public string Request;
    }
}
