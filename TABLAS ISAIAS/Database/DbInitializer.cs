using Microsoft.Data.Sqlite;
using System.IO;

namespace FitLife.Database
{
    public static class DbInitializer
    {
        private const string DbFilePath = "fitlife.db";
        private const string SqlFilePath = "queries.sql";

        public static void Initialize()
        {
            if (!File.Exists(DbFilePath))
            {
                using var connection = new SqliteConnection($"Data Source={DbFilePath}");
                connection.Open();

                if (File.Exists(SqlFilePath))
                {
                    string sql = File.ReadAllText(SqlFilePath);
                    var command = connection.CreateCommand();
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        public static string GetConnectionString() => $"Data Source={DbFilePath}";
    }
}
