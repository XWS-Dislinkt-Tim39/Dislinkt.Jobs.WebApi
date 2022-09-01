using System;
using MediatR;
using System.Collections.Generic;

namespace Dislinkt.Jobs.Application.GetAllUsers.Commands
{
    public class GetAllUsersCommand : IRequest<IReadOnlyList<Guid>>
    {
        public GetAllUsersCommand() 
        {
        }
    }
}

