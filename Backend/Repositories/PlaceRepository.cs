using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using Backend.Models;
using System.Data;

namespace Backend.Repositories
{
    public class PlaceRepository : CommonRepository, IPlaceRepository
    {
        public List<t_place> GetAll() 
        {
            List<t_place> placeList = new List<t_place>();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM t_place;";
            con.Open();
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                var place = new t_place();
                place.c_placeid = Convert.ToInt32(dr["c_placeid"]);
                place.c_placename = dr["c_placename"].ToString();
                place.c_description = dr["c_description"].ToString();
                place.c_placeimage = dr["c_placeimage"].ToString();
                place.c_preferedmonths = dr["c_preferedmonths"].ToString();
                placeList.Add(place);
            }
            dr.Close();
            con.Close();
            return placeList;
        }

        public t_place GetOne(int id) 
        {
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM t_place WHERE c_placeid = @c_placeid;";
            cmd.Parameters.AddWithValue("@c_placeid", id);
            con.Open();
            NpgsqlDataReader dr = cmd.ExecuteReader();
            var place = new t_place();
            if(dr.Read())
            {
                place.c_placeid = Convert.ToInt32(dr["c_placeid"]);
                place.c_placename = dr["c_placename"].ToString();
                place.c_description = dr["c_description"].ToString();
                place.c_placeimage = dr["c_placeimage"].ToString();
                place.c_preferedmonths = dr["c_preferedmonths"].ToString();
            }
            dr.Close();
            con.Close();
            return place;
        }

        public bool Add(t_place place) 
        {
            bool result = false;
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO t_place(c_placename, c_description, c_placeimage, c_preferedmonths) VALUES(@c_placename, @c_description, @c_placeimage, @c_preferedmonths);";
            cmd.Parameters.AddWithValue("@c_placename", place.c_placename);
            cmd.Parameters.AddWithValue("@c_description", place.c_description);
            cmd.Parameters.AddWithValue("@c_placeimage", place.c_placeimage);
            cmd.Parameters.AddWithValue("@c_preferedmonths", place.c_preferedmonths);
            con.Open();
            int n = cmd.ExecuteNonQuery();
            if(n > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }

        public bool Update(t_place place) 
        {
            bool result = false;
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE t_place SET c_placename = @c_placename, c_description = @c_description, c_placeimage = @c_placeimage, c_preferedmonths = @c_preferedmonths WHERE c_placeid = @c_placeid;";
            cmd.Parameters.AddWithValue("@c_placeid", place.c_placeid);
            cmd.Parameters.AddWithValue("@c_placename", place.c_placename);
            cmd.Parameters.AddWithValue("@c_description", place.c_description);
            cmd.Parameters.AddWithValue("@c_placeimage", place.c_placeimage);
            cmd.Parameters.AddWithValue("@c_preferedmonths", place.c_preferedmonths);
            con.Open();
            int n = cmd.ExecuteNonQuery();
            if(n > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }

        public bool Delete(int id) 
        {
            bool result = false;
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM t_place WHERE c_placeid = @c_placeid;";
            cmd.Parameters.AddWithValue("@c_placeid", id);
            con.Open();
            int n = cmd.ExecuteNonQuery();
            if(n > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }
    }
}