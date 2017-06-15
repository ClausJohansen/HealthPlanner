using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthPlanner.Data.Utility
{
    public abstract class UserEntityBase : EntityBase
    {
        public ObjectId UserId { get; set; }

        [BsonIgnore]
        public string UserIdString
        {
            get
            {
                return UserId.ToString();
            }

            set
            {
                UserId = new ObjectId(value);
            }
        }
    }
}
