using Dislinkt.Jobs.Domain.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Jobs.Domain.Users
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public Seniority Seniority { get; set; }

        public User(Guid id, string username, Seniority seniority)
        {
            Id = id;
            Username = username;
            Seniority = seniority;
        }
    }
}
