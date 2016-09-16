namespace GET2WORK.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.MotivationId)
                .ForeignKey("dbo.Questions", t => t.AfternoonQuestion_QuestionId)
                .ForeignKey("dbo.Questions", t => t.MorningQuestion_QuestionId)
                .Index(t => t.AfternoonQuestion_QuestionId)
                .Index(t => t.MorningQuestion_QuestionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        TimeOfTheDay = c.Int(nullable: false),
                        Project_ProjectId = c.Int(),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Projects", t => t.Project_ProjectId)
                .Index(t => t.Project_ProjectId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Motivations", "MorningQuestion_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Motivations", "AfternoonQuestion_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "Project_ProjectId", "dbo.Projects");
            DropIndex("dbo.Questions", new[] { "Project_ProjectId" });
            DropIndex("dbo.Motivations", new[] { "MorningQuestion_QuestionId" });
            DropIndex("dbo.Motivations", new[] { "AfternoonQuestion_QuestionId" });
            DropTable("dbo.Projects");
            DropTable("dbo.Questions");
            DropTable("dbo.Motivations");
        }
    }
}
