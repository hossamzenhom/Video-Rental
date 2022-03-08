namespace VideoRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5820c4b6-a3fa-4735-a202-af915b7249c5', N'guest@vidly.com', 0, N'AHULastNMkYLBpJztfoGCNUryh/jTw9ak1q32hVo4AJfH8mDq6DQLRuQgNU76jvKmA==', N'e3473ab7-d60d-41a0-af72-e385564b3193', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fe001c00-2225-4553-89f8-132b5a6e43f3', N'admin@vidly.com', 0, N'AByydslmjgqb/8JZXnLzgB1QzMScX1H5LG6p1KkoG4yX/mRsUI3OT8IGe7TnlpbfRQ==', N'0959f75f-3be4-4b24-a12d-34efce546092', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'44b22d54-f3e8-49fd-bb69-d5f8f56bf90b', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fe001c00-2225-4553-89f8-132b5a6e43f3', N'44b22d54-f3e8-49fd-bb69-d5f8f56bf90b')
");
        }
        
        public override void Down()
        {
        }
    }
}
