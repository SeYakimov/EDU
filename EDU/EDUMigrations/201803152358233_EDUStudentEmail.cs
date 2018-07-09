namespace EDU.EDUMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EDUStudentEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExercisesBDs", "StudentEmail", c => c.String());
            DropColumn("dbo.ExercisesBDs", "StudentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExercisesBDs", "StudentId", c => c.Int(nullable: false));
            DropColumn("dbo.ExercisesBDs", "StudentEmail");
        }
    }
}
