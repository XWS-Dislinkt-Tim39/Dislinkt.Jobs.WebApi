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
        Task CreateConnectionAsync(Guid sourceId, Guid targetId, string connectionName);
        Task RemoveConnectionAsync(Guid sourceId, Guid targetId, string connectionName);
        Task<IReadOnlyList<Guid>> GetConnectedAsync(Guid sourceId, string connectionType);
    }
}
