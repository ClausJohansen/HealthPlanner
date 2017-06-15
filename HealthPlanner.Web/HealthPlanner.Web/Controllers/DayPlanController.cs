using HealthPlanner.Data;
using HealthPlanner.Data.Entities;
using HealthPlanner.Web.Models;
using HealthPlanner.Web.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthPlanner.Web.Controllers
{
    public class DayPlanController : Controller
    {
        DayPlanDb db = DatabaseManager.CreateDayPlanDb();

        // GET: DayPlan
        public ActionResult Index()
        {
            List<DayPlan> data = db.GetDayPlans(AccountManager.CurrentUserId);

            List<DayPlanModel> model = data.Select(record => new DayPlanModel()
            {
                Id = record.IdString,
                Name = record.Name
                // Times = data.

            }).ToList();

            return View(model);
        }

        // GET: DayPlan/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DayPlan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DayPlan/Create
        [HttpPost]
        public ActionResult Create(DayPlanModel input)
        {
            try
            {
                DayPlan data = new DayPlan();
                data.Name = input.Name;
                data.UserIdString = AccountManager.CurrentUserId;
                db.CreateDayPlan(data);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DayPlan/Edit/5
        public ActionResult Edit(string id)
        {
            DayPlan data = db.GetDayPlan(id);

            var model = new DayPlanModel
            {
                Id = data.IdString,
                Name = data.Name
            };

            if (data.MealTimes != null)
            {
                // Transfer data from data entity collection into MVC model collection.
                model.MealTimes = data.MealTimes
                    .Select(mealTime => new MealTimeModel
                    {
                        Id = mealTime.IdString,
                        Time = mealTime.Time,
                        Name = mealTime.Name,
                        Description = mealTime.Description
                    }).OrderBy(x => x.Time).ToList();
            }


            return View(model);
        }

        // POST: DayPlan/Edit/5
        [HttpPost]
        public ActionResult Edit(DayPlanModel input)
        {
            try
            {
                DayPlan data = db.GetDayPlan(input.Id);

                data.Name = input.Name;

                db.UpdateDayPlan(data);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(input);
            }
        }

        // GET: DayPlan/Delete/5
        public ActionResult Delete(string id)
        {
            try
            {
                db.DeleteDayPlan(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
