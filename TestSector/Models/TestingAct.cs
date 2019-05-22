using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestSector.Models
{
    public class TestingAct
    {
        public int Id { get; set; }
        [NotMapped]
        private int _testId { get; set; }
        public Test Test { get; set; }
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }
        [Display(Name = "Email пользователя")]
        public string UserEmail { get; set; }
        public bool IsFinished { get; set; }
        public Question CurrentQuestion { get; set; }
        [Display(Name = "Количество правильных ответов")]
        public int Score { get; set; }
        [Display(Name = "Процент правильных ответов")]
        public double Percentage { get; set; }
        public virtual List<UserAnswer> UserAnswers { get; set; }

        [NotMapped]
        public int TestId
        {
            get
            {
                return _testId;
            }
            set
            {
                _testId = value;
                Test = TestService.GetTestById(_testId);
            }
        }

        public int AddScore(int userAnswerId)
        {
            if (CurrentQuestion.CorrectAnswer.Id == userAnswerId)
                Score += 1;
            Percentage = GetPercentage();
            return Score;
        }

        public double GetPercentage()
        {
            return 100 / Test.Questions.Count * Score;
        }

    }
}