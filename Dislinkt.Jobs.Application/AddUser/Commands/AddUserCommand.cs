using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Dislinkt.Jobs.Application.AddUser.Commands
{
    public class AddUserCommand : IRequest<bool>
    {
        public AddUserCommand(UserData userData)
        {
            Request = userData;
        }
        public UserData Request { get; set; }
    }
}
