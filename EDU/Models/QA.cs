using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDU.Models
{
    public class QA
    {
        public Question question { get; set; }
        public ICollection<Answer> answers { get; set; }
    }
}