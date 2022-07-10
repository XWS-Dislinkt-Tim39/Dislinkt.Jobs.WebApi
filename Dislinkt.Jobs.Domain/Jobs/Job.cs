using System;

namespace Dislinkt.Jobs.Domain.Jobs
{
    public class Job
    {
      
        public Guid Id { get; }
        public DateTime StartDateTime { get; }
        public DateTime EndDateTime { get; }
        public Guid PublisherId { get; }
        public string PositionName { get; }
        public string Description { get; }
        public string[] DailyActivities { get; }
        public string[] Requirements { get; }
        public Seniority Seniority { get; }

        public Job(Guid id,DateTime startDateTime,DateTime endDateTime, Guid publisherId, string positionName, string description, 
            string[] dailyActivities, string[] requirements, Seniority seniority)
        {
            Id = id;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            PublisherId = publisherId;
            PositionName = positionName;
            Description = description;
            DailyActivities = dailyActivities;
            Requirements = requirements;
            Seniority = seniority;
        }
        public Job(Guid id, string positionName, Seniority seniority)
        {
            Id = id;
            PositionName = positionName;
            Seniority = seniority;
        }
    }
}
