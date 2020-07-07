namespace VidlyStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class convertTaskTimeToTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tasks", "TaskTime", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tasks", "TaskTime", c => c.String());
        }
    }
}
