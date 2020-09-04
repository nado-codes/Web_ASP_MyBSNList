namespace ASP_MyBSNList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PeopleSetupNonNullables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "DateAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
        }
    }
}
