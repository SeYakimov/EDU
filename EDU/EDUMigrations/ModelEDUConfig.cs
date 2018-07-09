namespace EDU.EDUMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ModelEDUConfig : DbMigrationsConfiguration<EDU.Models.EDUContext>
    {
        public ModelEDUConfig()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"EDUMigrations";
            ContextKey = "EDU.Models.EDUContext";
        }

        protected override void Seed(EDU.Models.EDUContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
