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
    public class LoginDetailsController : ApiController
    {
        ShoopingDal ShoopingDal = new ShoopingDal();
        // GET: api/LoginDetails
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/LoginDetails/5
        public string Get(int id)
        {
            return "value";
        }
        [EnableCors(headers: "*", methods: "*", origins: "*")]
        // POST: api/LoginDetails
        public HttpResponseMessage PostUserLogin(LoginDetails l)
        {
            Login ld = new Login();
            ld.userEmail = l.userEmail;
            ld.userPassword = l.userPassword;
            bool res = false;
            res = ShoopingDal.ValidateUser(ld);
            if (res)
            {
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, res);
            }
        }

        // PUT: api/LoginDetails/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LoginDetails/5
        public void Delete(int id)
        {
        }
    }
}
