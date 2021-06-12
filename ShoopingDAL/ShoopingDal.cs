using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingBal;

namespace ShoopingDAL
{
    public class ShoopingDal
    {
        public bool InsertUser(user userinput)
        {
            bool status = false;
            SqlConnection cn = new SqlConnection("server=yaswanthkalepal\\sqlexpress;Integrated Security=true;database=OnlineShopping");
            SqlCommand cmd = new SqlCommand("[dbo].[InsertUserRecord]", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            //cmd.Parameters.AddWithValue("@userID", userinput.userID);
            cmd.Parameters.AddWithValue("@userName", userinput.userName);
            cmd.Parameters.AddWithValue("@userEmail", userinput.userEmail);
            cmd.Parameters.AddWithValue("@userPassword", userinput.userPassword);
            cmd.Parameters.AddWithValue("@userPhone", userinput.userPhone);
            cmd.Parameters.AddWithValue("@userAddress", userinput.userAddress);
            cmd.Parameters.AddWithValue("@userCity", userinput.userCity);
            cmd.Parameters.AddWithValue("@userState", userinput.userstate);
            cmd.Parameters.AddWithValue("@userCountry", userinput.userCountry);
            try
            {
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            cn.Close();
            return status;
        }

        public bool UpdateUser(user userUpdate)
        {
            bool status = false;
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineShoppingEntities"].ConnectionString);
            SqlCommand cmd = new SqlCommand("[dbo].[UpdateUserRecord]", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            cmd.Parameters.AddWithValue("@userID", userUpdate.userID);
            cmd.Parameters.AddWithValue("@userName", userUpdate.userName);
            cmd.Parameters.AddWithValue("@userEmail", userUpdate.userEmail);
            cmd.Parameters.AddWithValue("@userPassword", userUpdate.userPassword);
            cmd.Parameters.AddWithValue("@userAddress", userUpdate.userAddress);
            cmd.Parameters.AddWithValue("@userCity", userUpdate.userCity);
            cmd.Parameters.AddWithValue("@userState", userUpdate.userstate);
            cmd.Parameters.AddWithValue("@userCountry", userUpdate.userCountry);
            try
            {
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cn.Close();
            return status;
        }

        public bool InsertProduct(productdetails productInput)
        {
            bool status = false;
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineShoppingEntities"].ConnectionString);
            SqlCommand cmd = new SqlCommand("[dbo].[InsertProductRecord]", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            cmd.Parameters.AddWithValue("@productID", productInput.prodID);
            cmd.Parameters.AddWithValue("@productName", productInput.productName);
            cmd.Parameters.AddWithValue("@productDescription", productInput.productDescription);
            cmd.Parameters.AddWithValue("@productPrice", productInput.productPrice);
            cmd.Parameters.AddWithValue("@productImage", productInput.productImage);
            cmd.Parameters.AddWithValue("@productSize", productInput.productSize);
            cmd.Parameters.AddWithValue("@quantity", productInput.quantity);
            try
            {
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cn.Close();
            return status;
        }
        public bool UpdateProduct(productdetails productInput)
        {
            bool status = false;
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineShoppingEntities"].ConnectionString);
            SqlCommand cmd = new SqlCommand("[dbo].[UpdateProductRecord]", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            cmd.Parameters.AddWithValue("@productID", productInput.prodID);
            cmd.Parameters.AddWithValue("@productName", productInput.productName);
            cmd.Parameters.AddWithValue("@productDescription", productInput.productDescription);
            cmd.Parameters.AddWithValue("@productPrice", productInput.productPrice);
            cmd.Parameters.AddWithValue("@productImage", productInput.productImage);
            cmd.Parameters.AddWithValue("@productSize", productInput.productSize);
            cmd.Parameters.AddWithValue("@quantity", productInput.quantity);
            try
            {
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cn.Close();
            return status;
        }
        public bool DeleteProduct(int productID)
        {
            bool status = false;

            SqlConnection cn = new SqlConnection("server=yaswanthkalepal\\sqlexpress;Integrated Security=true;database=OnlineShopping");
            DataSet ds = new DataSet("OnlineShoppingEntities");
            SqlDataAdapter da = new SqlDataAdapter("select * from Categories", cn);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da.Fill(ds, "Categories");
            ds.Tables["Categories"].Rows.Find(productID).Delete();
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            da.Update(ds.Tables["products"]);
            status = true;
            return status;
        }

        public List<productdetails> GetProductsDetails()
        {
            SqlConnection cn = new SqlConnection("server=yaswanthkalepal\\sqlexpress;Integrated Security=true;database=northwind");
            SqlCommand cmd = new SqlCommand("select * from ProductDetails", cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<productdetails> prodlist = new List<productdetails>();
            while (dr.Read())
            {
                productdetails p = new productdetails();
                p.productID = Convert.ToInt32(dr["productID"]);
                p.productName = dr[1].ToString();
                p.productDescription = dr[2].ToString();
                p.productPrice = Convert.ToInt32(dr["productPrice"]);
                p.productImage = (byte[])dr["productImage"];
                p.productSize = dr[4].ToString();
                p.quantity = Convert.ToInt32(dr["quantity"]);
                prodlist.Add(p);
            }
            cn.Close();
            return prodlist;
        }

        public bool Insertcategories(Category categoryinput)
        {
            bool status = false;
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineShoppingEntities"].ConnectionString);
            SqlCommand cmd = new SqlCommand("[dbo].[InsertCategoryRecord]", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            cmd.Parameters.AddWithValue("@catID", categoryinput.catID);
            cmd.Parameters.AddWithValue("@catName", categoryinput.catName);
            cmd.Parameters.AddWithValue("@catImg", categoryinput.catImg);
            try
            {
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cn.Close();
            return status;
        }

        public bool Updatecategories(Category categoryupdate)
        {
            bool status = false;
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineShoppingEntities"].ConnectionString);
            SqlCommand cmd = new SqlCommand("[dbo].[UpdateCategoreiesRecord]", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            cmd.Parameters.AddWithValue("@catID", categoryupdate.catID);
            cmd.Parameters.AddWithValue("@catName", categoryupdate.catName);
            cmd.Parameters.AddWithValue("@catImg", categoryupdate.catImg);
            try
            {
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cn.Close();
            return status;
        }


        public List<Category> GetCategories()
        {
            SqlConnection cn = new SqlConnection("server=yaswanthkalepal\\sqlexpress;Integrated Security=true;database=OnlineShopping");
            SqlCommand cmd = new SqlCommand("select * from  [dbo].[Categories]()", cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<Category> catlist = new List<Category>();
            while (dr.Read())
            {
                Category c = new Category();
                c.catID = Convert.ToInt32(dr["catID"]);
                c.catName = dr[1].ToString();
                c.catImg = (Byte[])(dr["catImg"]);
                catlist.Add(c);
            }
            cn.Close();
            return catlist;
        }

        DataSet ds = new DataSet("onlineshopping");
        public bool DeletecategoryData(int catID)
        {
            bool status = false;
            SqlConnection cn = new SqlConnection("server=yaswanthkalepal\\sqlexpress;Integrated Security=true;database=OnlineShopping");
            SqlDataAdapter da = new SqlDataAdapter("select * from Categories", cn);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da.Fill(ds, "Categories");
            ds.Tables["Categories"].Rows.Find(catID).Delete();
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            da.Update(ds.Tables["products"]);
            status = true;
            return status;
        }
    }
}
