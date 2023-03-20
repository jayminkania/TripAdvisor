using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace Backend.Repositories
{
    public class CommonRepository
    {
<<<<<<< HEAD
         protected NpgsqlConnection  conn;
    public CommonRepository()
    {
        IConfiguration myconig= new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json")
        .Build();

       conn =new NpgsqlConnection(myconig.GetConnectionString("pgconn"));
    }
=======
        protected NpgsqlConnection con;
        
        public CommonRepository()
        {
            IConfiguration myConfig = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            con = new NpgsqlConnection(myConfig.GetConnectionString("pgconn"));
        }
>>>>>>> 05487d385d657cea14b1025b1ec76b45a5d6a61b
    }
}