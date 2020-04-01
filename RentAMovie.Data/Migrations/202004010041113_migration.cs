namespace RentAMovie.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rating", "Customer_CustomerId", "dbo.Customer");
            DropIndex("dbo.Rating", new[] { "MovieId" });
            DropIndex("dbo.Rating", new[] { "Customer_CustomerId" });
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Type = c.String(nullable: false),
                        Player = c.Int(nullable: false),
                        Online = c.Boolean(nullable: false),
                        Description = c.String(nullable: false),
                        Year = c.DateTime(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.GameId);
            
            AddColumn("dbo.Movie", "Year", c => c.DateTime(nullable: false));
            AddColumn("dbo.Rental", "GameId", c => c.Int(nullable: false));
            AddColumn("dbo.Rating", "Description", c => c.String(nullable: false));
            AddColumn("dbo.Rating", "GameId", c => c.Int());
            AddColumn("dbo.Rating", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Rating", "MovieId", c => c.Int());
            CreateIndex("dbo.Rental", "GameId");
            CreateIndex("dbo.Rating", "GameId");
            CreateIndex("dbo.Rating", "MovieId");
            AddForeignKey("dbo.Rating", "GameId", "dbo.Game", "GameId", cascadeDelete: true);
            AddForeignKey("dbo.Rental", "GameId", "dbo.Game", "GameId", cascadeDelete: true);
            DropColumn("dbo.Rating", "Customer_CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rating", "Customer_CustomerId", c => c.Int());
            DropForeignKey("dbo.Rental", "GameId", "dbo.Game");
            DropForeignKey("dbo.Rating", "GameId", "dbo.Game");
            DropIndex("dbo.Rating", new[] { "MovieId" });
            DropIndex("dbo.Rating", new[] { "GameId" });
            DropIndex("dbo.Rental", new[] { "GameId" });
            AlterColumn("dbo.Rating", "MovieId", c => c.Int(nullable: false));
            DropColumn("dbo.Rating", "Discriminator");
            DropColumn("dbo.Rating", "GameId");
            DropColumn("dbo.Rating", "Description");
            DropColumn("dbo.Rental", "GameId");
            DropColumn("dbo.Movie", "Year");
            DropTable("dbo.Game");
            CreateIndex("dbo.Rating", "Customer_CustomerId");
            CreateIndex("dbo.Rating", "MovieId");
            AddForeignKey("dbo.Rating", "Customer_CustomerId", "dbo.Customer", "CustomerId");
        }
    }
}
