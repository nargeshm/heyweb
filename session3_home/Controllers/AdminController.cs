using Dal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using session3_home.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace session3_home.Controllers
{
    public class AdminController : Controller
    {
        UserContext ctx = new UserContext();
        public IActionResult UserBoard()
        {
            ViewBag.Data = ctx.questions.ToList();
            ViewBag.choice = ctx.choices.ToList();
          var user= ctx.users.ToList();
            return View(user);
        }
        public IActionResult Create()
        {
            User user = new User();
            return View(user);
        }


        [HttpPost]
        public IActionResult Create(UserModelView model)
        {
            User user = new User()
            {
                name=model.name,
                Username = model.Username,
                Email = model.Email,
                Password = model.Password

            };
            ctx.users.Add(user);
            ctx.SaveChanges();
            return RedirectToAction("UserBoard");
        }

        public IActionResult Delete(int id)
        {
            var user = ctx.users.Find(id);
            ctx.Remove(user);
            ctx.SaveChanges();
            return RedirectToAction("UserBoard");
        }

        public IActionResult Edit(int id)
        {
            var user = ctx.users.Find(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User model)
        {

            ctx.users.Update(model);
            ctx.SaveChanges();
            return RedirectToAction("UserBoard");

        }
        //.........................................Question
        public IActionResult CreateQuestion()
        {
            Question question = new Question();
            return View(question);
        }
        [HttpPost]
        public IActionResult CreateQuestion(QuestionModelView model)
        {

            Question question = new Question()
            {
                Description = model.Description
            };
            ctx.questions.Add(question);
            ctx.SaveChanges();
            return RedirectToAction("UserBoard");
        }

      

        public IActionResult DeleteQuestion(int id)
        {
            var question = ctx.questions.Find(id);
            ctx.Remove(question);
            ctx.SaveChanges();
            return RedirectToAction("UserBoard");
        }

        public IActionResult EditQuestion(int id)
        {
            var question = ctx.questions.Find(id);
            return View(question);
        }

        [HttpPost]
        public IActionResult EditQuestion(Question model)
        {

            ctx.questions.Update(model);
            ctx.SaveChanges();
            return RedirectToAction("UserBoard");

        }
        //...........................................choice
        public IActionResult CreateChoice()
        {
            Choice choice = new Choice();
            return View(choice);
        }
        [HttpPost]
        public IActionResult CreateChoice(ChoiceModelView model)
        {

            Choice choice = new Choice()
            {
                ChoiceText = model.ChoiceText,
                  QuestionId  =model.QuestionId

            };
            ctx.choices.Add(choice);
            ctx.SaveChanges();
            return RedirectToAction("UserBoard");
        }



        public IActionResult DeleteChoice(int id)
        {
            var choice = ctx.choices.Find(id);
            ctx.Remove(choice);
            ctx.SaveChanges();
            return RedirectToAction("UserBoard");
        }

        public IActionResult EditChoice(int id)
        {
            var choice = ctx.choices.Find(id);
            return View(choice);
        }

        [HttpPost]
        public IActionResult EditChoice(Choice model)
        {

            ctx.choices.Update(model);
            ctx.SaveChanges();
            return RedirectToAction("UserBoard");

        }
        //submit
        [HttpPost]
        [Route("Submit")]
        public IActionResult Submit(IFormCollection iformCollection )

        {

            int Score = 0;
            string[] questionIds = iformCollection["QuestionId"];
            foreach (var QuestionId in questionIds)
            {
                var choices = ctx.choices.Find(QuestionId);
                choices.AnswerId++;
                choices.AnswerIstrue = true;
                int answerIdCorrect = ctx.questions.Find(int.Parse
                    (QuestionId)).choice.Where(a => a.AnswerIstrue == true).FirstOrDefault().ChoiceId;
                
                if (answerIdCorrect== int.Parse(iformCollection["Question " + QuestionId]))
                {
                    Score++;
                }
            }
            ViewBag.scoreData = Score; 
            return View();
        }

    }
}
