using Major_Shopping_Application.Models;
using ShoppingBal;
using ShoopingDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Major_Shopping_Application.Controllers
{
    [EnableCors(headers: "*", methods: "*", origins: "*")]
    public class ProductsController : ApiController
    {

        ShoopingDal shoopingDal = new ShoopingDal();
        // GET: api/Products
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [EnableCors(headers: "*", methods: "*", origins: "*")]
        // GET: api/Products/5
        public List<ProductsModel> Get(int id)
        {
            List<productdetails> list = new List<productdetails>();
            List<ProductsModel> plist = new List<ProductsModel>();
            list = shoopingDal.FindProduct(id);
            foreach (var items in list)
            {
                ProductsModel pm = new ProductsModel();
                pm.productID = items.productID;
                pm.productName = items.productName;
                pm.productDescription = items.productDescription;
                pm.productImage = items.productImage;
                pm.productPrice = items.productPrice;
                pm.productSize = items.productSize;
                pm.quantity = items.quantity;
                plist.Add(pm);
            }
            return plist;
        }

        // POST: api/Products
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
