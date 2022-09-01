using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Jobs.Persistence.Neo4j.Factory
{
    public class DatabaseFactory : IDatabaseFactory
    {
        public IDriver Create()
        {
            var uri = "bolt://neo4j.jobs:7686";
            var user = "neo4j";
            var password = "dislinkt";
            return GraphDatabase.Driver(uri, AuthTokens.Basic(user, password));
        }
    }
}
