﻿using Dislinkt.Jobs.Domain.Jobs;
using Dislinkt.Jobs.Persistance.MongoDB.Attributes;
using System;

namespace Dislinkt.Jobs.Persistance.MongoDB.Entities
{
    [CollectionName("Jobs")]
    public class JobEntity : BaseEntity
    {
        public Guid PublisherId { get; set; }
        public string PositionName { get; set; }
        public string Description { get; set; }
        public string DailyActivities { get; set; }
        public string Requirements { get; set; }
        public Job ToJob()
            => new Job(this.Id, this.PublisherId, this.PositionName, this.Description, this.DailyActivities, this.Requirements);
        public static JobEntity ToJobEntity(Job job)
        {
            return new JobEntity
            {
                Id = job.Id,
                PublisherId = job.PublisherId,
                Description = job.Description,
                DailyActivities = job.DailyActivities,
                PositionName = job.PositionName,
                Requirements = job.Requirements
            };
        }
    }
}
