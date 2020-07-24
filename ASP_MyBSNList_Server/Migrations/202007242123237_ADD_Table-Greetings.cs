namespace ASP_MyBSNList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADD_TableGreetings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HelloModels",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HelloModels");
        }
    }
}
