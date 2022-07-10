using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Jobs.Persistence.Neo4j.Factory
{
    public interface IDatabaseFactory
    {
        IDriver Create();
    }
}
