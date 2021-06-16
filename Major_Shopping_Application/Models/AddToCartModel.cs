using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Major_Shopping_Application.Models
{
    public class AddToCartModel
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public long productPrice { get; set; }
        public byte[] productImage { get; set; }
        public int quantity { get; set; }
    }
}