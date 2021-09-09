using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;

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

        public List<GenericModel> ReadFromDatabase<GenericModel>(string query)
        {
            var output = _connection.Query<GenericModel>(query, new DynamicParameters());
            _connection.Close();
            return output.ToList();
        }

        public void AddToDatabase(string query, object obj)
        {
            _connection.Execute(query, obj);
            _connection.Close();
        }
    }
}