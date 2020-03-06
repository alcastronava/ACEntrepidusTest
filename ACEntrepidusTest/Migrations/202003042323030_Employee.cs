namespace ACEntrepidusTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocumentId = c.String(nullable: false, maxLength: 256),
                        FullName = c.String(nullable: false, maxLength: 256),
                        Address = c.String(nullable: false, maxLength: 1024),
                        EMail = c.String(),
                        PhoneNumber = c.String(),
                        ContractDate = c.DateTime(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        IsFreelance = c.Boolean(nullable: false),
                        PayRate = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String(nullable: false, maxLength: 256));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "FullName");
            DropTable("dbo.Employees");
        }
    }
}
