using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dislinkt.Jobs.Domain.Jobs;

namespace Dislinkt.Jobs
{
    public class UserData
    {
        /// <summary>
        /// ID of the user
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Username of the user
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Seniority of the user
        /// </summary>
        public Seniority Seniority { get; set; }
    }
}
