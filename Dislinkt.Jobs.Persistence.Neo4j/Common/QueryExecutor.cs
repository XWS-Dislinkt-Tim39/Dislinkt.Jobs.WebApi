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

        public async Task DeleteByIdAsync<T>(Guid id) where T : BaseEntity
            => await _neo4jDbContext.DeleteByIdAsync<T>(id);
        public async Task CreateConnectionAsync(Guid sourceId, Guid targetId, string connectionName)
            => await _neo4jDbContext.CreateConnectionAsync(sourceId, targetId, connectionName);

        public async Task RemoveConnectionAsync(Guid sourceId, Guid targetId, string connectionName)
            => await _neo4jDbContext.RemoveConnectionAsync(sourceId, targetId, connectionName);

        public async Task<IReadOnlyList<Guid>> GetConnectedAsync(Guid sourceId, string connectionType)
            => await _neo4jDbContext.GetConnected(sourceId, connectionType);

        public async Task<T> FindByIdAsync<T>(Guid id) where T : BaseEntity
            => await _neo4jDbContext.FindByIdAsync<T>(id);

        public async Task<IReadOnlyList<T>> GetCommonNodeWithCondition<T>(Guid sourceId, string sourceLabel,
            string targetLabel,
            string sourceConnectionLabel, string targetConnectionLabel, string conditionAttribute,
            string commonNodeLabel) where T : BaseEntity
            => await _neo4jDbContext.GetCommonNodeWithCondition<T>(sourceId, sourceLabel, targetLabel,
                sourceConnectionLabel, targetConnectionLabel, conditionAttribute, commonNodeLabel);
        public async Task UpdateSpecificByIdAsync<T>(T t, string attributeName, string attributeValue) where T : BaseEntity
            => await _neo4jDbContext.UpdateSpecificById(t, attributeName, attributeValue);
    }
}
