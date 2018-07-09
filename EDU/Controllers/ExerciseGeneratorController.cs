using EDU.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EDU.Controllers
{
    public class ExerciseGeneratorController : Controller
    {
        EDUContext db = new EDUContext();

        Exercise exercise = new Exercise();
        [Authorize]
        public ActionResult Index()
        {
            if (HttpContext.User.IsInRole("teacher"))
            {
                var tests = db.Exercises;
                ViewBag.Tests = tests;
                return View("ExerciseGeneratorResults");
            }
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult NextExercise(string StudentAnswer)
        {
            exercise = (Exercise)Session["Exercise"];
            
            if (exercise.CompareTo(StudentAnswer))
            {
                exercise.IncScore();
            }
            exercise.IncQuestionNumber();

            exercise.RandomExercise();
            Session["Exercise"] = exercise;
            ViewBag.Exercise = exercise;
            return View();
        }
        [Authorize]
        [HttpGet]
        public ActionResult NextExercise()
        {
            exercise.RandomExercise();
            Session["Exercise"] = exercise;
            ViewBag.Exercise = exercise;
            return View();
        }
        [Authorize]
        public ActionResult FinishExercise()
        {
            if (Session["Exercise"] == null)
            {
                return Redirect("/ExerciseGenerator/Index");
            }
            exercise = (Exercise)Session["Exercise"];
            ExercisesBD exerBD = new ExercisesBD();
            string userId = User.Identity.GetUserId();
            var user = (new ApplicationDbContext()).Users.FirstOrDefault(s => s.Id == userId);
            exerBD.StudentEmail = user.Email;
            exerBD.Score = exercise.Score;
            exerBD.QuestionsCount = exercise.QuestionNumber;
            exerBD.Date = DateTime.Now;
            if (exercise.QuestionNumber <= 0)
            {
                exerBD.Result = 0;
            }
            else
            {
                exerBD.Result = (int)(Math.Round(exercise.Score * 1.0 / exercise.QuestionNumber, 2) * 100);
            }
            db.Exercises.Add(exerBD);
            db.SaveChanges();
            ViewBag.Exercise = exercise;
            Session["Exercise"] = null;
            return View();
        }
    }
}