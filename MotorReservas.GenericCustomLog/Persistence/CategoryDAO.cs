using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using GenericCustomLog.Model;

namespace GenericCustomLog.Persistence
{
    public class CategoryDAO
    {
        public List<Category> GetAllCategories()
        {
            List<Category> lstcategory = new List<Category>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BBTur"].ConnectionString);
            string sql = "GetAllCategories";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                Category category = new Category();
                category.Categoryid = int.Parse(dr["CategoryID"].ToString());
                category.Categoryname = dr["CategoryName"].ToString();

                lstcategory.Add(category);
            }

            con.Close();
            return lstcategory;
        }
    }
 }