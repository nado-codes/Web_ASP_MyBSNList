namespace ASP_MyBSNList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonSetupNullablesv2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "PrimaryCommunicationId", c => c.Byte(nullable: true));
            AlterColumn("dbo.People", "SecondaryCommunicationId", c => c.Byte(nullable: true));
            AlterColumn("dbo.People", "NationalityId", c => c.Byte(nullable: true));
            AlterColumn("dbo.People", "CityId", c => c.Byte(nullable: true));
            AlterColumn("dbo.People", "OccupationId", c => c.Byte(nullable: true));
            AlterColumn("dbo.People", "IndustryId", c => c.Byte(nullable: true));
            AlterColumn("dbo.People", "MartialStatusId", c => c.Byte(nullable: true));
            AlterColumn("dbo.People", "AgeGroupId", c => c.Byte(nullable: true));
            AlterColumn("dbo.People", "HasKids", c => c.Boolean(nullable: true));
            AlterColumn("dbo.People", "Remarks", c => c.String(nullable: true));
            AlterColumn("dbo.People", "DateAdded", c => c.DateTime(nullable: true));
            AlterColumn("dbo.People", "LastContact", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
        }
    }
}
