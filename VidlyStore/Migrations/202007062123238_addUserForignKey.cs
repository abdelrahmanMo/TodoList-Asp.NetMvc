namespace VidlyStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserForignKey : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.tasks", name: "user_Id", newName: "ApplicationUserId");
            RenameIndex(table: "dbo.tasks", name: "IX_user_Id", newName: "IX_ApplicationUserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.tasks", name: "IX_ApplicationUserId", newName: "IX_user_Id");
            RenameColumn(table: "dbo.tasks", name: "ApplicationUserId", newName: "user_Id");
        }
    }
}
