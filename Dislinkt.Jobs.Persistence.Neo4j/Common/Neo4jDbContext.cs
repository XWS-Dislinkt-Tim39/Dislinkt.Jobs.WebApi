using Dislinkt.Jobs.Persistence.Neo4j.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Jobs.Persistence.Neo4j.Common
{
    public class Neo4jDbContext
    {
        private readonly IDatabaseFactory _databaseFactory;

        public Neo4jDbContext(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }
    }
}
