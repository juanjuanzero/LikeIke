namespace LikeIke.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TaskDateMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "TaskName", c => c.String(nullable: false, maxLength: 80));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "TaskName", c => c.String());
        }
    }
}
