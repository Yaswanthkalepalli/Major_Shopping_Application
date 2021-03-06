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

        public bool DeleteSingleItemFromCart(int productID)
        {
            bool status = false;
            SqlConnection cn = new SqlConnection("server=yaswanthkalepal\\sqlexpress;Integrated Security=true;database=OnlineShopping");
            SqlCommand cmd = new SqlCommand("delete from CartDetails where productID '" + productID + "'", cn);
            cmd.CommandType = CommandType.StoredProcedure;
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
        public bool DeleteItemsInCart()
        {
            bool status = false;
            SqlConnection cn = new SqlConnection("server=yaswanthkalepal\\sqlexpress;Integrated Security=true;database=OnlineShopping");
            SqlCommand cmd = new SqlCommand("[dbo].[DeleteCartRecord]", cn);
            cmd.CommandType = CommandType.StoredProcedure;
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


        public bool InsertOrder(orderDetails orderinput)
        {
            bool status = false;
            SqlConnection cn = new SqlConnection("server=yaswanthkalepal\\sqlexpress;Integrated Security=true;database=OnlineShopping");
            SqlCommand cmd = new SqlCommand("[dbo].[InsertOrderRecord]", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            //cmd.Parameters.AddWithValue("@orderID", orderinput.orderID);
            cmd.Parameters.AddWithValue("@deluserName", orderinput.deluserName);
            cmd.Parameters.AddWithValue("@deluserEmail", orderinput.deluserEmail);
            cmd.Parameters.AddWithValue("@delieveryAddress", orderinput.delieveryAddress);
            cmd.Parameters.AddWithValue("@delieveryCity", orderinput.delieveryCity);
            cmd.Parameters.AddWithValue("@delieveryState", orderinput.delieveryState);
            cmd.Parameters.AddWithValue("@delieveryPincode", orderinput.delieveryPincode);
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
        public bool ValidateUser(Login l)
        {
            SqlConnection cn = new SqlConnection("server=yaswanthkalepal\\sqlexpress;Integrated Security=true;database=OnlineShopping");
            SqlCommand cmd = new SqlCommand("[dbo].[ValidateLogin]", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@emailId", l.userEmail);
            cmd.Parameters.AddWithValue("@password", l.userPassword);
            cmd.Parameters.AddWithValue("@value", 0);
            bool status;
            cn.Open();
            cmd.Parameters["@value"].Direction = System.Data.ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int value = Convert.ToInt32(cmd.Parameters["@value"].Value);
            status = Convert.ToBoolean(cmd.Parameters["@value"].Value);
            if (status)
            {
                return true;
                cn.Close();
            }
            else
            {
                return false;
            }
            return status;
        }

        public bool InsertUser(users userinput)
        {
            bool status = false;
            SqlConnection cn = new SqlConnection("server=yaswanthkalepal\\sqlexpress;Integrated Security=true;database=OnlineShopping");
            SqlCommand cmd = new SqlCommand("[dbo].[InsertUserRecord]", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            cmd.Parameters.AddWithValue("@UserName", userinput.userName);
            cmd.Parameters.AddWithValue("@UserEmail", userinput.userEmail);
            cmd.Parameters.AddWithValue("@UserPassword", userinput.userPassword);
            cmd.Parameters.AddWithValue("@UserPhone", userinput.userPhone);
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

        public List<productdetails> FindProduct(int catID)
        {
            List<productdetails> prodlist = new List<productdetails>();
            SqlConnection cn = new SqlConnection("server=yaswanthkalepal\\sqlexpress;Integrated Security=true;database=OnlineShopping");
            SqlCommand cmd = new SqlCommand("select * from ProductDetails where categoryID like '" + catID + "'", cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    productdetails pd = new productdetails();
                    pd.productID = Convert.ToInt32(dr["productID"]);
                    pd.productName = dr["productName"].ToString();
                    pd.productDescription = dr["productDescription"].ToString();
                    //MemoryStream ms = new MemoryStream();
                    byte[] photoArray = (byte[])dr["productImage"];
                    MemoryStream ms = new MemoryStream(photoArray);
                    pd.productImage = ms.ToArray();
                    pd.productPrice = Convert.ToInt32(dr["productPrice"]);
                    pd.productSize = dr["productSize"].ToString();
                    pd.quantity = Convert.ToInt32(dr["quantity"]);
                    prodlist.Add(pd);
                }
            }
            cn.Close();
            return prodlist;
        }

        public bool InsertIntoCart(AddToCart addCart)
        {
            bool status = false;
            SqlConnection cn = new SqlConnection("server=yaswanthkalepal\\sqlexpress;Integrated Security=true;database=OnlineShopping");
            SqlCommand cmd = new SqlCommand("[dbo].[InsertIntoCart]", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            cmd.Parameters.AddWithValue("@productID", addCart.productID);
            cmd.Parameters.AddWithValue("@productName", addCart.productName);
            cmd.Parameters.AddWithValue("@productPrice", addCart.productPrice);
            cmd.Parameters.AddWithValue("@quantity", addCart.quantity);
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

        public List<AddToCart> GetAllFromCart()
        {
            List<AddToCart> cartList = new List<AddToCart>();
            SqlConnection cn = new SqlConnection("server=yaswanthkalepal\\sqlexpress;Integrated Security=true;database=OnlineShopping");
            SqlCommand cmd = new SqlCommand("select * from CartDetails", cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    AddToCart pd = new AddToCart();
                    pd.productID = Convert.ToInt32(dr["productID"]);
                    pd.productName = dr["productName"].ToString();
                    pd.productPrice = Convert.ToInt32(dr["productPrice"]);
                    pd.quantity = Convert.ToInt32(dr["quantity"]);
                    cartList.Add(pd);
                }
            }
            cn.Close();
            return cartList;
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
