using HealthPlanner.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HealthPlanner.Backend.Utility
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