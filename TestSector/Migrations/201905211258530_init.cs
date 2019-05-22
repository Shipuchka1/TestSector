namespace TestSector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Question_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Question", t => t.Question_Id)
                .Index(t => t.Question_Id);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        CorrectAnswer_Id = c.Int(),
                        Answer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Answer", t => t.CorrectAnswer_Id)
                .ForeignKey("dbo.Answer", t => t.Answer_Id)
                .Index(t => t.CorrectAnswer_Id)
                .Index(t => t.Answer_Id);
            
            CreateTable(
                "dbo.Test",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestingAct",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserEmail = c.String(),
                        IsFinished = c.Boolean(nullable: false),
                        Score = c.Int(nullable: false),
                        Percentage = c.Double(nullable: false),
                        CurrentQuestion_Id = c.Int(),
                        Test_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Question", t => t.CurrentQuestion_Id)
                .ForeignKey("dbo.Test", t => t.Test_Id)
                .Index(t => t.CurrentQuestion_Id)
                .Index(t => t.Test_Id);
            
            CreateTable(
                "dbo.UserAnswer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Answer_Id = c.Int(),
                        Question_Id = c.Int(),
                        TestingAct_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Answer", t => t.Answer_Id)
                .ForeignKey("dbo.Question", t => t.Question_Id)
                .ForeignKey("dbo.TestingAct", t => t.TestingAct_Id)
                .Index(t => t.Answer_Id)
                .Index(t => t.Question_Id)
                .Index(t => t.TestingAct_Id);
            
            CreateTable(
                "dbo.TestQuestion",
                c => new
                    {
                        Test_Id = c.Int(nullable: false),
                        Question_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Test_Id, t.Question_Id })
                .ForeignKey("dbo.Test", t => t.Test_Id, cascadeDelete: true)
                .ForeignKey("dbo.Question", t => t.Question_Id, cascadeDelete: true)
                .Index(t => t.Test_Id)
                .Index(t => t.Question_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAnswer", "TestingAct_Id", "dbo.TestingAct");
            DropForeignKey("dbo.UserAnswer", "Question_Id", "dbo.Question");
            DropForeignKey("dbo.UserAnswer", "Answer_Id", "dbo.Answer");
            DropForeignKey("dbo.TestingAct", "Test_Id", "dbo.Test");
            DropForeignKey("dbo.TestingAct", "CurrentQuestion_Id", "dbo.Question");
            DropForeignKey("dbo.Question", "Answer_Id", "dbo.Answer");
            DropForeignKey("dbo.TestQuestion", "Question_Id", "dbo.Question");
            DropForeignKey("dbo.TestQuestion", "Test_Id", "dbo.Test");
            DropForeignKey("dbo.Question", "CorrectAnswer_Id", "dbo.Answer");
            DropForeignKey("dbo.Answer", "Question_Id", "dbo.Question");
            DropIndex("dbo.TestQuestion", new[] { "Question_Id" });
            DropIndex("dbo.TestQuestion", new[] { "Test_Id" });
            DropIndex("dbo.UserAnswer", new[] { "TestingAct_Id" });
            DropIndex("dbo.UserAnswer", new[] { "Question_Id" });
            DropIndex("dbo.UserAnswer", new[] { "Answer_Id" });
            DropIndex("dbo.TestingAct", new[] { "Test_Id" });
            DropIndex("dbo.TestingAct", new[] { "CurrentQuestion_Id" });
            DropIndex("dbo.Question", new[] { "Answer_Id" });
            DropIndex("dbo.Question", new[] { "CorrectAnswer_Id" });
            DropIndex("dbo.Answer", new[] { "Question_Id" });
            DropTable("dbo.TestQuestion");
            DropTable("dbo.UserAnswer");
            DropTable("dbo.TestingAct");
            DropTable("dbo.Test");
            DropTable("dbo.Question");
            DropTable("dbo.Answer");
        }
    }
}
