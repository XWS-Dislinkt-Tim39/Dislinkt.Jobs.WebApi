using Dislinkt.Jobs.Domain.Jobs;
using Dislinkt.Jobs.Persistance.MongoDB.Attributes;
using System;
using MongoDB.Driver.GeoJsonObjectModel.Serializers;

namespace Dislinkt.Jobs.Persistance.MongoDB.Entities
{
    [CollectionName("Jobs")]
    public class JobEntity : BaseEntity
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public Guid PublisherId { get; set; }
        public string PositionName { get; set; }
        public string Description { get; set; }
        public string[] DailyActivities { get; set; }
        public Guid[] Requirements { get; set; }
        public Seniority Seniority { get; set; }
        public Job ToJob()
            => new Job(this.Id, this.StartDateTime,this.EndDateTime,this.PublisherId, this.PositionName, this.Description, this.DailyActivities, 
                this.Requirements, this.Seniority);
        public static JobEntity ToJobEntity(Job job)
        {
            return new JobEntity
            {
                Id = job.Id,
                StartDateTime=job.StartDateTime,
                EndDateTime=job.EndDateTime,
                PublisherId = job.PublisherId,
                Description = job.Description,
                DailyActivities = job.DailyActivities,
                PositionName = job.PositionName,
                Requirements = job.Requirements,
                Seniority = job.Seniority
            };
        }
    }
}
