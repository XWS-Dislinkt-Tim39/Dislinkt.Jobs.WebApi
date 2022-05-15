using System;

namespace Dislinkt.Jobs.Domain.Jobs
{
    public class Job
    {
        public Guid Id { get; }
        public Guid PublisherId { get; }
        public string PositionName { get; }
        public string Description { get; }
        public string DailyActivities { get; }
        public string Requirements { get; }

        public Job(Guid id, Guid publisherId, string positionName, string description, string dailyActivities, string requirements)
        {
            Id = id;
            PublisherId = publisherId;
            PositionName = positionName;
            Description = description;
            DailyActivities = dailyActivities;
            Requirements = requirements;
        }
    }
}
