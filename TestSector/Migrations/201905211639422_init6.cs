namespace TestSector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserAnswer", "TestingAct_Id", "dbo.TestingAct");
            DropIndex("dbo.UserAnswer", new[] { "TestingAct_Id" });
            RenameColumn(table: "dbo.UserAnswer", name: "TestingAct_Id", newName: "TestingActId");
            AlterColumn("dbo.UserAnswer", "TestingActId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserAnswer", "TestingActId");
            AddForeignKey("dbo.UserAnswer", "TestingActId", "dbo.TestingAct", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAnswer", "TestingActId", "dbo.TestingAct");
            DropIndex("dbo.UserAnswer", new[] { "TestingActId" });
            AlterColumn("dbo.UserAnswer", "TestingActId", c => c.Int());
            RenameColumn(table: "dbo.UserAnswer", name: "TestingActId", newName: "TestingAct_Id");
            CreateIndex("dbo.UserAnswer", "TestingAct_Id");
            AddForeignKey("dbo.UserAnswer", "TestingAct_Id", "dbo.TestingAct", "Id");
        }
    }
}
