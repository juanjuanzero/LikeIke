namespace LikeIke.Migrations
{
    using LikeIke.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LikeIke.LikeIkeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LikeIke.LikeIkeContext context)
        {
            context.Task.AddOrUpdate(t => t.TaskId, 
                new Task {TaskId =1, DateDue= DateTime.Now , TaskName = "Important Task" , Description="Just a sample task", Duration=2, Complete=true, Important=true, Urgent=false},
                new Task { TaskId = 2, DateDue = DateTime.Now, TaskName = "Urgent Task", Description = "Just a sample task", Duration = 2, Complete = true, Important = false, Urgent = true },
                new Task { TaskId = 3, DateDue = DateTime.Now, TaskName = "Important and Urgent Task", Description = "Just a sample task", Duration = 2, Complete = true, Important = true, Urgent = true });
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
