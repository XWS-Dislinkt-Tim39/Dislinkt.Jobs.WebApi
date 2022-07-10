using Dislinkt.Jobs.Core.Repositories;
using Dislinkt.Jobs.Domain.Users;
using Dislinkt.Jobs.Persistence.Neo4j.Common;
using Dislinkt.Jobs.Persistence.Neo4j.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Jobs.Persistence.Neo4j.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IQueryExecutor _queryExecutor;

        public UserRepository(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        public async Task AddUserAsync(User user)
        {
            await _queryExecutor.CreateAsync<UserEntity>(UserEntity.ToUserEntity(user), "USER");
        }
    }
}
