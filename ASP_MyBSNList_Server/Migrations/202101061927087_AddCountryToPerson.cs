namespace ASP_MyBSNList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCountryToPerson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "CountryId", c => c.Byte());
            CreateIndex("dbo.People", "CountryId");
            AddForeignKey("dbo.People", "CountryId", "dbo.Countries", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "CountryId", "dbo.Countries");
            DropIndex("dbo.People", new[] { "CountryId" });
            DropColumn("dbo.People", "CountryId");
        }
    }
}
