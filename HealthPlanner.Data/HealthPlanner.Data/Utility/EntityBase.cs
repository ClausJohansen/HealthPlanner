using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HealthPlanner.Data.Utility
{
    public abstract class EntityBase
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonIgnore]
        public string IdString
        {
            get
            {
                return Id.ToString();
            }

            set
            {
                Id = new ObjectId(value);
            }
        }
    }
}
