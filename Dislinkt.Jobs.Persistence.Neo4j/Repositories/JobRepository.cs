using Dislinkt.Jobs.Core.Repositories;
using Dislinkt.Jobs.Domain.Jobs;
using Dislinkt.Jobs.Persistence.Neo4j.Common;
using Dislinkt.Jobs.Persistence.Neo4j.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Jobs.Persistence.Neo4j.Repositories
{
    public class JobRepository : IJobGraphRepository
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
                await _queryExecutor.CreateAsync(JobEntity.ToJobEntity(job), "JOB");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
