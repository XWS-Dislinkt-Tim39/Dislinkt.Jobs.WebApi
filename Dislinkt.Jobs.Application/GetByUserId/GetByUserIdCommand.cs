using Dislinkt.Jobs.Domain.Jobs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Jobs.Application.GetByUserId
{
    public class GetByUserIdCommand: IRequest<IReadOnlyCollection<Job>>
    {
        public GetByUserIdCommand(Guid userId)
    {
        this.UserId = userId;
    }
    public Guid UserId;

    }
}

