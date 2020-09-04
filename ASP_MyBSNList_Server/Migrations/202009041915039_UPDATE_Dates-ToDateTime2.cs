namespace ASP_MyBSNList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPDATE_DatesToDateTime2 : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE People ALTER column DateAdded datetime2");
            Sql("ALTER TABLE People ALTER column LastContact datetime2");
        }
        
        public override void Down()
        {
        }
    }
}
