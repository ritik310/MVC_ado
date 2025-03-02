﻿using MVCCRUDwithADO.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCCRUDwithADO.Service
{
    public class UserDAL
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;       
        

        public List<UserModel> GetUsers()
        {
            cmd = new SqlCommand("sp_select", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<UserModel> list = new List<UserModel>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new UserModel
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = dr["Name"].ToString(),
                    Email = dr["Email"].ToString(),
                    Age = Convert.ToInt32(dr["Age"])
                });
            }
            return list;
        }

        public bool InsertUser(UserModel user)
        {
            try
            {
                cmd = new SqlCommand("sp_insert", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", user.Name);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@age", user.Age);
                conn.Open();
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool UpdateUser(UserModel user)
        {
            try
            {
                cmd = new SqlCommand("sp_update", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", user.Name);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@age", user.Age);
                cmd.Parameters.AddWithValue("@id", user.Id);
                conn.Open();
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int DeleteUser(int? id)
        {
            try
            {
                cmd = new SqlCommand("sp_delete", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}