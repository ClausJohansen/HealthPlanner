using HealthPlanner.Data.Entities;
using HealthPlanner.Data.Utility;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using System.Linq;

namespace HealthPlanner.Data
{
    public class DayPlanDb
    {
        IMongoDatabase database;
        IMongoCollection<DayPlan> collection;

        public DayPlanDb(string connectionString)
        {
            database = DatabaseManager.CreateConnection(connectionString);
            collection = database.GetCollection<DayPlan>("dayplan");
        }

        public List<DayPlan> GetDayPlans(string userId)
        {
            return collection.Find(dayPlan => dayPlan.UserId == new ObjectId(userId)).ToListAsync().Result;
        }

        public DayPlan GetDayPlan(string id)
        {
            return collection.Find(dayPlan => dayPlan.Id == new ObjectId(id)).SingleAsync().Result;
        }

        public DayPlan GetDayPlanByMealTimeId(string id)
        {
            FilterDefinitionBuilder<DayPlan> dayPlanFdb = Builders<DayPlan>.Filter;
            FilterDefinitionBuilder<MealTime> mealTimeFilterFdb = Builders<MealTime>.Filter;

            FilterDefinition<DayPlan> filter = dayPlanFdb.ElemMatch("MealTimes", mealTimeFilterFdb.Eq("_id", new ObjectId(id)));

            return collection.Find(filter).First();
        }

        public void CreateDayPlan(DayPlan data)
        {
            collection.InsertOne(data);
        }

        public void UpdateDayPlan(DayPlan data)
        {
            collection.ReplaceOne(dayPlan => dayPlan.Id == data.Id, data);
        }

        public void DeleteDayPlan(string id)
        {
            collection.DeleteOne(dayPlan => dayPlan.Id == new ObjectId(id));
        }
    }
}
