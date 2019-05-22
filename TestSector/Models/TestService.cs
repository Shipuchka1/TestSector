using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestSector.Models
{
    public class TestService
    {
        private static TestContext TestContext = new TestContext();

        public static List<Test> GetAllTests()
        {
            return TestContext.Tests.ToList();
        }

        public static List<Question> GetAllQuestion()
        {
            return TestContext.Questions.ToList();
        }

        public static List<Question> GetAllQuestionForTest(int testId)
        {
            return TestContext.Questions.Where(w=>w.Tests.Select(s=>s.Id).Contains(testId)).ToList();
        }

        public static Test GetTestById(int id)
        {
            return TestContext.Tests.FirstOrDefault(fr=>fr.Id==id);
        }

        public static TestingAct GetTestingActById(int id)
        {
            return TestContext.TestingActs.FirstOrDefault(fr => fr.Id == id);
        }

        public static Question GetQuestionById(int id)
        {
            return TestContext.Questions.FirstOrDefault(fr => fr.Id == id);
        }

        public static Answer GetAnswerById(int id)
        {
            return TestContext.Answers.FirstOrDefault(fr => fr.Id == id);
        }

        public static void AddUserAnswer(Question question, int answerId, int testingActId)
        {
            TestContext.UserAnswers.Add(new UserAnswer() { Question = question, Answer = GetAnswerById(answerId), TestingActId = testingActId });
            TestContext.SaveChanges();
        }

        public static int AddTestingAct(TestingAct testingAct)
        {
            TestContext.TestingActs.Add(testingAct);
            TestContext.SaveChanges();
            return TestContext.TestingActs.ToList().Last().Id;
        }

       
    }
}