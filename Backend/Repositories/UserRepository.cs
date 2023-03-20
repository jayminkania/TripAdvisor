using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Npgsql;

namespace Backend.Repositories
{
    public class UserRepository:CommonRepository,IUserRepository
    {
        public bool Register(t_user data)
        {
            conn.Open();
            NpgsqlCommand cmd1 = new NpgsqlCommand("select * from t_user where c_email=@c_email",conn);
            cmd1.Parameters.AddWithValue("@c_email", data.c_email);
            NpgsqlDataReader dr = cmd1.ExecuteReader();
            if (dr.HasRows)
            {
                return false;
            }
            else
            {
                conn.Close();
             NpgsqlCommand cmd =  new NpgsqlCommand("INSERT INTO t_user(c_username, c_email, c_pass, c_gender, c_address, c_cityid, c_mobile, c_uimage)VALUES (@c_username,@c_email,@c_pass,@c_gender,@c_address,@c_cityid,@c_mobile,@c_uimage);",conn);
            cmd.Parameters.AddWithValue("@c_username", data.c_username);
            cmd.Parameters.AddWithValue("@c_address", data.c_address);
            cmd.Parameters.AddWithValue("@c_gender", data.c_gender);
            cmd.Parameters.AddWithValue("@c_email", data.c_email);
            cmd.Parameters.AddWithValue("@c_pass", data.c_pass);
            cmd.Parameters.AddWithValue("@c_mobile", data.c_mobile);
            cmd.Parameters.AddWithValue("@c_cityid", data.c_cityid);
            cmd.Parameters.AddWithValue("@c_uimage", data.c_uimage);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
            }
        }

    //    public bool Login(VM_login data)
    //     {
    //         conn.Open();
    //         NpgsqlCommand cmd = new NpgsqlCommand("select * from t_user where c_email=@c_email AND c_pass=@c_pass", conn);
    //         cmd.Parameters.AddWithValue("@c_email", data.c_email);
    //         cmd.Parameters.AddWithValue("@c_pass", data.c_pass);
    //         NpgsqlDataReader dr = cmd.ExecuteReader();
    //         if (dr.Read())
    //         {
            
    //           //  HttpContext.Session.SetString("userid" , dr["c_userid"].ToString());
    //            // HttpContext.Session.SetString("username" , dr["c_username"].ToString());
    //            // HttpContext.Current.Session["userid"] = dr["c_userid"].ToString();
    //             //HttpContext.Current.Session["username"] = dr["c_username"].ToString();
    //             return true;
    //         }
    //         conn.Close();
    //         return false;


    //     }

        // public t_register GetProfile()
        // {
        //     NpgsqlCommand com = new NpgsqlCommand("Select c_userid, c_username,c_city,c_gender,c_email, c_pass From t_register", conn);
        //     NpgsqlDataAdapter da = new NpgsqlDataAdapter(com);
        //     DataSet ds = new DataSet();
        //     da.Fill(ds, "t_register");
        //     t_register userList = (from DataRow dr in ds.Tables["t_register"].Rows
        //                        where dr["c_userid"].ToString().Equals(HttpContext.Current.Session["userid"].ToString())
        //                        select new t_register()
        //                        {
        //                            c_userid = Convert.ToInt32(dr["c_userid"]),
        //                            c_username = dr["c_username"].ToString(),
        //                            c_city = dr["c_city"].ToString(),
        //                            c_gender = dr["c_gender"].ToString(),
        //                            c_email = dr["c_email"].ToString(),
        //                        }).ToList().FirstOrDefault();

        //     return userList;
        // }
    }
}