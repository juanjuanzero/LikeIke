namespace LikeIke.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrgentDataField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "Urgent", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "Urgent");
        }
    }
}
