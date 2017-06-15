using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthPlanner.Data.Utility
{
    public class DatabaseUtillity
    {
        public static string GenerateObjectId()
        {
            return ObjectId.GenerateNewId(DateTime.Now).ToString();
        }
    }
}
