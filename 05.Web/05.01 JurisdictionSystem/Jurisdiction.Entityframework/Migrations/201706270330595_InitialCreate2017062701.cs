namespace Jurisdiction.Entityframework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2017062701 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User_Role_Relations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        RoleId = c.Long(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        CreateUserId = c.Long(),
                        User_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                //.ForeignKey("dbo.AdminUser", t => t.User_Id)
                //.ForeignKey("dbo.AdminUser", t => t.CreateUserId)
                //.ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                //.ForeignKey("dbo.AdminUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId)
                .Index(t => t.CreateUserId)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.AdminUser", "Email", c => c.String(maxLength: 200));
            AlterColumn("dbo.AdminUser", "PhoneNo", c => c.String(maxLength: 15));
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.User_Role_Relations", "UserId", "dbo.AdminUser");
            //DropForeignKey("dbo.User_Role_Relations", "RoleId", "dbo.Roles");
            //DropForeignKey("dbo.User_Role_Relations", "CreateUserId", "dbo.AdminUser");
            //DropForeignKey("dbo.User_Role_Relations", "User_Id", "dbo.AdminUser");
            DropIndex("dbo.User_Role_Relations", new[] { "User_Id" });
            DropIndex("dbo.User_Role_Relations", new[] { "CreateUserId" });
            DropIndex("dbo.User_Role_Relations", new[] { "RoleId" });
            DropIndex("dbo.User_Role_Relations", new[] { "UserId" });
            AlterColumn("dbo.AdminUser", "PhoneNo", c => c.String());
            DropColumn("dbo.AdminUser", "Email");
            DropTable("dbo.User_Role_Relations");
        }
    }
}
