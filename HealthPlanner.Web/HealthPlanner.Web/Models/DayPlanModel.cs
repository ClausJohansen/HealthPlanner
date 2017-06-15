using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthPlanner.Web.Models
{
    public class DayPlanModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public List<MealTimeModel> MealTimes { get; set; } = new List<MealTimeModel>();
    }
}