using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dislinkt.Jobs.Core.Repositories;
using MediatR;

namespace Dislinkt.Jobs.Application.GetAllUsers.Commands
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersCommand, IReadOnlyList<Guid>>
    {
        private readonly IUserRepository _userRepository;
        public GetAllUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IReadOnlyList<Guid>> Handle(GetAllUsersCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllUsersAsync();
        }
    }
}

