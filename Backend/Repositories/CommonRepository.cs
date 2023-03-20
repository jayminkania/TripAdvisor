using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace Backend.Repositories
{
    public class CommonRepository
    {
        protected NpgsqlConnection con;
        
        public CommonRepository()
        {
            IConfiguration myConfig = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            con = new NpgsqlConnection(myConfig.GetConnectionString("pgconn"));
        }
    }
}