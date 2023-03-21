using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TripAdvisorApi.Models;
using Npgsql;

namespace TripAdvisorApi.Bal
{
    public class NearbyHelper :Helper 
    {
        public List<t_nearby> GetAll()
        {
            List<t_nearby> nearbylist = new List<t_nearby>();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM t_nearby";
            cn.Open();
            NpgsqlDataReader sdr = cmd.ExecuteReader();
            while(sdr.Read())
            {
                var near = new t_nearby();
                near.c_nearbyid = Convert.ToInt32(sdr["c_nearbyid"]);
                near.c_placeid = Convert.ToInt32(sdr["c_placeid"]);
                near.c_description = sdr["c_description"].ToString();
                near.c_daystovisit = sdr["c_daystovisit"].ToString();
                near.c_timetovisit = sdr["c_timetovisit"].ToString();
                nearbylist.Add(near);
            }
            cn.Close();
            sdr.Close();
            return nearbylist;
        }


        public t_nearby GetOne(int id)
        {
            NpgsqlCommand cmd = new NpgsqlCommand();
                var near = new t_nearby();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM t_nearby WHERE c_nearbyid = @c_nearbyid";
            cmd.Parameters.AddWithValue("c_nearbyid", id);
            cn.Open();
            NpgsqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                near.c_nearbyid = Convert.ToInt32(sdr["c_nearbyid"]);
                near.c_placeid = Convert.ToInt32(sdr["c_placeid"]);
                near.c_description = sdr["c_description"].ToString();
                near.c_daystovisit = sdr["c_daystovisit"].ToString();
                near.c_timetovisit = sdr["c_timetovisit"].ToString();
               
            }
            cn.Close();
            sdr.Close();
            return near;
        }

        public bool Add(t_nearby near)
        {
            bool result = false;
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT INTO t_nearby(c_placeid,c_description,c_daystovisit,c_timetovisit) VALUES(@c_placeid,@c_description,@c_daystovisit,@c_timetovisit);";
            cmd.Parameters.AddWithValue("c_placeid", near.c_placeid);
            cmd.Parameters.AddWithValue("c_description", near.c_description);
            cmd.Parameters.AddWithValue("c_daystovisit", near.c_daystovisit);
            cmd.Parameters.AddWithValue("c_timetovisit", near.c_timetovisit);
            cn.Open();
            int n = cmd.ExecuteNonQuery();
            if(n > 0)
            {
                result = true;
            }
            cn.Close();
            return result;
        }

        public bool Update(t_nearby near)
        {
            bool result = false;
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "UPDATE t_nearby SET c_placeid = @c_placeid,c_description = @c_description,c_daystovisit = @c_daystovisit,c_timetovisit = @c_timetovisit WHERE c_nearbyid = @c_nearbyid";
            cmd.Parameters.AddWithValue("c_nearbyid", near.c_nearbyid);
            cmd.Parameters.AddWithValue("c_placeid", near.c_placeid);
            cmd.Parameters.AddWithValue("c_description", near.c_description);
            cmd.Parameters.AddWithValue("c_daystovisit", near.c_daystovisit);
            cmd.Parameters.AddWithValue("c_timetovisit", near.c_timetovisit);
            cn.Open();
            int n = cmd.ExecuteNonQuery();
            if(n > 0)
            {
                 result = true;
            }
            cn.Close();
            return result;

        }

        public bool Delete(int id)
        {
            bool result = false;
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE FROM t_nearby WHERE c_nearbyid = @c_nearbyid ";
            cmd.Parameters.AddWithValue("c_nearbyid", id);
            cn.Open();
            int n = cmd.ExecuteNonQuery();
            if (n > 0)
            {
                result = true;
            }
            cn.Close();
            return result;
        }
    }
}