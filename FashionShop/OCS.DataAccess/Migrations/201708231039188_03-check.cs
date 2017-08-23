namespace OCS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _03check : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "ProductPrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "ProductPrice", c => c.Double());
        }
    }
}
