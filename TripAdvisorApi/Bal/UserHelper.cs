using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TripAdvisorApi.Models;

namespace TripAdvisorApi.Bal
{
    public class UserHelper:Helper
    {
        public bool Register(t_user data)
        {
            cn.Open();
            NpgsqlCommand cmd1 = new NpgsqlCommand("select * from t_user where c_email=@c_email", cn);
            cmd1.Parameters.AddWithValue("@c_email", data.c_email);
            NpgsqlDataReader dr = cmd1.ExecuteReader();
            if (dr.HasRows)
            {
                return false;
            }
            else
            {
                cn.Close();
                NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO t_user(c_username, c_email, c_pass, c_gender, c_address, c_cityid, c_mobile, c_uimage)VALUES (@c_username,@c_email,@c_pass,@c_gender,@c_address,@c_cityid,@c_mobile,@c_uimage)", cn);
                cmd.Parameters.AddWithValue("@c_username", data.c_username);
                cmd.Parameters.AddWithValue("@c_address", data.c_address);
                cmd.Parameters.AddWithValue("@c_gender", data.c_gender);
                cmd.Parameters.AddWithValue("@c_email", data.c_email);
                cmd.Parameters.AddWithValue("@c_pass", data.c_pass);
                cmd.Parameters.AddWithValue("@c_mobile", data.c_mobile);
                cmd.Parameters.AddWithValue("@c_cityid", data.c_cityid);
                cmd.Parameters.AddWithValue("@c_uimage", data.c_uimage);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                return true;
            }
        }

        public t_user Login(VM_login data)
        {
            cn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("select * from t_user where c_email=@c_email AND c_pass=@c_pass", cn);
            cmd.Parameters.AddWithValue("@c_email", data.c_email);
            cmd.Parameters.AddWithValue("@c_pass", data.c_pass);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            var user = new t_user();
            if (dr.Read())
            {
                user.c_userid = Convert.ToInt32(dr["c_userid"]);
              user.c_username= dr["c_username"].ToString();
              
            }
            cn.Close();
            return user;


        }
    }
}