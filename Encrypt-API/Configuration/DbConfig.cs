using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Encrypt_API.Configuration
{
    public static class DbConfig
    {
        /// <summary>
        /// Adicionar injecao dependencia do IDBConnection
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddConfigDB(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString;

            if (!Debugger.IsAttached)            
                connectionString = configuration?.GetConnectionString("Production") ?? "";            

            else
                connectionString = configuration?.GetConnectionString("Postgres") ?? "";


            NpgsqlConnection con = new NpgsqlConnection(connectionString);

            services.AddSingleton<IDbConnection>(con);
        }
    }
}
