using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestSector.Models;

namespace TestSector.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            if (Session["TestingActId"] != null && !TestService.GetTestingActById((int)Session["TestingActId"]).IsFinished) 
            {
                TestingAct testingAct = TestService.GetTestingActById((int)Session["TestingActId"]);
                return RedirectToAction("Next", new { questionId = testingAct.CurrentQuestion.Id });
            }
            ViewBag.Tests = TestService.GetAllTests();
            return View();
        }

        [HttpPost]
        public ActionResult Index(TestingAct testingAct)
        {
            Session["TestingActId"] = TestService.AddTestingAct(testingAct);
            testingAct.CurrentQuestion = testingAct.Test.GetNextQuestion(null);
            if (testingAct.CurrentQuestion != null)
                return RedirectToAction("Next",new {questionId = testingAct.CurrentQuestion.Id });
            else
                return RedirectToAction("Next", new { questionId = testingAct.CurrentQuestion.Id });
        }

        [HttpGet]
        public ActionResult Next(int questionId)
        {
            Question question = TestService.GetQuestionById(questionId);
            return View(question);
        }

        [HttpPost]
        public ActionResult Next(Question question)
        {
            TestingAct testingAct = TestService.GetTestingActById((int)Session["TestingActId"]);
            testingAct.AddScore(question.UserAnswerId);     
            TestService.AddUserAnswer(testingAct.CurrentQuestion, question.UserAnswerId, testingAct.Id);
            testingAct.CurrentQuestion = testingAct.Test.GetNextQuestion(testingAct.CurrentQuestion);
            if (testingAct.CurrentQuestion != null)
                return View(testingAct.CurrentQuestion);
            else
            {
                testingAct.IsFinished = true;
                return RedirectToAction("Finish");
            }
        }

        [HttpGet]
        public ActionResult Finish()
        {
            TestingAct testingAct = TestService.GetTestingActById((int)Session["TestingActId"]);
            return View(testingAct);
        }
    }
}