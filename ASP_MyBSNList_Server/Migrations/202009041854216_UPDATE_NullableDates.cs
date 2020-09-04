namespace ASP_MyBSNList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPDATE_NullableDates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "DateAdded", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "DateAdded", c => c.DateTime(nullable: false));
        }
    }
}
