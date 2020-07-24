namespace ASP_MyBSNList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class POP_TableGreetings : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO HelloModels (Id, Name) VALUES (1, 'DbHello')");
        }
        
        public override void Down()
        {
        }
    }
}
