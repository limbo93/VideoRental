namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedusers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'104905b6-c14f-4ec7-b972-915b983aefbe', N'admin', N'AC7UkA+XOndFlIhZ7eEi+Sl1sHpOW5slcoKe7oxRCkru7vPxDMnXE2EgIzJmNeFjQw==', N'03ff5ac5-9da7-4dce-9401-5df46742f501', N'ApplicationUser')
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'6ec67a42-daae-44c3-961b-df42475ffa96', N'guest', N'AGg1r8ILTYLDEufOI1qpflLdbUzSJniXFTqjNofRmfKDbLsqHSpkDH7EfEH+7zzmUg==', N'08226cf1-bf6b-413b-aa34-115cf2cd83bb', N'ApplicationUser')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a6ff7ced-7899-4f96-852d-5eb3b44899ef', N'CanManageMovie')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'104905b6-c14f-4ec7-b972-915b983aefbe', N'a6ff7ced-7899-4f96-852d-5eb3b44899ef')

");


        }
        
        public override void Down()
        {
        }
    }
}
