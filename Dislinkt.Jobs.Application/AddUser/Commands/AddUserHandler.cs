using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dislinkt.Jobs.Core.Repositories;
using Dislinkt.Jobs.Domain.Users;
using MediatR;

namespace Dislinkt.Jobs.Application.AddUser.Commands
{
    public class AddUserHandler : IRequestHandler<AddUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public AddUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _userRepository.AddUserAsync(new User
                {
                    Id = request.Request.Id,
                    Seniority = request.Request.Seniority,
                    Username = request.Request.Username
                });
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
                return false;
            }

            return true;
        }
    }
}
