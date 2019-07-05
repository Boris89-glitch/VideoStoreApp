namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3853b0b2-dc67-4c35-8cee-7518683632f8', N'booris89@gmail.com', 0, N'APZLo76B/HipoG8uLSVLXsSH9kli5qKcgrY0xJZBFTL+pCCAjmR+61N9W6OZxlqInQ==', N'46d4f07c-7af9-420c-a744-3558f669817f', NULL, 0, 0, NULL, 1, 0, N'booris89@gmail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c3bf15ff-d7fc-4308-a4c0-45a26e01e8db', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3853b0b2-dc67-4c35-8cee-7518683632f8', N'c3bf15ff-d7fc-4308-a4c0-45a26e01e8db')


");
        }
        
        public override void Down()
        {
        }
    }
}
