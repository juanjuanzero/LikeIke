namespace LikeIke.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotationBugFix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "TaskName", c => c.String(maxLength: 80));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "TaskName", c => c.String());
        }
    }
}
