using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dislinkt.Jobs.Application.DeleteUser.Commands
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public DeleteUserCommand(Guid id)
        {
            Request = id;
        }
        public Guid Request { get; set; }

    }
}
