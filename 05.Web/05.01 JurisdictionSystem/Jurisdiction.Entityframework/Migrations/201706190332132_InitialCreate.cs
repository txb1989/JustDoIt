namespace Jurisdiction.Entityframework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RoleName = c.String(),
                        ParentRoleId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                //.ForeignKey("dbo.Roles", t => t.ParentRoleId)
                .Index(t => t.ParentRoleId);
            
            CreateTable(
                "dbo.AdminUser",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 40),
                        Password = c.String(),
                        PhoneNo = c.String(),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Roles", "ParentRoleId", "dbo.Roles");
            DropIndex("dbo.Roles", new[] { "ParentRoleId" });
            DropTable("dbo.AdminUser");
            DropTable("dbo.Roles");
        }
    }
}
