using System;
using System.IO;
using Npgsql;
using Microsoft.Extensions.Configuration;

namespace SQLConnection
{
    class Program
    {
        public static void Main(string[] args)
        {
            // build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();
            var value = configuration.GetValue<string>("appsettings:host", "local");
            Console.WriteLine(value);


            var connection = new ConnectionPostgre();
            configuration.GetSection("appSettings").Bind(connection);
            Console.WriteLine($"{connection.ConnectionString}");
            var c = connection.ConnectionString;


            var connectionString = configuration["connectionStrings:MyDb"];
            Console.WriteLine(connectionString);

            using (var conn = new NpgsqlConnection(c))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from contractors";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[2]} {reader[3]}");
                        }
                    }
                }


            }
            Console.ReadLine();
        }
    }
}