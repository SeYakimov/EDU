using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDU.Models
{
    public class TestAnswers
    {
        public int questionId { get; set; }
        public string studentAnswer { get; set; }
        public string rightAnswer { get; set; }
        public bool isCorrect { get; set; }
    }
}