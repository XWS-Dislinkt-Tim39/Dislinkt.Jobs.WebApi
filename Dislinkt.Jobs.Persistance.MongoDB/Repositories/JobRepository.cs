using Dislinkt.Jobs.Core.Repositories;
using Dislinkt.Jobs.Domain.Jobs;
using Dislinkt.Jobs.Persistance.MongoDB.Common;
using Dislinkt.Jobs.Persistance.MongoDB.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Linq;
using System;

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
    }
}
