using System;
using System.Data.Entity;

namespace EDU.Models
{
    public class TestContext : DbContext
    {
        public TestContext() :
            base("TestContext")
        { }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<TestBD> TestResults { get; set; }
    }
}