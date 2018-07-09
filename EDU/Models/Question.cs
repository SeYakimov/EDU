using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDU.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public int Type { get; set; }
        public string Text { get; set; }

        public Question GetCopy()
        {
            Question q = new Question();
            q.Id = this.Id;
            q.TestId = this.TestId;
            q.Type = this.Type;
            q.Text = this.Text;
            return q;
        }
    }
}