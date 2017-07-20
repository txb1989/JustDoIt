namespace Jurisdiction.Entityframework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2017062801 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Roles", new[] { "ParentRoleId" });
            AlterColumn("dbo.Roles", "ParentRoleId", c => c.Long());
            CreateIndex("dbo.Roles", "ParentRoleId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Roles", new[] { "ParentRoleId" });
            AlterColumn("dbo.Roles", "ParentRoleId", c => c.Long(nullable: false));
            CreateIndex("dbo.Roles", "ParentRoleId");
        }
    }
}
