using System.Data.Entity;

namespace EDU.Models
{
    public class EDUContext : DbContext
    {
        public EDUContext() :
            base("EDUContext")
        { }

        public DbSet<ExercisesBD> Exercises { get; set; }
    }
}