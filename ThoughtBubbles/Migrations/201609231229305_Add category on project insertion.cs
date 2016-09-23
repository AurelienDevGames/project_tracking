namespace ThoughtBubbles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addcategoryonprojectinsertion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryLabel = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            AddColumn("dbo.Projects", "Category_CategoryId", c => c.Int());
            CreateIndex("dbo.Projects", "Category_CategoryId");
            AddForeignKey("dbo.Projects", "Category_CategoryId", "dbo.Categories", "CategoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Projects", new[] { "Category_CategoryId" });
            DropColumn("dbo.Projects", "Category_CategoryId");
            DropTable("dbo.Categories");
        }
    }
}
