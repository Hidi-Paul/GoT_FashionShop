namespace OCS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _01Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "ProductName", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Product", "ProductPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.Product", "Image", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Image", c => c.String());
            AlterColumn("dbo.Product", "ProductPrice", c => c.Double());
            AlterColumn("dbo.Product", "ProductName", c => c.String(maxLength: 50, unicode: false));
        }
    }
}
