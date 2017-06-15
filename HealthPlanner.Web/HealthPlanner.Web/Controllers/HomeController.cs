using HealthPlanner.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthPlanner.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            /*
            string connectionString = @"mongodb://healthplanner:8lAGviRDAiQhktuGEjPnw23DxAKUxPoqGxhxfAR8AdAj3cZnkbe2ithNROe7axz9lEU2EzyaAoIYVgWV8NbXig==@healthplanner.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            MongoClient client = new MongoClient(settings);

            IMongoDatabase db = client.GetDatabase("healthplanner");
            IMongoCollection<MealModel> collection = db.GetCollection<MealModel>("meal");

            List<MealModel> model = collection.Find(new BsonDocument()).ToListAsync().Result;
            */

            List<MealModel> model = new List<MealModel>(); // slet!!!

            return View(model);
        }
    }
}