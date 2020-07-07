namespace VidlyStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtaskForginKeyInImages : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "task_Id", "dbo.tasks");
            DropIndex("dbo.Images", new[] { "task_Id" });
            RenameColumn(table: "dbo.Images", name: "task_Id", newName: "taskId");
            AlterColumn("dbo.Images", "taskId", c => c.Int(nullable: false));
            CreateIndex("dbo.Images", "taskId");
            AddForeignKey("dbo.Images", "taskId", "dbo.tasks", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "taskId", "dbo.tasks");
            DropIndex("dbo.Images", new[] { "taskId" });
            AlterColumn("dbo.Images", "taskId", c => c.Int());
            RenameColumn(table: "dbo.Images", name: "taskId", newName: "task_Id");
            CreateIndex("dbo.Images", "task_Id");
            AddForeignKey("dbo.Images", "task_Id", "dbo.tasks", "Id");
        }
    }
}
