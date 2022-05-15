using Dislinkt.Jobs.Core.Repositories;
using Dislinkt.Jobs.Domain.Jobs;
using Dislinkt.Jobs.Persistance.MongoDB.Common;
using Dislinkt.Jobs.Persistance.MongoDB.Entities;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Dislinkt.Jobs.Persistance.MongoDB.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly IQueryExecutor _queryExecutor;
        public JobRepository(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        public async Task AddJobAsync(Job job)
        {
            try
            {
                await _queryExecutor.CreateAsync(JobEntity.ToJobEntity(job));

            }
            catch (MongoWriteException ex)
            {
                throw ex;
            }
        }
    }
}
