using Dislinkt.Jobs.Core.Repositories;
using Dislinkt.Jobs.Domain.Jobs;
using Dislinkt.Jobs.Persistence.Neo4j.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Jobs.Persistence.Neo4j.Repositories
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

        public async Task<IReadOnlyList<Job>> SearchJobs(string searchParameter)
        {
            var filter = Builders<JobEntity>.Filter.Regex("PositionName", BsonRegularExpression.Create(new Regex(searchParameter, RegexOptions.IgnoreCase)));

            var result = await _queryExecutor.FindAsync(filter);

            return result?.AsEnumerable()?.Select(s => s.ToJob())?.ToArray() ?? Array.Empty<Job>();
        }

        public async Task<IReadOnlyCollection<Job>> GetAllAsync()
        {
            var result = await _queryExecutor.GetAll<JobEntity>();

            return result?.AsEnumerable().Select(s => s.ToJob()).ToArray() ?? Array.Empty<Job>();
        }

        public async Task<IReadOnlyCollection<Job>> GetByUserId(Guid userId)
        {
            var filter = Builders<JobEntity>.Filter.Eq(u => u.PublisherId, userId);

            var result = await _queryExecutor.FindAsync(filter);

            return result?.AsEnumerable().Select(s => s.ToJob()).ToArray() ?? Array.Empty<Job>();
        }
    }
}
