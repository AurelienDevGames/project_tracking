namespace GET2WORK_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionandAnswer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "QuestionText", c => c.String());
            AddColumn("dbo.Questions", "AnswerText", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "AnswerText");
            DropColumn("dbo.Questions", "QuestionText");
        }
    }
}
