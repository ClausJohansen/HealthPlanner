using HealthPlanner.Data.Utility;
using System;

namespace HealthPlanner.Data.Entities
{
    public class MealTime : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public TimeSpan Time { get; set; }

        // public List<Meal> Meals { get; set; }
    }
}