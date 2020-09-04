namespace ASP_MyBSNList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonSetupNullables : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.People");
            AddColumn("dbo.People", "List", c => c.String(nullable: false));
            AlterColumn("dbo.People", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.People", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.People");
            AlterColumn("dbo.People", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.People", "List");
            AddPrimaryKey("dbo.People", "Id");
        }
    }
}
