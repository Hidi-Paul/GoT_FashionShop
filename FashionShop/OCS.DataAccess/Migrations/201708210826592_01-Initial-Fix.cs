namespace OCS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _01InitialFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "ColorID", "dbo.Color");
            DropForeignKey("dbo.Product", "GenderID", "dbo.Gender");
            DropIndex("dbo.Product", new[] { "GenderID" });
            DropIndex("dbo.Product", new[] { "ColorID" });
            AddColumn("dbo.Product", "Gender", c => c.Int(nullable: false));
            DropColumn("dbo.Product", "GenderID");
            DropColumn("dbo.Product", "ColorID");
            DropTable("dbo.Color");
            DropTable("dbo.Gender");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Gender",
                c => new
                    {
                        GenderID = c.Guid(nullable: false),
                        GenderName = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.GenderID);
            
            CreateTable(
                "dbo.Color",
                c => new
                    {
                        ColorID = c.Guid(nullable: false),
                        ColorName = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.ColorID);
            
            AddColumn("dbo.Product", "ColorID", c => c.Guid());
            AddColumn("dbo.Product", "GenderID", c => c.Guid());
            DropColumn("dbo.Product", "Gender");
            CreateIndex("dbo.Product", "ColorID");
            CreateIndex("dbo.Product", "GenderID");
            AddForeignKey("dbo.Product", "GenderID", "dbo.Gender", "GenderID");
            AddForeignKey("dbo.Product", "ColorID", "dbo.Color", "ColorID");
        }
    }
}
