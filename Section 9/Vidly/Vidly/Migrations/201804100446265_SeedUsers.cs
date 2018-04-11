namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'df1dea82-addb-43b4-9592-11cf2a56b971', N'admin@vidly.com', 0, N'AAPrOGN3ojKm6xkoxJDL7YQwIK0EQJ9uNyvhwzRa6SNXsVeeOA9IkcHgmjWIKJVozw==', N'6f705a94-2f80-47a1-bd4a-25d9c784cec5', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e5bdcb0a-a890-4e75-a5f6-6087d2b1369e', N'guest@vidly.com', 0, N'AAzaD99h549pGRIeyPNv+2M0sQGa0m5lES058+TX3oHVCfkaALvEZhPSBxa4DNq1ow==', N'c400b797-8dd7-4566-9bd3-97a4cb364f16', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
            
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'10cc288d-fd2e-435b-a7e1-10d0a4c6569a', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'df1dea82-addb-43b4-9592-11cf2a56b971', N'10cc288d-fd2e-435b-a7e1-10d0a4c6569a')
            ");
        }

        public override void Down()
        {
        }
    }
}
