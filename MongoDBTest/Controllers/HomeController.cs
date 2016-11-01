using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDBTest.Models;

namespace MongoDBTest.Controllers
{
    public class HomeController : Controller
    {
        protected static IMongoClient client = new MongoClient("mongodb://prod:159632@ds139277.mlab.com:39277/testerkan");
        protected static IMongoDatabase database = client.GetDatabase("testerkan");
        UserList UserList;
        public ActionResult Index()
        {
            var col = database.GetCollection<BsonDocument>("Users");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse("58164c54dcba0f01c12e6b97"));

            var t = col.Find(filter).FirstOrDefault();
            if (t!=null)
            {
                UserList = new UserList()
                {
                    Id = t["_id"],
                    Name = t["Name"].ToString(),
                    Surname = t["Surname"].ToString(),
                    Department = t["Deparment"].ToString()
                };
            }

            return View(UserList);
        }
    }
}