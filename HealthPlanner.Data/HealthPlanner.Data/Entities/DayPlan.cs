using HealthPlanner.Data.Utility;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthPlanner.Data.Entities
{
    public class DayPlan : UserEntityBase
    {
        public string Name { get; set; }

        public List<MealTime> MealTimes { get; set; }
    }
}
