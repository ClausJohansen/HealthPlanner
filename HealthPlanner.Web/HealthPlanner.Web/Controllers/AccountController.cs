using HealthPlanner.Data;
using HealthPlanner.Data.Entities;
using HealthPlanner.Web.Models;
using HealthPlanner.Web.Utility;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace HealthPlanner.Web.Controllers
{
    public class AccountController : Controller
    {
        AccountDb db = DatabaseManager.CreateAccountDb();

        // GET: Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        //POST: Login
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(UserModel input)
        {
            User dbUser = db.GetUser(input.Username);

            if(EncodingManager.Encode(input.Password) == dbUser.Password)
            {
                IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;

                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, dbUser.IdString),
                    new Claim(ClaimTypes.Name, dbUser.Username)
                };

                var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                var signinProperties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = false,
                    ExpiresUtc = DateTime.Now.AddMinutes(20)
                };

                authManager.SignIn(signinProperties, identity);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Forkert brugernavn eller adgangskode.");
                return View();
            }

        }

        //GET: Logout
        public ActionResult Logout()
        {
            IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie, DefaultAuthenticationTypes.ExternalCookie);

            return RedirectToAction("Login");
        }

        //GET: Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        //POST: Create
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Create(UserModel input)
        {
            try
            {
                User data = new User
                {
                    Username = input.Username,
                    Password = EncodingManager.Encode(input.Password)
                };

                db.CreateUser(data);

                ViewBag.Usercreated = true;
            }
            catch(Exception e)
            {
                ViewBag.Usercreated = false;
                ViewBag.Errormessage = e.Message;
            }

            return View();
        }
    }
}