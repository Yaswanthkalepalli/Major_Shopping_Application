using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingBal;
using System.Drawing;
using Microsoft.VisualBasic;
using static System.Net.Mime.MediaTypeNames;

namespace ShoopingDAL
{
    public class ShoopingDal
    {

        public bool InsertUser(users userinput)
        {
            bool status = false;
            SqlConnection cn = new SqlConnection("server=yaswanthkalepal\\sqlexpress;Integrated Security=true;database=OnlineShopping");
            SqlCommand cmd = new SqlCommand("[dbo].[InsertUserRecord]", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            //cmd.Parameters.AddWithValue("@userID", userinput.userID);
            cmd.Parameters.AddWithValue("@UserName", userinput.userName);
            cmd.Parameters.AddWithValue("@UserEmail", userinput.userEmail);
            cmd.Parameters.AddWithValue("@UserPassword", userinput.userPassword);
            cmd.Parameters.AddWithValue("@UserPhone", userinput.userPhone);
            cmd.Parameters.AddWithValue("@UserAddress", userinput.userAddress);
            cmd.Parameters.AddWithValue("@UserCity", userinput.userCity);
            cmd.Parameters.AddWithValue("@UserState", userinput.userstate);
            cmd.Parameters.AddWithValue("@UserCountry", userinput.userCountry);
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

        public bool UpdateUser(users userUpdate)
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

        public bool Insertcategories(Categories categoryinput)
        {
            bool status = false;
            SqlConnection cn = new SqlConnection("server=yaswanthkalepal\\sqlexpress;Integrated Security=true;database=OnlineShopping");
            SqlCommand cmd = new SqlCommand("[dbo].[InsertCategoryRecord]", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
    
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

        public bool Updatecategories(int catID,Categories cat)
        {
            Categories catUpdate = new Categories();
            catUpdate.catID = catID;
            catUpdate.catName = cat.catName;
            catUpdate.catImg = cat.catImg;
            bool status = false;
            SqlConnection cn = new SqlConnection("server=yaswanthkalepal\\sqlexpress;Integrated Security=true;database=OnlineShopping");
            SqlCommand cmd = new SqlCommand("[dbo].[UpdateCategoreiesRecord]", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            cmd.Parameters.AddWithValue("@catID", catUpdate.catID);
            cmd.Parameters.AddWithValue("@catName", catUpdate.catName);
            cmd.Parameters.AddWithValue("@catImg", catUpdate.catImg);
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


        public List<Categories> GetCategories()
        {
            SqlConnection cn = new SqlConnection("server=yaswanthkalepal\\sqlexpress;Integrated Security=true;database=OnlineShopping");
            SqlCommand cmd = new SqlCommand("select * from  Categories", cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<Categories> catlist = new List<Categories>();
            while (dr.Read())
            {
                Categories c = new Categories();
                c.catID = Convert.ToInt32(dr["catID"]);
                c.catName = dr[1].ToString();
                byte[] photoArray = (byte[])dr["catImg"];
                MemoryStream stream = new MemoryStream(photoArray);
                c.catImg = stream.ToArray();
                catlist.Add(c);
            }
            cn.Close();
            return catlist;
        }
        
        public List<Categories> FindCategories(int catID)
        {
            List<Categories> catList = new List<Categories>();
            SqlConnection cn = new SqlConnection("server=yaswanthkalepal\\sqlexpress;Integrated Security=true;database=OnlineShopping");
            SqlCommand cmd = new SqlCommand("select * from  Categories where catID like '"+catID+"'", cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Categories category = new Categories();
            if (dr.HasRows)
            {
                dr.Read();
                category.catID = Convert.ToInt32(dr["catID"]);
                category.catName = dr["catName"].ToString();
                byte[] photoArray = (byte[])dr["catImg"];
                MemoryStream stream = new MemoryStream(photoArray);
                category.catImg = stream.ToArray();
                catList.Add(category);
            }
            cn.Close();
            return catList;
        }

        public bool DeletecategoryData(int catID)
        {
            bool status = false;
            SqlConnection cn = new SqlConnection("server=yaswanthkalepal\\sqlexpress;Integrated Security=true;database=OnlineShopping");
            SqlCommand cmd = new SqlCommand("[dbo].[DeleteCategoreiesRecord]", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@catID", catID);
            cn.Open();
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
    }
}
