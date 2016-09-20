namespace ThoughtBubbles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClefEtrangereQuestionversProjet : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "Project_ProjectId", "dbo.Projects");
            DropIndex("dbo.Questions", new[] { "Project_ProjectId" });
            RenameColumn(table: "dbo.Questions", name: "Project_ProjectId", newName: "ProjectId");
            AlterColumn("dbo.Questions", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Questions", "ProjectId");
            AddForeignKey("dbo.Questions", "ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Questions", new[] { "ProjectId" });
            AlterColumn("dbo.Questions", "ProjectId", c => c.Int());
            RenameColumn(table: "dbo.Questions", name: "ProjectId", newName: "Project_ProjectId");
            CreateIndex("dbo.Questions", "Project_ProjectId");
            AddForeignKey("dbo.Questions", "Project_ProjectId", "dbo.Projects", "ProjectId");
        }
    }
}
