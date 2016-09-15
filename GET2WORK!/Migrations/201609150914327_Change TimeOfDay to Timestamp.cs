namespace GET2WORK_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTimeOfDaytoTimestamp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Questions", "TimeOfTheDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "TimeOfTheDay", c => c.Int(nullable: false));
            DropColumn("dbo.Questions", "Date");
        }
    }
}
