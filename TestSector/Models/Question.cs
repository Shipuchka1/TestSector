using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestSector.Models
{
    public class Question
    {
        public int Id { get; set; }
        [NotMapped]
        public int UserAnswerId { get; set; }
        [InverseProperty("Questions")]
        public virtual List<Answer> Answers { get; set; }
        public  Answer CorrectAnswer { get; set; }
        public virtual List<Test> Tests { get; set; }
        public string Description { get; set; }
    }
}