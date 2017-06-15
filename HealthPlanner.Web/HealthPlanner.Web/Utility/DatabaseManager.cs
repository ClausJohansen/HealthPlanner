using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using HealthPlanner.Data;
using System.Configuration;

namespace HealthPlanner.Web.Utility
{
    public class DatabaseManager
    {
        public static AccountDb CreateAccountDb()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MongoDb"].ToString();
            return new AccountDb(connectionString);
        }

        public static DayPlanDb CreateDayPlanDb()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MongoDb"].ToString();
            return new DayPlanDb(connectionString);
        }
    }
}