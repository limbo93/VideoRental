namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieAndGreneType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GreneTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Grene = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ReleseDate = c.DateTime(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        NumberInStock = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.MembershipTypes", "GreneType_Id", c => c.Byte());
            CreateIndex("dbo.MembershipTypes", "GreneType_Id");
            AddForeignKey("dbo.MembershipTypes", "GreneType_Id", "dbo.GreneTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MembershipTypes", "GreneType_Id", "dbo.GreneTypes");
            DropIndex("dbo.MembershipTypes", new[] { "GreneType_Id" });
            DropColumn("dbo.MembershipTypes", "GreneType_Id");
            DropTable("dbo.Movies");
            DropTable("dbo.GreneTypes");
        }
    }
}
