namespace ASP_MyBSNList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class POP_TablesSelect : DbMigration
    {
        public override void Up()
        {
            string[] cities = new string[8]
            {
                "Sydney","Wollongong","Adelaide","Brisbane","Perth","Darwin","Melbourne","Other"
            };

            Sql("SET IDENTITY_INSERT dbo.Cities ON");
            for (int i = 0; i < cities.Length; i++)
            {
                Sql("INSERT INTO Cities (Id,Name) VALUES ("+ i +",'"+cities[i]+"')");
            }
            Sql("SET IDENTITY_INSERT dbo.Cities OFF");
        }
        
        public override void Down()
        {
        }
    }
}
