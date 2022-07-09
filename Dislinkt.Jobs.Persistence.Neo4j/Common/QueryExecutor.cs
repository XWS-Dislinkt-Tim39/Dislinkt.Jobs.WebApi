using Dislinkt.Jobs.Persistence.Neo4j.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Jobs.Persistence.Neo4j.Common
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly Neo4jDbContext _neo4jDbContext;

        public QueryExecutor(Neo4jDbContext neo4JDbContext)
        {
            _neo4jDbContext = neo4JDbContext;
        }
        public async Task CreateAsync<T>(T t, string EntityType) where T : BaseEntity
            => await _neo4jDbContext.CreateAsync(t, EntityType);
    }
}
