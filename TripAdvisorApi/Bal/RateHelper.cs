using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TripAdvisorApi.Models;

namespace TripAdvisorApi.Bal
{
    public class RateHelper:Helper
    {
        public List<t_rate> GetAll()
        {
            List<t_rate> disp = new List<t_rate>();
            NpgsqlCommand cmd = new NpgsqlCommand("Select * from t_rate", cn);
            cn.Open();
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var list = new t_rate();
                list.c_rateid = Convert.ToInt32(dr["c_rateid"]);
                list.c_userid = Convert.ToInt32(dr["c_userid"]);
                list.c_nearbyid = Convert.ToInt32(dr["c_nearbyid"]);
                list.c_ratedate = Convert.ToDateTime(dr["c_ratedate"]);
                list.c_rate = Convert.ToInt32(dr["c_rate"]);
                disp.Add(list);
            }
            cn.Close();
            return disp;

        }
        public t_rate GetOne(int c_rateid)
        {
            var list = new t_rate();
            NpgsqlCommand cmd = new NpgsqlCommand("Select * from t_rate where c_rateid="+c_rateid, cn);
            cn.Open();
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
           
                list.c_rateid = Convert.ToInt32(dr["c_rateid"]);
                list.c_userid = Convert.ToInt32(dr["c_userid"]);
                list.c_nearbyid = Convert.ToInt32(dr["c_nearbyid"]);
                list.c_ratedate = Convert.ToDateTime(dr["c_ratedate"]);
                list.c_rate = Convert.ToInt32(dr["c_rate"]);
             
            }
            cn.Close();
            return list;

        }
        public void Insert(t_rate data)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO t_rate(c_userid, c_nearbyid, c_ratedate, c_rate)VALUES (@c_userid,@c_nearbyid,@c_ratedate,@c_rate)", cn);
            cmd.Parameters.AddWithValue("@c_userid",data.c_userid);
            cmd.Parameters.AddWithValue("@c_nearbyid", data.c_nearbyid);
            cmd.Parameters.AddWithValue("@c_ratedate", data.c_ratedate);
            cmd.Parameters.AddWithValue("@c_rate", data.c_rate);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();


        }

        public void Update(t_rate data)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("UPDATE public.t_rate SET  c_userid=@c_userid, c_nearbyid=@c_nearbyid, c_ratedate=@c_ratedate, c_rate=@c_rate WHERE c_rateid=@c_rateid", cn);
            cmd.Parameters.AddWithValue("@c_rateid", data.c_rateid);
            cmd.Parameters.AddWithValue("@c_userid", data.c_userid);
            cmd.Parameters.AddWithValue("@c_nearbyid", data.c_nearbyid);
            cmd.Parameters.AddWithValue("@c_ratedate", data.c_ratedate);
            cmd.Parameters.AddWithValue("@c_rate", data.c_rate);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();


        }

        public void Delete(int c_rateid)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM t_rate WHERE c_rateid=@c_rateid", cn);
            cmd.Parameters.AddWithValue("@c_rateid", c_rateid);
          
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();


        }

    }
}