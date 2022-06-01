using Dislinkt.Jobs.Domain.Jobs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Jobs.Application.GetAllJobs.Commands
{
    public class GetAllJobsCommand : IRequest<IReadOnlyCollection<Job>>
    {
    }
}
