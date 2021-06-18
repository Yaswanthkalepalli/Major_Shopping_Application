using Major_Shopping_Application.Models;
using ShoopingDAL;
using ShoppingBal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Major_Shopping_Application.Controllers
{
    public class OrderController : ApiController
    {
        ShoopingDal ShoopingDal = new ShoopingDal();
        // GET: api/Order
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Order/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Order
        public void Post([FromBody] ShoopingApplicationModel value)
        {
            orderDetails od = new orderDetails();
            od.deluserName = value.deluserName;
            od.deluserEmail = value.deluserEmail;
            od.delieveryAddress = value.delieveryAddress;
            od.delieveryCity = value.delieveryCity;
            od.delieveryState = value.delieveryState;
            od.delieveryPincode = value.delieveryPincode;

            ShoopingDal.InsertOrder(od);
        }

        // PUT: api/Order/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Order/5
        public void Delete(int id)
        {
        }
    }
}
