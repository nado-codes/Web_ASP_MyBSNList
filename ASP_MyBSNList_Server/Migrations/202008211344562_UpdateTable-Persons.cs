namespace ASP_MyBSNList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTablePersons : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PeopleInfo", "AgeGroupId", "dbo.AgeGroups");
            DropForeignKey("dbo.PeopleInfo", "CityId", "dbo.Cities");
            DropForeignKey("dbo.PeopleInfo", "IndustryId", "dbo.Industries");
            DropForeignKey("dbo.PeopleInfo", "MartialStatusId", "dbo.MartialStatus");
            DropForeignKey("dbo.PeopleInfo", "NationalityId", "dbo.Countries");
            DropForeignKey("dbo.PeopleInfo", "OccupationId", "dbo.Occupations");
            DropForeignKey("dbo.PeopleInfo", "PrimaryCommunicationId", "dbo.CommunicationTypes");
            DropForeignKey("dbo.PeopleInfo", "SecondaryCommunicationId", "dbo.CommunicationTypes");
            DropIndex("dbo.PeopleInfo", new[] { "PrimaryCommunicationId" });
            DropIndex("dbo.PeopleInfo", new[] { "SecondaryCommunicationId" });
            DropIndex("dbo.PeopleInfo", new[] { "NationalityId" });
            DropIndex("dbo.PeopleInfo", new[] { "CityId" });
            DropIndex("dbo.PeopleInfo", new[] { "OccupationId" });
            DropIndex("dbo.PeopleInfo", new[] { "IndustryId" });
            DropIndex("dbo.PeopleInfo", new[] { "MartialStatusId" });
            DropIndex("dbo.PeopleInfo", new[] { "AgeGroupId" });
            DropPrimaryKey("dbo.People");
            AddColumn("dbo.People", "PrimaryCommunicationId", c => c.Byte(nullable: false));
            AddColumn("dbo.People", "SecondaryCommunicationId", c => c.Byte(nullable: false));
            AddColumn("dbo.People", "NationalityId", c => c.Byte(nullable: false));
            AddColumn("dbo.People", "CityId", c => c.Byte(nullable: false));
            AddColumn("dbo.People", "OccupationId", c => c.Byte(nullable: false));
            AddColumn("dbo.People", "IndustryId", c => c.Byte(nullable: false));
            AddColumn("dbo.People", "MartialStatusId", c => c.Byte(nullable: false));
            AddColumn("dbo.People", "AgeGroupId", c => c.Byte(nullable: false));
            AddColumn("dbo.People", "HasKids", c => c.Boolean(nullable: false));
            AddColumn("dbo.People", "Remarks", c => c.String(nullable: false));
            AddColumn("dbo.People", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.People", "LastContact", c => c.DateTime(nullable: false));
            AlterColumn("dbo.People", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.People", "Id");
            CreateIndex("dbo.People", "PrimaryCommunicationId");
            CreateIndex("dbo.People", "SecondaryCommunicationId");
            CreateIndex("dbo.People", "NationalityId");
            CreateIndex("dbo.People", "CityId");
            CreateIndex("dbo.People", "OccupationId");
            CreateIndex("dbo.People", "IndustryId");
            CreateIndex("dbo.People", "MartialStatusId");
            CreateIndex("dbo.People", "AgeGroupId");
            AddForeignKey("dbo.People", "AgeGroupId", "dbo.AgeGroups", "Id");
            AddForeignKey("dbo.People", "CityId", "dbo.Cities", "Id");
            AddForeignKey("dbo.People", "IndustryId", "dbo.Industries", "Id");
            AddForeignKey("dbo.People", "MartialStatusId", "dbo.MartialStatus", "Id");
            AddForeignKey("dbo.People", "NationalityId", "dbo.Countries", "Id");
            AddForeignKey("dbo.People", "OccupationId", "dbo.Occupations", "Id");
            AddForeignKey("dbo.People", "PrimaryCommunicationId", "dbo.CommunicationTypes", "Id");
            AddForeignKey("dbo.People", "SecondaryCommunicationId", "dbo.CommunicationTypes", "Id");
            DropColumn("dbo.People", "infoId");
            DropTable("dbo.PeopleInfo");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PeopleInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        PrimaryCommunicationId = c.Byte(nullable: false),
                        SecondaryCommunicationId = c.Byte(nullable: false),
                        NationalityId = c.Byte(nullable: false),
                        CityId = c.Byte(nullable: false),
                        OccupationId = c.Byte(nullable: false),
                        IndustryId = c.Byte(nullable: false),
                        MartialStatusId = c.Byte(nullable: false),
                        AgeGroupId = c.Byte(nullable: false),
                        HasKids = c.Boolean(nullable: false),
                        Remarks = c.String(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        LastContact = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.People", "infoId", c => c.Int(nullable: false));
            DropForeignKey("dbo.People", "SecondaryCommunicationId", "dbo.CommunicationTypes");
            DropForeignKey("dbo.People", "PrimaryCommunicationId", "dbo.CommunicationTypes");
            DropForeignKey("dbo.People", "OccupationId", "dbo.Occupations");
            DropForeignKey("dbo.People", "NationalityId", "dbo.Countries");
            DropForeignKey("dbo.People", "MartialStatusId", "dbo.MartialStatus");
            DropForeignKey("dbo.People", "IndustryId", "dbo.Industries");
            DropForeignKey("dbo.People", "CityId", "dbo.Cities");
            DropForeignKey("dbo.People", "AgeGroupId", "dbo.AgeGroups");
            DropIndex("dbo.People", new[] { "AgeGroupId" });
            DropIndex("dbo.People", new[] { "MartialStatusId" });
            DropIndex("dbo.People", new[] { "IndustryId" });
            DropIndex("dbo.People", new[] { "OccupationId" });
            DropIndex("dbo.People", new[] { "CityId" });
            DropIndex("dbo.People", new[] { "NationalityId" });
            DropIndex("dbo.People", new[] { "SecondaryCommunicationId" });
            DropIndex("dbo.People", new[] { "PrimaryCommunicationId" });
            DropPrimaryKey("dbo.People");
            AlterColumn("dbo.People", "Id", c => c.Byte(nullable: false));
            DropColumn("dbo.People", "LastContact");
            DropColumn("dbo.People", "DateAdded");
            DropColumn("dbo.People", "Remarks");
            DropColumn("dbo.People", "HasKids");
            DropColumn("dbo.People", "AgeGroupId");
            DropColumn("dbo.People", "MartialStatusId");
            DropColumn("dbo.People", "IndustryId");
            DropColumn("dbo.People", "OccupationId");
            DropColumn("dbo.People", "CityId");
            DropColumn("dbo.People", "NationalityId");
            DropColumn("dbo.People", "SecondaryCommunicationId");
            DropColumn("dbo.People", "PrimaryCommunicationId");
            AddPrimaryKey("dbo.People", "Id");
            CreateIndex("dbo.PeopleInfo", "AgeGroupId");
            CreateIndex("dbo.PeopleInfo", "MartialStatusId");
            CreateIndex("dbo.PeopleInfo", "IndustryId");
            CreateIndex("dbo.PeopleInfo", "OccupationId");
            CreateIndex("dbo.PeopleInfo", "CityId");
            CreateIndex("dbo.PeopleInfo", "NationalityId");
            CreateIndex("dbo.PeopleInfo", "SecondaryCommunicationId");
            CreateIndex("dbo.PeopleInfo", "PrimaryCommunicationId");
            AddForeignKey("dbo.PeopleInfo", "SecondaryCommunicationId", "dbo.CommunicationTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PeopleInfo", "PrimaryCommunicationId", "dbo.CommunicationTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PeopleInfo", "OccupationId", "dbo.Occupations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PeopleInfo", "NationalityId", "dbo.Countries", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PeopleInfo", "MartialStatusId", "dbo.MartialStatus", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PeopleInfo", "IndustryId", "dbo.Industries", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PeopleInfo", "CityId", "dbo.Cities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PeopleInfo", "AgeGroupId", "dbo.AgeGroups", "Id", cascadeDelete: true);
        }
    }
}
