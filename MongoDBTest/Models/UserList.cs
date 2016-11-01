using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoDBTest.Models
{
    public class UserList
    {
        public object Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Department { get; set; }
    }
}