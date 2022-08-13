namespace ProjectMuziek_DALS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BeluisterdLieds",
                c => new
                    {
                        BeluisterdLiedId = c.Int(nullable: false, identity: true),
                        Datum = c.DateTime(nullable: false),
                        GebruikerId = c.Int(nullable: false),
                        LiedId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BeluisterdLiedId)
                .ForeignKey("dbo.Gebruikers", t => t.GebruikerId, cascadeDelete: true)
                .ForeignKey("dbo.Lieds", t => t.LiedId, cascadeDelete: true)
                .Index(t => t.GebruikerId)
                .Index(t => t.LiedId);
            
            CreateTable(
                "dbo.Gebruikers",
                c => new
                    {
                        GebruikerId = c.Int(nullable: false, identity: true),
                        Voornaam = c.String(),
                        Wachtwoord = c.String(),
                        Email = c.String(),
                        IsLid = c.Boolean(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        IsSuperAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.GebruikerId);
            
            CreateTable(
                "dbo.Lieds",
                c => new
                    {
                        LiedId = c.Int(nullable: false, identity: true),
                        Titel = c.String(),
                        Producer = c.String(),
                        PlatenLabel = c.String(),
                        UitgaveJaar = c.String(),
                        GenreId = c.Int(nullable: false),
                        ZangerId = c.Int(nullable: false),
                        IsBeluisterd = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LiedId)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Zangers", t => t.ZangerId, cascadeDelete: true)
                .Index(t => t.GenreId)
                .Index(t => t.ZangerId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        naam = c.String(),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.Zangers",
                c => new
                    {
                        ZangerId = c.Int(nullable: false, identity: true),
                        VolledigeNaam = c.String(),
                    })
                .PrimaryKey(t => t.ZangerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lieds", "ZangerId", "dbo.Zangers");
            DropForeignKey("dbo.Lieds", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.BeluisterdLieds", "LiedId", "dbo.Lieds");
            DropForeignKey("dbo.BeluisterdLieds", "GebruikerId", "dbo.Gebruikers");
            DropIndex("dbo.Lieds", new[] { "ZangerId" });
            DropIndex("dbo.Lieds", new[] { "GenreId" });
            DropIndex("dbo.BeluisterdLieds", new[] { "LiedId" });
            DropIndex("dbo.BeluisterdLieds", new[] { "GebruikerId" });
            DropTable("dbo.Zangers");
            DropTable("dbo.Genres");
            DropTable("dbo.Lieds");
            DropTable("dbo.Gebruikers");
            DropTable("dbo.BeluisterdLieds");
        }
    }
}
