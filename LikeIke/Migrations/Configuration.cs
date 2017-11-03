namespace LikeIke.Migrations
{
    using LikeIke.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LikeIkeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LikeIkeContext context)
        {
            context.Task.AddOrUpdate(
                p => p.TaskId,
                new Task { TaskId = 1, TaskName = "First Task", DateDue = "10/30/2017", Description = "My first task", Duration = 10.5, Important = true, Complete = false },
                new Task { TaskId = 2, TaskName = "Second Task", DateDue = "11/01/2017", Description = "My second task", Duration = 10.5, Important = true, Complete = false },
                new Task { TaskId = 3, TaskName = "Third Task", DateDue = "11/03/2017", Description = "My third task", Duration = 10.5, Important = true, Complete = true },
                new Task { TaskId = 4, TaskName = "Fourth Task", DateDue = "11/04/2017", Description = "My fourt task", Duration = 10.5, Important = true, Complete = false },
                new Task { TaskId = 5, TaskName = "Fifth Task", DateDue = "11/05/2017", Description = "My fifth task", Duration = 10.5, Important = true, Complete = false }
                    );

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
