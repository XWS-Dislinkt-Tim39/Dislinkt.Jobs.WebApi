using Dislinkt.Jobs.Persistence.Neo4j.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Jobs.Persistence.Neo4j.Common
{
    public interface IQueryExecutor
    {
        Task CreateAsync<T>(T t, string EntityType) where T : BaseEntity;
        Task DeleteByIdAsync<T>(Guid id) where T : BaseEntity;
        Task CreateConnectionAsync(Guid sourceId, Guid targetId, string connectionName);
        Task RemoveConnectionAsync(Guid sourceId, Guid targetId, string connectionName);
        Task<IReadOnlyList<Guid>> GetConnectedAsync(Guid sourceId, string connectionType);
        Task<T> FindByIdAsync<T>(Guid id) where T : BaseEntity;
        Task<IReadOnlyList<T>> GetCommonNodeWithCondition<T>(Guid sourceId, string sourceLabel, string targetLabel, 
            string sourceConnectionLabel, string targetConnectionLabel, string conditionAttribute, string commonNodeLabel) where T : BaseEntity;
    }
}
