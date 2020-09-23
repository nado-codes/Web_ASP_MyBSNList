namespace ASP_MyBSNList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB_1309 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Gender", c => c.Byte());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Gender");
        }
    }
}
