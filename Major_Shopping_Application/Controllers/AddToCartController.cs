using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShoppingBal;
using ShoopingDAL;
using Major_Shopping_Application.Models;
using System.Web;
using System.IO;
using System.Web.Http.Cors;

namespace Major_Shopping_Application.Controllers
{
    
    [EnableCors(headers: "*", methods: "*", origins: "*")]
    public class AddToCartController : ApiController
    {
        ShoopingDal shoopingDal = new ShoopingDal();
        // GET: api/AddToCart
        public IEnumerable<AddToCart> get()
        {
            List<AddToCart> listcat = new List<AddToCart>();
            listcat = shoopingDal.GetAllFromCart();
            return listcat;
        }

        // GET: api/AddToCart/5
        public string Get(int id)
        {
            return "value";
        }

        [EnableCors(headers: "*", methods: "*", origins: "*")]
        // POST: api/AddToCart
        public void Post([FromBody] List<AddToCartModel> value)
        {
                AddToCart addcart = new AddToCart();
                for (int i = 0; i < value.Count; i++)
                {
                    addcart.productID = value[i].productID;
                    addcart.productName = value[i].productName;
                    addcart.productPrice = value[i].productPrice;
                    addcart.quantity = value[i].quantity;
                }
                shoopingDal.InsertIntoCart(addcart);
            }

        // PUT: api/AddToCart/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AddToCart/5
        public void Delete(int id)
        {
        }
    }
}
