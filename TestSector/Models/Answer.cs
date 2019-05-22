using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestSector.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual List<Question> Questions { get; set; }
    }
}