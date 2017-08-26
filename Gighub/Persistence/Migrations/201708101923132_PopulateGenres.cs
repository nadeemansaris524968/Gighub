namespace Gighub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Jazz')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Rock')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Pop')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Metal')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Blues')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Country')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Genres WHERE Id in (1, 2, 3, 4, 5, 6)");
        }
    }
}
