namespace OCS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _01Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brand",
                c => new
                    {
                        BrandID = c.Guid(nullable: false),
                        BrandName = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.BrandID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductID = c.Guid(nullable: false),
                        ProductName = c.String(maxLength: 50, unicode: false),
                        ProductPrice = c.Double(),
                        GenderID = c.Guid(),
                        ColorID = c.Guid(),
                        BrandID = c.Guid(),
                        CategoryID = c.Guid(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Brand", t => t.BrandID)
                .ForeignKey("dbo.Category", t => t.CategoryID)
                .ForeignKey("dbo.Color", t => t.ColorID)
                .ForeignKey("dbo.Gender", t => t.GenderID)
                .Index(t => t.GenderID)
                .Index(t => t.ColorID)
                .Index(t => t.BrandID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Guid(nullable: false),
                        CategoryName = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Color",
                c => new
                    {
                        ColorID = c.Guid(nullable: false),
                        ColorName = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.ColorID);
            
            CreateTable(
                "dbo.Gender",
                c => new
                    {
                        GenderID = c.Guid(nullable: false),
                        GenderName = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.GenderID);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "GenderID", "dbo.Gender");
            DropForeignKey("dbo.Product", "ColorID", "dbo.Color");
            DropForeignKey("dbo.Product", "CategoryID", "dbo.Category");
            DropForeignKey("dbo.Product", "BrandID", "dbo.Brand");
            DropIndex("dbo.Product", new[] { "CategoryID" });
            DropIndex("dbo.Product", new[] { "BrandID" });
            DropIndex("dbo.Product", new[] { "ColorID" });
            DropIndex("dbo.Product", new[] { "GenderID" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.Gender");
            DropTable("dbo.Color");
            DropTable("dbo.Category");
            DropTable("dbo.Product");
            DropTable("dbo.Brand");
        }
    }
}
