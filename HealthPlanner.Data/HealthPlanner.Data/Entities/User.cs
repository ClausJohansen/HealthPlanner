using HealthPlanner.Data.Utility;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthPlanner.Data.Entities
{
    public class User : EntityBase
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
