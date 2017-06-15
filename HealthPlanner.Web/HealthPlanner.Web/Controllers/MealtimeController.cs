using HealthPlanner.Data;
using HealthPlanner.Data.Entities;
using HealthPlanner.Data.Utility;
using HealthPlanner.Web.Models;
using HealthPlanner.Web.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthPlanner.Web.Controllers
{
    public class MealtimeController : Controller
    {
        DayPlanDb db = DatabaseManager.CreateDayPlanDb();

        // GET: Mealtime
        public ActionResult Index(string id)
        {
            return View();
        }

        // GET: Mealtime/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Mealtime/Create
        public ActionResult Create(string dayPlanId)
        {
            ViewBag.DayPlanId = dayPlanId;
            return View();
        }

        // POST: Mealtime/Create
        [HttpPost]
        public ActionResult Create(MealTimeModel model)
        {
            try
            {
                DayPlan parent = db.GetDayPlan(model.DayPlanId);

                if (parent.MealTimes == null)
                    parent.MealTimes = new List<MealTime>();

                MealTime data = new MealTime
                {
                    IdString = DatabaseUtillity.GenerateObjectId(),
                    Time = model.Time,
                    Name = model.Name,
                    Description = model.Description
                };

                parent.MealTimes.Add(data);

                db.UpdateDayPlan(parent);

                return RedirectToAction("Edit", "DayPlan", new { id = parent.IdString });
            }
            catch
            {
                return View();
            }
        }

        // GET: Mealtime/Edit/5
        public ActionResult Edit(string id)
        {
            DayPlan data = db.GetDayPlanByMealTimeId(id);
            MealTime mealTimeData = data.MealTimes.First(mealTime => mealTime.IdString == id);

            var model = new MealTimeModel
            {
                Id = mealTimeData.IdString,
                DayPlanId = data.IdString,

                Time = mealTimeData.Time,
                Name = mealTimeData.Name,
                Description = mealTimeData.Description
            };


            return View(model);
        }

        // POST: Mealtime/Edit/5
        [HttpPost]
        public ActionResult Edit(MealTimeModel input)
        {
            try
            {
                DayPlan data = db.GetDayPlanByMealTimeId(input.Id);
                MealTime update = data.MealTimes.First(mealTime => mealTime.IdString == input.Id);

                update.Time = input.Time;
                update.Name = input.Name;
                update.Description = input.Description;

                db.UpdateDayPlan(data);



                return RedirectToAction("Edit", "DayPlan", new { id = data.IdString });
            }
            catch
            {
                return View();
            }
        }

        // GET: Mealtime/Delete/5
        public ActionResult Delete(string id)
        {
            try
            {
                DayPlan data = db.GetDayPlanByMealTimeId(id);

                MealTime delete = data.MealTimes.First(mealTime => mealTime.IdString == id);
                data.MealTimes.Remove(delete);

                db.UpdateDayPlan(data);

                return RedirectToAction("Edit", "DayPlan", new { id = data.IdString });
            }
            catch
            {
                return View();
            }
        }

    }
}
