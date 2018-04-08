namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertDataToGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) values (1, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) values (2, 'Thriller')");
            Sql("INSERT INTO Genres (Id, Name) values (3, 'Family')");
            Sql("INSERT INTO Genres (Id, Name) values (4, 'Romance')");
            Sql("INSERT INTO Genres (Id, Name) values (5, 'Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
