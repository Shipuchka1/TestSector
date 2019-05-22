using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestSector.Models
{
    public class UserAnswer
    {
        public int Id { get; set; }
        public int TestingActId { get; set; }
        public Question Question { get; set; }
        public virtual Answer Answer { get; set; }
    }
}