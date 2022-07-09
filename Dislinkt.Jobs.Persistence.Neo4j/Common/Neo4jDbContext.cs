using Dislinkt.Jobs.Persistence.Neo4j.Entities;
using Dislinkt.Jobs.Persistence.Neo4j.Factory;
using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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

        public async Task CreateAsync<T>(T t, string EntityType) where T : BaseEntity
        {
            var type = typeof(T);
            var types = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            var query = $"CREATE(:{EntityType} {{Id: \"{t.Id}\", ";

            foreach (var field in types)
            {
                query += field.Name.Substring(1, Math.Max(field.Name.IndexOf('>') - 1, 0)) + @": """;
                query += field.GetValue(t);
                query += @""", ";
            }

            query = query.Remove(query.Length - 2, 1);
            query += "})";


            IAsyncSession session = _databaseFactory.Create().AsyncSession();
            try
            {
                await session.RunAsync(query);
            }
            catch (Neo4jException ex)
            {
                Trace.WriteLine($"{query} - {ex}");
                throw;
            }
        }
    }
}
