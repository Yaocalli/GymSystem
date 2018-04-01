namespace Maintenance.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Maintenance.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Maintenance.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ProfilePicture = c.Binary(),
                        Active = c.Boolean(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Maintenance.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Street = c.String(),
                        City = c.String(),
                        StateProvince = c.String(),
                        PostalCode = c.String(),
                        MemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Maintenance.Members", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "Maintenance.ContactDetails",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Email = c.String(),
                        HomePhone = c.String(),
                        OfficePhone = c.String(),
                        Cellphone = c.String(),
                        EmergencyContact = c.String(),
                        EmergencyPhone = c.String(),
                        MemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Maintenance.Members", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "Maintenance.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Image = c.Binary(),
                        IsAvailable = c.Boolean(nullable: false),
                        AvailableQuantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Maintenance.ContactDetails", "Id", "Maintenance.Members");
            DropForeignKey("Maintenance.Addresses", "Id", "Maintenance.Members");
            DropIndex("Maintenance.ContactDetails", new[] { "Id" });
            DropIndex("Maintenance.Addresses", new[] { "Id" });
            DropTable("Maintenance.Products");
            DropTable("Maintenance.ContactDetails");
            DropTable("Maintenance.Addresses");
            DropTable("Maintenance.Members");
            DropTable("Maintenance.Accounts");
        }
    }
}
