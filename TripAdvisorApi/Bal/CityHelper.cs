using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TripAdvisorApi.Models;

namespace TripAdvisorApi.Bal
{
    public class CityHelper:Helper
    {
        public List<t_city> GetAll()
        {
            DataTable dt = new DataTable();
            NpgsqlCommand cm = new NpgsqlCommand("select * from t_city", cn);
            cn.Open();
            NpgsqlDataReader datar = cm.ExecuteReader();
            if (datar.HasRows)
            {
                dt.Load(datar);
            }
            List<t_city> contactlist = new List<t_city>();
            contactlist = (from DataRow dr in dt.Rows

                           select new t_city()
                           {
                               c_cityid = Convert.ToInt32(dr["c_cityid"]),
                               c_cityname = dr["c_cityname"].ToString(),

                           }).ToList();
            cn.Close();
            return contactlist;
        }
    }
}