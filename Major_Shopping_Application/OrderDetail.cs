//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Major_Shopping_Application
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderDetail
    {
        public int oderId { get; set; }
        public Nullable<int> productID { get; set; }
        public Nullable<decimal> unitPrice { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<float> discount { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual ProductDetail ProductDetail { get; set; }
    }
}
