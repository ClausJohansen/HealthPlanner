using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthPlanner.Web.Models
{
    public class MealTimeModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public TimeSpan Time { get; set; }

        // public List<MealModel> Meals { get; set; }

        public string DayPlanId { get; set; }
        
    }
}