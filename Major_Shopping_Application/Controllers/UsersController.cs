using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShoopingDAL;
using ShoppingBal;
using Major_Shopping_Application.Models;
using System.Web.Http.Cors;

namespace Major_Shopping_Application.Controllers
{
    [EnableCors(headers: "*", methods: "*", origins: "*")]
    public class UsersController : ApiController
    {
        
        // GET: api/Users
        ShoopingDal ShoopingDal = new ShoopingDal();
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Users/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Users
        [EnableCors(headers: "*", methods: "*", origins: "*")]
        public void Post([FromBody]ShoopingApplicationModel value)
        {
            users u = new users();
            u.userName = value.userName;
            u.userEmail = value.userEmail;
            u.userPassword = value.userPassword;
            u.userPhone = Convert.ToInt32(value.userPhone);
            u.userAddress = value.userAddress;
            u.userCity = value.userCity;
            u.userstate = value.userstate;
            u.userCountry = value.userCountry;
            ShoopingDal.InsertUser(u);
        }

        // PUT: api/Users/5
        public void Edit(int id, [FromBody]string value)
        {

        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {

        }
    }
}
