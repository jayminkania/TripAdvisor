using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TripAdvisorApi.Models;
using Npgsql;

namespace TripAdvisorApi.Bal
{
    public class ReviewHelper :Helper
    {
        public List<t_review> GetAllReview()
        {
            List<t_review> DisplayReview = new List<t_review>();
            NpgsqlCommand cm = new NpgsqlCommand("select * from t_review", cn);
            cn.Open();
            NpgsqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                var review = new t_review();
                review.c_reviewid = Convert.ToInt32(dr["c_reviewid"]);
                review.c_userid = Convert.ToInt32(dr["c_userid"]);
                review.c_nearbyid = Convert.ToInt32(dr["c_nearbyid"]);
                review.c_reviewdate = Convert.ToDateTime(dr["c_reviewdate"]);
                review.c_review = dr["c_review"].ToString();
                DisplayReview.Add(review);
            }
            cn.Close();
            return DisplayReview;
        }

        public t_review GetOne(int id)
        {
            
            NpgsqlCommand cm = new NpgsqlCommand("select * from t_review where c_reviewid="+id, cn);
            cn.Open();
            NpgsqlDataReader dr = cm.ExecuteReader();
            var review = new t_review();
            if (dr.Read())
            {
                review.c_reviewid = Convert.ToInt32(dr["c_reviewid"]);
                review.c_userid = Convert.ToInt32(dr["c_userid"]);
                review.c_nearbyid = Convert.ToInt32(dr["c_nearbyid"]);
                review.c_reviewdate = Convert.ToDateTime(dr["c_reviewdate"]);
                review.c_review = dr["c_review"].ToString();
                
            }
            cn.Close();
            return review;
        }

        public bool Add(t_review data)
        {
            bool result = false;
            NpgsqlCommand cm = new NpgsqlCommand("insert into t_review (c_userid,c_nearbyid,c_reviewdate,c_review) values (@c_userid,@c_nearbyid,@c_reviewdate,@c_review)", cn);
            cm.Parameters.AddWithValue("@c_userid", data.c_userid);
            cm.Parameters.AddWithValue("@c_nearbyid", data.c_nearbyid);
            cm.Parameters.AddWithValue("@c_reviewdate", data.c_reviewdate);
            cm.Parameters.AddWithValue("@c_review", data.c_review);
            cn.Open();
            int n = cm.ExecuteNonQuery();
            if(n > 0)
            {
                result = true;
            }
            cn.Close();
            return result;
        }

        public bool Update(t_review data)
        {
            bool result = false;
            NpgsqlCommand cm = new NpgsqlCommand("update t_review set c_userid=@c_userid,c_nearbyid=@c_nearbyid,c_reviewdate=@c_reviewdate,c_review=@c_review where c_reviewid =@c_reviewid ", cn);
            cm.Parameters.AddWithValue("@c_userid", data.c_userid);
            cm.Parameters.AddWithValue("@c_nearbyid", data.c_nearbyid);
            cm.Parameters.AddWithValue("@c_reviewdate", data.c_reviewdate);
            cm.Parameters.AddWithValue("@c_review", data.c_review);
            cm.Parameters.AddWithValue("@c_reviewid", data.c_reviewid);
            cn.Open();
            int n = cm.ExecuteNonQuery();
            if (n > 0)
            {
                result = true;
            }
            cn.Close();
            return result;
        }


        public bool Delete(int id)
        {
            bool result = false;
            NpgsqlCommand cm = new NpgsqlCommand("delete from t_review  where c_reviewid =@c_reviewid ", cn);
            cm.Parameters.AddWithValue("@c_reviewid", id);
            cn.Open();
            int n = cm.ExecuteNonQuery();
            if (n > 0)
            {
                result = true;
            }
            cn.Close();
            return result;
        }
    }
}