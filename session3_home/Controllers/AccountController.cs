using Dal;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace session3_home.Controllers
{
    public class AccountController : Controller
    {
        UserContext ctx = new UserContext();
        public IActionResult LogIn()
        {

            return View();
        }

        public IActionResult SignUp()
        {

            return View();
        }

        [HttpPost]
        public IActionResult SignUp(string name, string userName, string email, string password)
        {

            if (ctx.users.Any(a => a.Username == userName && a.Password == password))
            {

                return RedirectToAction("LogIn");
            }
            User users = new User()
            {
                name = name,
                Username = userName,
                Email = email,
                Password = password
            };
            ctx.users.Add(users);
            ctx.SaveChanges();
            string url = $"Welcome?user={userName}";
            return Redirect(url);
        }
        [HttpPost]
        public IActionResult LogIn(string userName, string password)
        {

            if (ctx.users.Any(a => a.Username == userName && a.Password == password))
            {

                string url = $"Welcome?user={userName}";
                return Redirect(url);

            }
            return RedirectToAction("SignUp");
        }

        public IActionResult Welcome(string user)
        {
            var users = ctx.users.SingleOrDefault(a=> a.Username==user);
            ViewBag.ID = users.UserId;
            ViewBag.username = users.Username;
            return View();

        }
        public IActionResult Form(int id)
        {
            var user = ctx.users.Find(id);
            ViewBag.questionData = ctx.questions.ToList();
            ViewBag.ChoiceData = ctx.choices.ToList();
            return View(user);
        }


    }
}
          