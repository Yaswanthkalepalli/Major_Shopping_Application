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
    public class CategoryController : ApiController
    {
        ShoopingDal shoopingDal = new ShoopingDal();
        // GET: api/Category
        public IEnumerable<Categories> Get()
        {
            List<Categories> listCat = new List<Categories>();
            listCat = shoopingDal.GetCategories();
            return listCat;
        }

        //GET: api/Category/5
        public List<CategoryModel> Get(int id)
        {
            List<Categories> catList = new List<Categories>();
            List<CategoryModel> model = new List<CategoryModel>();
            catList = shoopingDal.FindCategories(id);
            foreach(var items in catList)
            {
                CategoryModel cat = new CategoryModel();
                cat.catID = items.catID;
                cat.catName = items.catName;
                cat.catImg = items.catImg;
                model.Add(cat);
            }
            return model;
        }

            // POST: api/Category
            public void Post([FromBody]ShoopingApplicationModel value)
            {
                Categories cat = new Categories();
                cat.catName = value.catName;
                byte[] bytes;
                var httpreq = HttpContext.Current.Request;
                var postedFile = httpreq.InputStream;
                using(BinaryReader br = new BinaryReader(postedFile))
                {
                    bytes = br.ReadBytes(httpreq.ContentLength);
                }
                cat.catImg = bytes;
                shoopingDal.Insertcategories(cat);
            }

        // PUT: api/Category/5
        public void Put(int id, [FromBody]CategoryModel value)
        {
            List<Categories> catList = new List<Categories>();
            List<CategoryModel> model = new List<CategoryModel>();
            catList = shoopingDal.Updatecategories(id);

        }

        // DELETE: api/Category/5
        public void Delete(int id)
        {

        }


    }
}
