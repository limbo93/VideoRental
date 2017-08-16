namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertDataIntoDraneType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GreneTypes (Id,Grene) VALUES(1,'Comedy')");
            Sql("INSERT INTO GreneTypes (Id,Grene) VALUES(2,'Action')");
            Sql("INSERT INTO GreneTypes (Id,Grene) VALUES(3,'Family')");
            Sql("INSERT INTO GreneTypes (Id,Grene) VALUES(4,'Romance')");
            Sql("INSERT INTO GreneTypes (Id,Grene) VALUES(5,'Horror')");
            Sql("INSERT INTO GreneTypes (Id,Grene) VALUES(6,'Animation')");
        }
        
        public override void Down()
        {
        }
    }
}
