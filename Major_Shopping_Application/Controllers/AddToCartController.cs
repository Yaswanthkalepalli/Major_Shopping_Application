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

namespace Major_Shopping_Application.Controllers
{
    public class AddToCartController : ApiController
    {
        ShoopingDal shoopingDal = new ShoopingDal();
        // GET: api/AddToCart
        public IEnumerable<AddToCart> Get()
        {
            List<AddToCart> listCat = new List<AddToCart>();
            listCat = shoopingDal.GetAllFromCart();
            return listCat;
        }

        // GET: api/AddToCart/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AddToCart
        public void Post([FromBody] AddToCartModel value)
        {
            AddToCart cart = new AddToCart();
            cart.productID = value.productID;
            cart.productName = value.productName;
            cart.productPrice = value.productPrice;
            byte[] bytes;
            var httpreq = HttpContext.Current.Request;
            var postedFile = httpreq.InputStream;
            using (BinaryReader br = new BinaryReader(postedFile))
            {
                bytes = br.ReadBytes(httpreq.ContentLength);
            }
            cart.productImage = bytes;
            cart.quantity = value.quantity;
            shoopingDal.AddingToCart(cart);
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
