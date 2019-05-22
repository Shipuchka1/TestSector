using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestSector.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual List<Question> Questions { get; set; }

        public Question GetNextQuestion(Question question)
        {
            if (question == null)
                return Questions[0];
            else
            {
                int index = Questions.IndexOf(Questions.FirstOrDefault(fr => fr.Id == question.Id));
                if (++index > Questions.Count - 1)
                    return null;
                else return Questions[index];
            }
        }
    }
}