using EDU.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EDU.Controllers
{
    public class CheckYourselfController : Controller
    {
        TestContext db = new TestContext();
        [Authorize]
        public ActionResult Index()
        {
            if (HttpContext.User.IsInRole("teacher"))
            {
                var results = db.TestResults.ToList();
                ViewBag.Results = results;
                return View("TestResults");
            }
            else
            {
                var tests = db.Tests.ToList();
                ViewBag.Tests = tests;
            }
            return View();
        }
        [HttpGet]
        [Authorize]
        public ActionResult Test(int id, string title)
        {
            IEnumerable<Question> questions = db.Questions.Where(u => u.TestId == id).ToList();
            // IEnumerable<Answer> answers = db.Answers.Where(u => u.TestId == id).ToList();
            List<QA> QAs = new List<QA>();
            foreach (Question question in questions)
            {
                QA qa = new QA();
                qa.question = question.GetCopy();
                qa.answers = db.Answers.Where(u => u.QuestionId == question.Id).ToList();
                QAs.Add(qa);
            }
            //IQueryable<QA> qa = db.Questions.Where(q => q.TestId == id).Select(q => new QA
            //{
            //    question = new Question { Id = q.Id, TestId = q.TestId, Text = q.Text, Type = q.Type}

            //}, a => a.).AsQueryable();
            ViewBag.Title = title;
            return View(QAs);
        }
        [HttpPost]
        [Authorize]
        public ActionResult Test(List<TestAnswers> studentAnswers)
        {
            int count = 0;
            int countQ = 0;
            foreach (TestAnswers studentAnswer in studentAnswers)
            {
                countQ++;
                studentAnswer.rightAnswer = (db.Answers.Where(a => a.QuestionId == studentAnswer.questionId && a.isRight == true).FirstOrDefault()).Text;
                if (studentAnswer.rightAnswer == studentAnswer.studentAnswer)
                {
                    studentAnswer.isCorrect = true;
                    count++;
                }
                else
                {
                    studentAnswer.isCorrect = false; 
                }
            }

            TestBD t = new TestBD();
            t.Result = countQ == 0 ? 0 : (int)Math.Round((count * 1.0 / countQ * 100), 2);
            string userId = User.Identity.GetUserId();
            var user = (new ApplicationDbContext()).Users.FirstOrDefault(s => s.Id == userId);
            t.StudentEmail = user.Email;
            t.Date = DateTime.Now;
            db.TestResults.Add(t);
            db.SaveChanges();

            return Json(new { result = studentAnswers }, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult Test()
        {
            return Redirect("Index");
        }
        [HttpPost]
        [Authorize]
        public ActionResult FinishTest(IEnumerable<Answer> studentAnswers)
        {
            ViewBag.StudentAnswers = studentAnswers;
            return View();
        }
    }
}