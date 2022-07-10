using Dislinkt.Jobs.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Jobs.Core.Repositories
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);

        Task AddSkillAsync(Guid userId, Guid skillId);
    }
}
