﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TripAdvisor.Bal
{
    public class Helper
    {
        protected NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["pgconn"].ToString());
    }
}