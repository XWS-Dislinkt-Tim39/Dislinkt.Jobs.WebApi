using Dislinkt.Jobs.Domain.Jobs;
using System;

namespace Dislinkt.Jobs.Persistence.Neo4j.Entities
{
    public class JobEntity : BaseEntity
    {
        public string PositionName { get; set; }
        public string Description { get; set; }
        public Seniority Seniority { get; set; }
        public Job ToJob()
            => new Job(this.Id, this.PositionName, this.Seniority);
        public static JobEntity ToJobEntity(Job job)
        {
            return new JobEntity
            {
                Id = job.Id,
                PositionName = job.PositionName,
                Seniority = job.Seniority
            };
        }
    }
}
