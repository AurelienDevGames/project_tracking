namespace ThoughtBubbles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SuppressiondeMotivationclassnonutilisée : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Motivations", "AfternoonQuestion_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Motivations", "MorningQuestion_QuestionId", "dbo.Questions");
            DropIndex("dbo.Motivations", new[] { "AfternoonQuestion_QuestionId" });
            DropIndex("dbo.Motivations", new[] { "MorningQuestion_QuestionId" });
            DropTable("dbo.Motivations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Motivations",
                c => new
                    {
                        MotivationId = c.Int(nullable: false, identity: true),
                        Timestamp = c.DateTime(nullable: false),
                        AfternoonQuestion_QuestionId = c.Int(),
                        MorningQuestion_QuestionId = c.Int(),
                    })
                .PrimaryKey(t => t.MotivationId);
            
            CreateIndex("dbo.Motivations", "MorningQuestion_QuestionId");
            CreateIndex("dbo.Motivations", "AfternoonQuestion_QuestionId");
            AddForeignKey("dbo.Motivations", "MorningQuestion_QuestionId", "dbo.Questions", "QuestionId");
            AddForeignKey("dbo.Motivations", "AfternoonQuestion_QuestionId", "dbo.Questions", "QuestionId");
        }
    }
}
