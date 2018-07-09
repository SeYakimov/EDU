using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDU.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public bool isRight { get; set; }

        public Answer GetCopy()
        {
            Answer a = new Answer();
            a.Id = this.Id;
            a.TestId = this.TestId;
            a.QuestionId = this.QuestionId;
            a.Text = this.Text;
            a.isRight = this.isRight;
            return a;
        }
    }
}