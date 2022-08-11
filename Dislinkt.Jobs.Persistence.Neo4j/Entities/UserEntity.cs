using Dislinkt.Jobs.Domain.Jobs;
using Dislinkt.Jobs.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Jobs.Persistence.Neo4j.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Username { get; set; }
        public Seniority Seniority { get; set; }

        public UserEntity(Guid id, string username, Seniority seniority)
        {
            Id = id;
            Username = username;
            Seniority = seniority;
        }

        public UserEntity(){}

        public User ToUser()
        => new User(Id, Username, Seniority);

        public static UserEntity ToUserEntity(User user)
        {
            return new UserEntity
            {
                Id = user.Id,
                Username = user.Username,
                Seniority = user.Seniority
            };
        }
    }
}
