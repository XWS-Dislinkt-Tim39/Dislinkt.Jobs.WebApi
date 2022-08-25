using Dislinkt.Jobs.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dislinkt.Jobs.Domain.Jobs;

namespace Dislinkt.Jobs.Core.Repositories
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task DeleteById(Guid id);

        Task AddSkillAsync(Guid userId, Guid skillId);

        Task RemoveSkillAsync(Guid userId, Guid skillId);

        Task<IReadOnlyList<Job>> GetJobRecommendationsAsync(Guid userId);
    }
}
