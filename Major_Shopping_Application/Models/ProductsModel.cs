using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Major_Shopping_Application.Models
{
    public class ProductsModel
    {
        public int categoryID { get; set; }
        public int productID { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public int productPrice { get; set; }
        public byte[] productImage { get; set; }
        public string productSize { get; set; }
        public int quantity { get; set; }
    }
}