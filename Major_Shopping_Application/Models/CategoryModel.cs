using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Major_Shopping_Application.Models
{
    public class CategoryModel
    {
        public int catID { get; set; }
        public string catName { get; set; }
        public byte[] catImg { get; set; }
    }
}