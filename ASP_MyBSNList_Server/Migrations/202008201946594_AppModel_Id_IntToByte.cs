namespace ASP_MyBSNList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppModel_Id_IntToByte : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PeopleInfo", "AgeGroup_Id", "dbo.AgeGroups");
            DropForeignKey("dbo.PeopleInfo", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.PeopleInfo", "Industry_Id", "dbo.Industries");
            DropForeignKey("dbo.PeopleInfo", "MartialStatus_Id", "dbo.MartialStatus");
            DropForeignKey("dbo.PeopleInfo", "Nationality_Id", "dbo.Countries");
            DropForeignKey("dbo.PeopleInfo", "Occupation_Id", "dbo.Occupations");
            DropForeignKey("dbo.PeopleInfo", "PrimaryCommunication_Id", "dbo.CommunicationTypes");
            DropForeignKey("dbo.PeopleInfo", "SecondaryCommunication_Id", "dbo.CommunicationTypes");
            //====DropIndex("dbo.PeopleInfo", new[] { "AgeGroup_Id" });
            //====DropIndex("dbo.PeopleInfo", new[] { "City_Id" });
            //====DropIndex("dbo.PeopleInfo", new[] { "Industry_Id" });
            //====DropIndex("dbo.PeopleInfo", new[] { "MartialStatus_Id" });
            //====DropIndex("dbo.PeopleInfo", new[] { "Nationality_Id" });
            //====DropIndex("dbo.PeopleInfo", new[] { "Occupation_Id" });
            //====DropIndex("dbo.PeopleInfo", new[] { "PrimaryCommunication_Id" });
            //DropIndex("dbo.PeopleInfo", new[] { "SecondaryCommunication_Id" });
            //====DropColumn("dbo.PeopleInfo", "AgeGroupId");
            //====DropColumn("dbo.PeopleInfo", "CityId");
            //====DropColumn("dbo.PeopleInfo", "IndustryId");
            //====DropColumn("dbo.PeopleInfo", "MartialStatusId");
            //====DropColumn("dbo.PeopleInfo", "NationalityId");
            //====DropColumn("dbo.PeopleInfo", "OccupationId");
            //====DropColumn("dbo.PeopleInfo", "PrimaryCommunicationId");
            //DropColumn("dbo.PeopleInfo", "SecondaryCommunicationId");
            //====RenameColumn(table: "dbo.PeopleInfo", name: "AgeGroup_Id", newName: "AgeGroupId");
            //====RenameColumn(table: "dbo.PeopleInfo", name: "City_Id", newName: "CityId");
            //====RenameColumn(table: "dbo.PeopleInfo", name: "Industry_Id", newName: "IndustryId");
            //====RenameColumn(table: "dbo.PeopleInfo", name: "MartialStatus_Id", newName: "MartialStatusId");
            //====RenameColumn(table: "dbo.PeopleInfo", name: "Nationality_Id", newName: "NationalityId");
            //====RenameColumn(table: "dbo.PeopleInfo", name: "Occupation_Id", newName: "OccupationId");
            //====RenameColumn(table: "dbo.PeopleInfo", name: "PrimaryCommunication_Id", newName: "PrimaryCommunicationId");
            //RenameColumn(table: "dbo.PeopleInfo", name: "SecondaryCommunication_Id", newName: "SecondaryCommunicationId");
            //DropPrimaryKey("dbo.AgeGroups");
            //DropPrimaryKey("dbo.Cities");
            //DropPrimaryKey("dbo.CommunicationTypes");
            //DropPrimaryKey("dbo.Countries");
            //DropPrimaryKey("dbo.Industries");
            //DropPrimaryKey("dbo.MartialStatus");
            //DropPrimaryKey("dbo.Occupations");
            //DropPrimaryKey("dbo.People");
            //DropPrimaryKey("dbo.Reasons");
            //DropPrimaryKey("dbo.Status");
            //AlterColumn("dbo.AgeGroups", "Id", c => c.Byte(nullable: false));
            //AlterColumn("dbo.Cities", "Id", c => c.Byte(nullable: false));
            //AlterColumn("dbo.CommunicationTypes", "Id", c => c.Byte(nullable: false));
            //AlterColumn("dbo.Countries", "Id", c => c.Byte(nullable: false));
            //AlterColumn("dbo.Industries", "Id", c => c.Byte(nullable: false));
            //AlterColumn("dbo.MartialStatus", "Id", c => c.Byte(nullable: false));
            //AlterColumn("dbo.Occupations", "Id", c => c.Byte(nullable: false));
            //AlterColumn("dbo.People", "Id", c => c.Byte(nullable: false));

            //====AlterColumn("dbo.PeopleInfo", "AgeGroupId", c => c.Byte(nullable: false));
            //====AlterColumn("dbo.PeopleInfo", "CityId", c => c.Byte(nullable: false));
            //====AlterColumn("dbo.PeopleInfo", "IndustryId", c => c.Byte(nullable: false));
            //====AlterColumn("dbo.PeopleInfo", "MartialStatusId", c => c.Byte(nullable: false));
            //====AlterColumn("dbo.PeopleInfo", "NationalityId", c => c.Byte(nullable: false));
            //====AlterColumn("dbo.PeopleInfo", "OccupationId", c => c.Byte(nullable: false));
            //====AlterColumn("dbo.PeopleInfo", "PrimaryCommunicationId", c => c.Byte(nullable: false));

            //AlterColumn("dbo.PeopleInfo", "SecondaryCommunicationId", c => c.Byte(nullable: false));
            //AlterColumn("dbo.Reasons", "Id", c => c.Byte(nullable: false));
            //AlterColumn("dbo.Status", "Id", c => c.Byte(nullable: false));
            //AddPrimaryKey("dbo.AgeGroups", "Id");
            //AddPrimaryKey("dbo.Cities", "Id");
            //AddPrimaryKey("dbo.CommunicationTypes", "Id");
            //AddPrimaryKey("dbo.Countries", "Id");
            //AddPrimaryKey("dbo.Industries", "Id");
            //AddPrimaryKey("dbo.MartialStatus", "Id");
            //AddPrimaryKey("dbo.Occupations", "Id");
            //AddPrimaryKey("dbo.People", "Id");
            //AddPrimaryKey("dbo.Reasons", "Id");
            //AddPrimaryKey("dbo.Status", "Id");
            //====CreateIndex("dbo.PeopleInfo", "PrimaryCommunicationId");
            //CreateIndex("dbo.PeopleInfo", "SecondaryCommunicationId");
            //====CreateIndex("dbo.PeopleInfo", "NationalityId");
            //====CreateIndex("dbo.PeopleInfo", "CityId");
            //====CreateIndex("dbo.PeopleInfo", "OccupationId");
            //====CreateIndex("dbo.PeopleInfo", "IndustryId");
            //====CreateIndex("dbo.PeopleInfo", "MartialStatusId");
            //====CreateIndex("dbo.PeopleInfo", "AgeGroupId");
            //====AddForeignKey("dbo.PeopleInfo", "AgeGroupId", "dbo.AgeGroups", "Id", cascadeDelete: true);
            //====AddForeignKey("dbo.PeopleInfo", "CityId", "dbo.Cities", "Id", cascadeDelete: true);
            //====AddForeignKey("dbo.PeopleInfo", "IndustryId", "dbo.Industries", "Id", cascadeDelete: true);
            //====AddForeignKey("dbo.PeopleInfo", "MartialStatusId", "dbo.MartialStatus", "Id", cascadeDelete: true);
            //====AddForeignKey("dbo.PeopleInfo", "NationalityId", "dbo.Countries", "Id", cascadeDelete: true);
            //====AddForeignKey("dbo.PeopleInfo", "OccupationId", "dbo.Occupations", "Id", cascadeDelete: true);
            //====AddForeignKey("dbo.PeopleInfo", "PrimaryCommunicationId", "dbo.CommunicationTypes", "Id", cascadeDelete: true);
            //AddForeignKey("dbo.PeopleInfo", "SecondaryCommunicationId", "dbo.CommunicationTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PeopleInfo", "SecondaryCommunicationId", "dbo.CommunicationTypes");
            DropForeignKey("dbo.PeopleInfo", "PrimaryCommunicationId", "dbo.CommunicationTypes");
            DropForeignKey("dbo.PeopleInfo", "OccupationId", "dbo.Occupations");
            DropForeignKey("dbo.PeopleInfo", "NationalityId", "dbo.Countries");
            DropForeignKey("dbo.PeopleInfo", "MartialStatusId", "dbo.MartialStatus");
            DropForeignKey("dbo.PeopleInfo", "IndustryId", "dbo.Industries");
            DropForeignKey("dbo.PeopleInfo", "CityId", "dbo.Cities");
            DropForeignKey("dbo.PeopleInfo", "AgeGroupId", "dbo.AgeGroups");
            //====DropIndex("dbo.PeopleInfo", new[] { "AgeGroupId" });
            //====DropIndex("dbo.PeopleInfo", new[] { "MartialStatusId" });
            //====DropIndex("dbo.PeopleInfo", new[] { "IndustryId" });
            //====DropIndex("dbo.PeopleInfo", new[] { "OccupationId" });
            //====DropIndex("dbo.PeopleInfo", new[] { "CityId" });
            //====DropIndex("dbo.PeopleInfo", new[] { "NationalityId" });
           // DropIndex("dbo.PeopleInfo", new[] { "SecondaryCommunicationId" });
            //====DropIndex("dbo.PeopleInfo", new[] { "PrimaryCommunicationId" });
            //DropPrimaryKey("dbo.Status");
            //DropPrimaryKey("dbo.Reasons");
            //DropPrimaryKey("dbo.People");
            //DropPrimaryKey("dbo.Occupations");
            //DropPrimaryKey("dbo.MartialStatus");
            //DropPrimaryKey("dbo.Industries");
            //DropPrimaryKey("dbo.Countries");
            //DropPrimaryKey("dbo.CommunicationTypes");
            //DropPrimaryKey("dbo.Cities");
            //DropPrimaryKey("dbo.AgeGroups");
            //AlterColumn("dbo.Status", "Id", c => c.Int(nullable: false, identity: true));
            //AlterColumn("dbo.Reasons", "Id", c => c.Int(nullable: false, identity: true));
            //AlterColumn("dbo.PeopleInfo", "SecondaryCommunicationId", c => c.Int());
            //====AlterColumn("dbo.PeopleInfo", "PrimaryCommunicationId", c => c.Int());
            //====AlterColumn("dbo.PeopleInfo", "OccupationId", c => c.Int());
            //====AlterColumn("dbo.PeopleInfo", "NationalityId", c => c.Int());
            //====AlterColumn("dbo.PeopleInfo", "MartialStatusId", c => c.Int());
            //====AlterColumn("dbo.PeopleInfo", "IndustryId", c => c.Int());
            //====AlterColumn("dbo.PeopleInfo", "CityId", c => c.Int());
            //====AlterColumn("dbo.PeopleInfo", "AgeGroupId", c => c.Int());
            //AlterColumn("dbo.People", "Id", c => c.Int(nullable: false, identity: true));
            //AlterColumn("dbo.Occupations", "Id", c => c.Int(nullable: false, identity: true));
            //AlterColumn("dbo.MartialStatus", "Id", c => c.Int(nullable: false, identity: true));
            //AlterColumn("dbo.Industries", "Id", c => c.Int(nullable: false, identity: true));
            //AlterColumn("dbo.Countries", "Id", c => c.Int(nullable: false, identity: true));
            //AlterColumn("dbo.CommunicationTypes", "Id", c => c.Int(nullable: false, identity: true));
            //AlterColumn("dbo.Cities", "Id", c => c.Int(nullable: false, identity: true));
            //AlterColumn("dbo.AgeGroups", "Id", c => c.Int(nullable: false, identity: true));
            //AddPrimaryKey("dbo.Status", "Id");
            //AddPrimaryKey("dbo.Reasons", "Id");
            //AddPrimaryKey("dbo.People", "Id");
            //AddPrimaryKey("dbo.Occupations", "Id");
            //AddPrimaryKey("dbo.MartialStatus", "Id");
            //AddPrimaryKey("dbo.Industries", "Id");
            //AddPrimaryKey("dbo.Countries", "Id");
            //AddPrimaryKey("dbo.CommunicationTypes", "Id");
            //AddPrimaryKey("dbo.Cities", "Id");
            //AddPrimaryKey("dbo.AgeGroups", "Id");
            //RenameColumn(table: "dbo.PeopleInfo", name: "SecondaryCommunicationId", newName: "SecondaryCommunication_Id");
            //====RenameColumn(table: "dbo.PeopleInfo", name: "PrimaryCommunicationId", newName: "PrimaryCommunication_Id");
            //====RenameColumn(table: "dbo.PeopleInfo", name: "OccupationId", newName: "Occupation_Id");
            //====RenameColumn(table: "dbo.PeopleInfo", name: "NationalityId", newName: "Nationality_Id");
            //====RenameColumn(table: "dbo.PeopleInfo", name: "MartialStatusId", newName: "MartialStatus_Id");
            //====RenameColumn(table: "dbo.PeopleInfo", name: "IndustryId", newName: "Industry_Id");
            //====RenameColumn(table: "dbo.PeopleInfo", name: "CityId", newName: "City_Id");
            //====RenameColumn(table: "dbo.PeopleInfo", name: "AgeGroupId", newName: "AgeGroup_Id");
            //AddColumn("dbo.PeopleInfo", "SecondaryCommunicationId", c => c.Byte(nullable: false));
            //====AddColumn("dbo.PeopleInfo", "PrimaryCommunicationId", c => c.Byte(nullable: false));
            //====AddColumn("dbo.PeopleInfo", "OccupationId", c => c.Byte(nullable: false));
            //====AddColumn("dbo.PeopleInfo", "NationalityId", c => c.Byte(nullable: false));
            //====AddColumn("dbo.PeopleInfo", "MartialStatusId", c => c.Byte(nullable: false));
            //====AddColumn("dbo.PeopleInfo", "IndustryId", c => c.Byte(nullable: false));
            //====AddColumn("dbo.PeopleInfo", "CityId", c => c.Byte(nullable: false));
            //====AddColumn("dbo.PeopleInfo", "AgeGroupId", c => c.Byte(nullable: false));
            //CreateIndex("dbo.PeopleInfo", "SecondaryCommunication_Id");
            //====CreateIndex("dbo.PeopleInfo", "PrimaryCommunication_Id");
            //====CreateIndex("dbo.PeopleInfo", "Occupation_Id");
            //====CreateIndex("dbo.PeopleInfo", "Nationality_Id");
            //====CreateIndex("dbo.PeopleInfo", "MartialStatus_Id");
            //====CreateIndex("dbo.PeopleInfo", "Industry_Id");
            //====CreateIndex("dbo.PeopleInfo", "City_Id");
            //====CreateIndex("dbo.PeopleInfo", "AgeGroup_Id");
            //AddForeignKey("dbo.PeopleInfo", "SecondaryCommunication_Id", "dbo.CommunicationTypes", "Id");
            //====AddForeignKey("dbo.PeopleInfo", "PrimaryCommunication_Id", "dbo.CommunicationTypes", "Id");
            //====AddForeignKey("dbo.PeopleInfo", "Occupation_Id", "dbo.Occupations", "Id");
            //====AddForeignKey("dbo.PeopleInfo", "Nationality_Id", "dbo.Countries", "Id");
            //====AddForeignKey("dbo.PeopleInfo", "MartialStatus_Id", "dbo.MartialStatus", "Id");
            //====AddForeignKey("dbo.PeopleInfo", "Industry_Id", "dbo.Industries", "Id");
            //====AddForeignKey("dbo.PeopleInfo", "City_Id", "dbo.Cities", "Id");
            //====AddForeignKey("dbo.PeopleInfo", "AgeGroup_Id", "dbo.AgeGroups", "Id");
        }
    }
}
