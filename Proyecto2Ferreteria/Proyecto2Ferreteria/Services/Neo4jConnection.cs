using Neo4j.Driver;
using System.Threading.Tasks;

namespace Proyecto2Ferreteria.Services
{
    public class Neo4jConnection
    {
        private readonly IDriver _driver;

        public Neo4jConnection(string uri, string user, string password)
        {
            _driver = GraphDatabase.Driver(uri, AuthTokens.Basic(user, password));
        }

        public async Task<IResultCursor> RunQueryAsync(string query)
        {
            var session = _driver.AsyncSession();
            return await session.RunAsync(query);
        }
    }
}
