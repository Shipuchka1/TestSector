namespace TestSector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answer", "Question_Id", "dbo.Question");
            DropForeignKey("dbo.Question", "Answer_Id", "dbo.Answer");
            DropIndex("dbo.Answer", new[] { "Question_Id" });
            DropIndex("dbo.Question", new[] { "Answer_Id" });
            CreateTable(
                "dbo.QuestionAnswer",
                c => new
                    {
                        Question_Id = c.Int(nullable: false),
                        Answer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Question_Id, t.Answer_Id })
                .ForeignKey("dbo.Question", t => t.Question_Id, cascadeDelete: true)
                .ForeignKey("dbo.Answer", t => t.Answer_Id, cascadeDelete: true)
                .Index(t => t.Question_Id)
                .Index(t => t.Answer_Id);
            
            DropColumn("dbo.Answer", "Question_Id");
            DropColumn("dbo.Question", "Answer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Question", "Answer_Id", c => c.Int());
            AddColumn("dbo.Answer", "Question_Id", c => c.Int());
            DropForeignKey("dbo.QuestionAnswer", "Answer_Id", "dbo.Answer");
            DropForeignKey("dbo.QuestionAnswer", "Question_Id", "dbo.Question");
            DropIndex("dbo.QuestionAnswer", new[] { "Answer_Id" });
            DropIndex("dbo.QuestionAnswer", new[] { "Question_Id" });
            DropTable("dbo.QuestionAnswer");
            CreateIndex("dbo.Question", "Answer_Id");
            CreateIndex("dbo.Answer", "Question_Id");
            AddForeignKey("dbo.Question", "Answer_Id", "dbo.Answer", "Id");
            AddForeignKey("dbo.Answer", "Question_Id", "dbo.Question", "Id");
        }
    }
}
