namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmailAndDrivingLicenseToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Email", c => c.String(maxLength: 255));
            AddColumn("dbo.AspNetUsers", "DrivingLicense", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DrivingLicense");
            DropColumn("dbo.AspNetUsers", "Email");
        }
    }
}
