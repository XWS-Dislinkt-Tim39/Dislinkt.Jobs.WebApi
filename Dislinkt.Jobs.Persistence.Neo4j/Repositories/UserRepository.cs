using Dislinkt.Jobs.Core.Repositories;
using Dislinkt.Jobs.Domain.Users;
using Dislinkt.Jobs.Persistence.Neo4j.Common;
using Dislinkt.Jobs.Persistence.Neo4j.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dislinkt.Jobs.Domain.Jobs;

namespace Dislinkt.Jobs.Persistence.Neo4j.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IQueryExecutor _queryExecutor;

        public UserRepository(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        public async Task<IReadOnlyList<Guid>> GetAllUsersAsync()
        {
            return await _queryExecutor.GetAll();
        }

        public async Task AddUserAsync(User user)
        {
            await _queryExecutor.CreateAsync<UserEntity>(UserEntity.ToUserEntity(user), "USER");
        }

        public async Task DeleteById(Guid id)
        {
            await _queryExecutor.DeleteByIdAsync<UserEntity>(id);
        }

        public async Task AddSkillAsync(Guid userId, Guid skillId)
        {
            await _queryExecutor.CreateConnectionAsync(userId, skillId, "HAS_SKILL");
        }

        public async Task RemoveSkillAsync(Guid userId, Guid skillId)
        {
            await _queryExecutor.RemoveConnectionAsync(userId, skillId, "HAS_SKILL");
        }

        public async Task<IReadOnlyList<Job>> GetJobRecommendationsAsync(Guid userId)
        {
            var results = await _queryExecutor.GetCommonNodeWithCondition<JobEntity>(userId, "USER", "JOB", "HAS_SKILL",
                    "REQUIRES", "Seniority", "SKILL");
            List<Job> retVal = results.Select(result => result.ToJob()).ToList() ?? new List<Job>();

            return retVal;
        }

        public async Task UpdateSeniorityByIdAsync(Guid id, Seniority seniority)
        {
            await _queryExecutor.UpdateSpecificByIdAsync<UserEntity>(new UserEntity
            {
                Id = id,
                Seniority = seniority
            }, "Seniority", seniority.ToString());
        }
    }
}
