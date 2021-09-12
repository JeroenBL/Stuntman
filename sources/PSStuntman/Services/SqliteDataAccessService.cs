using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PSStuntman.Services
{
    public class SqliteDataAccessService
    {
        private IDbConnection _connection;

        public SqliteDataAccessService()
        {
            GetDBConnection();
        }

        private void GetDBConnection()
        {
            var dllLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var dbPath = Path.Combine(dllLocation);
            _connection = new SQLiteConnection($"Data Source={dbPath}\\Stuntman.db");
            _connection.Open();
        }

        public async Task<List<GenericModel>> GetRecordFromDatabase<GenericModel>(string query)
        {
            var output = await _connection.QueryAsync<GenericModel>(query, new DynamicParameters()).ConfigureAwait(false);
            _connection.Close();
            return output.ToList();
        }

        public void CreateRecordInDatabase(string query, object obj)
        {
            _connection.Execute(query, obj);
            _connection.Close();
        }
    }
}