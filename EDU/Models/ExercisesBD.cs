using System;

namespace EDU.Models
{
    public class ExercisesBD
    {
        public int Id { get; set; }
        public string StudentEmail { get; set; }
        public int Score { get; set; }
        public int QuestionsCount { get; set; }
        public int Result { get; set; }
        public DateTime Date { get; set; }
    }
}