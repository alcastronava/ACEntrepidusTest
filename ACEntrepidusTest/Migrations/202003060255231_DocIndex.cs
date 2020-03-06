namespace ACEntrepidusTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocIndex : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Employees", "DocumentId", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Employees", new[] { "DocumentId" });
        }
    }
}
