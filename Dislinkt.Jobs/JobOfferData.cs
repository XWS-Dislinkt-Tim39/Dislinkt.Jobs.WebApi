using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Jobs
{
    public class JobOfferData
    {
        /// <summary>
        /// Publisher id
        /// </summary>
        public Guid PublisherId { get; set; }
        /// <summary>
        /// Position name
        /// </summary>
        public string PositionName { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Daily activities
        /// </summary>
        public string DailyActivities { get; set; }
        /// <summary>
        /// Requirements
        /// </summary>
        public string Requirements { get; set; }
    }
}
