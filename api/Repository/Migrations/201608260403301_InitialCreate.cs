namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        cpf = c.String(nullable: false, maxLength: 128),
                        name = c.String(),
                        email = c.String(),
                        maritalStatus = c.String(),
                        address = c.String(),
                    })
                .PrimaryKey(t => t.cpf);
            
            CreateTable(
                "dbo.Phone",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        number = c.Long(nullable: false),
                        cpfCustomer = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customer", t => t.cpfCustomer)
                .Index(t => t.cpfCustomer);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phone", "cpfCustomer", "dbo.Customer");
            DropIndex("dbo.Phone", new[] { "cpfCustomer" });
            DropTable("dbo.Phone");
            DropTable("dbo.Customer");
        }
    }
}
