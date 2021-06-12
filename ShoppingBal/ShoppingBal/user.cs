﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBal
{
    public class user
    {
        public int userID { get; set; }
        public string userName { get; set; }
        public string userEmail { get; set; }
        public string userPassword { get; set; }
        public long userPhone { get; set; }
        public string userAddress { get; set; }
        public string userCity { get; set; }
        public string userstate { get; set; }
        public string userCountry { get; set; }
    }

    public class order : user
    {
        public int uID { get; set; }
        public int orderID { get; set; }
        public DateTime orderDate { get; set; }
        public DateTime requiredDate { get; set; }
        public DateTime shippedDate { get; set; }
        public string shipName { get; set; }
        public string shipAddress { get; set; }
        public string shipCity { get; set; }
        public string shipState { get; set; }
        public string shipCountry { get; set; }

    }

    public class orderdetails : order
    {
        public int oderId { get; set; }
        public int productID { get; set; }
        public decimal unitPrice { get; set; }
        public int quantity { get; set; }
        public float discount { get; set; }
    }
    public class productdetails : orderdetails
    {
        public int categoryID { get; set; }
        public int prodID { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public int productPrice { get; set; }
        public byte[] productImage { get; set; }
        public string productSize { get; set; }
        public int Quantity { get; set; }
    }

    public class feedback : productdetails
    {
        public int usersID { get; set; }
        public int proID { get; set; }
        public int feedBackID { get; set; }
        public string uName { get; set; }
        public string userMessage { get; set; }
    }
    public class AdminTable
    {
        public int adminID { get; set; }
        public string adminUserName { get; set; }
        public string adminPassword { get; set; }
    }

    public class Category
    {
        public int catID { get; set; }
        public string catName { get; set; }
        public byte[] catImg { get; set; }
    }
    public class OnlinePayment
    {

        public int userID { get; set; }
        public string userName { get; set; }
        public long cardNumber { get; set; }
        public int CVV { get; set; }
        public DateTime expDate { get; set; }
    }
}



