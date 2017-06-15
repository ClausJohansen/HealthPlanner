using HealthPlanner.Data.Entities;
using HealthPlanner.Data.Utility;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthPlanner.Data
{
    public class AccountDb
    {
        IMongoDatabase database;
        IMongoCollection<User> collection;

        public AccountDb(string connectionString)
        {
            database = DatabaseManager.CreateConnection(connectionString);
            collection = database.GetCollection<User>("user");
        }

        public User GetUser(string username)
        {

            return collection.Find(user => user.Username == username).SingleAsync().Result;
        }

        public void CreateUser(User data)
        {
            collection.InsertOne(data);
        }
    }
}
