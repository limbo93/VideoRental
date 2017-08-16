namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMovieWithGreneTypeReference : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MembershipTypes", "GreneType_Id", "dbo.GreneTypes");
            DropIndex("dbo.MembershipTypes", new[] { "GreneType_Id" });
            AddColumn("dbo.Movies", "GreneTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "GreneTypeId");
            AddForeignKey("dbo.Movies", "GreneTypeId", "dbo.GreneTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.MembershipTypes", "GreneType_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "GreneType_Id", c => c.Byte());
            DropForeignKey("dbo.Movies", "GreneTypeId", "dbo.GreneTypes");
            DropIndex("dbo.Movies", new[] { "GreneTypeId" });
            DropColumn("dbo.Movies", "GreneTypeId");
            CreateIndex("dbo.MembershipTypes", "GreneType_Id");
            AddForeignKey("dbo.MembershipTypes", "GreneType_Id", "dbo.GreneTypes", "Id");
        }
    }
}
