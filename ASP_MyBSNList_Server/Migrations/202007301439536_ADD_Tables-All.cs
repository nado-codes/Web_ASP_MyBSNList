namespace ASP_MyBSNList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADD_TablesAll : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgeGroups",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Cities",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.CommunicationTypes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Countries",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Industries",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.MartialStatus",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Occupations",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.People",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    infoId = c.Int(nullable: false),
                    Name = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

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

            CreateTable(
                "dbo.Reasons",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Status",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);


            AddColumn("dbo.PeopleInfo", "AgeGroup_Id", c => c.Int());
            AddColumn("dbo.PeopleInfo", "City_Id", c => c.Int());
            AddColumn("dbo.PeopleInfo", "Industry_Id", c => c.Int());
            AddColumn("dbo.PeopleInfo", "MartialStatus_Id", c => c.Int());
            AddColumn("dbo.PeopleInfo", "Nationality_Id", c => c.Int());
            AddColumn("dbo.PeopleInfo", "Occupation_Id", c => c.Int());
            AddColumn("dbo.PeopleInfo", "PrimaryCommunication_Id", c => c.Int());
            AddColumn("dbo.PeopleInfo", "SecondaryCommunication_Id", c => c.Int());
            CreateIndex("dbo.PeopleInfo", "AgeGroup_Id");
            CreateIndex("dbo.PeopleInfo", "City_Id");
            CreateIndex("dbo.PeopleInfo", "Industry_Id");
            CreateIndex("dbo.PeopleInfo", "MartialStatus_Id");
            CreateIndex("dbo.PeopleInfo", "Nationality_Id");
            CreateIndex("dbo.PeopleInfo", "Occupation_Id");
            CreateIndex("dbo.PeopleInfo", "PrimaryCommunication_Id");
            CreateIndex("dbo.PeopleInfo", "SecondaryCommunication_Id");
            AddForeignKey("dbo.PeopleInfo", "AgeGroup_Id", "dbo.AgeGroups", "Id");
            AddForeignKey("dbo.PeopleInfo", "City_Id", "dbo.Cities", "Id");
            AddForeignKey("dbo.PeopleInfo", "Industry_Id", "dbo.Industries", "Id");
            AddForeignKey("dbo.PeopleInfo", "MartialStatus_Id", "dbo.MartialStatus", "Id");
            AddForeignKey("dbo.PeopleInfo", "Nationality_Id", "dbo.Countries", "Id");
            AddForeignKey("dbo.PeopleInfo", "Occupation_Id", "dbo.Occupations", "Id");
            AddForeignKey("dbo.PeopleInfo", "PrimaryCommunication_Id", "dbo.CommunicationTypes", "Id");
            AddForeignKey("dbo.PeopleInfo", "SecondaryCommunication_Id", "dbo.CommunicationTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PeopleInfo", "SecondaryCommunication_Id", "dbo.CommunicationTypes");
            DropForeignKey("dbo.PeopleInfo", "PrimaryCommunication_Id", "dbo.CommunicationTypes");
            DropForeignKey("dbo.PeopleInfo", "Occupation_Id", "dbo.Occupations");
            DropForeignKey("dbo.PeopleInfo", "Nationality_Id", "dbo.Countries");
            DropForeignKey("dbo.PeopleInfo", "MartialStatus_Id", "dbo.MartialStatus");
            DropForeignKey("dbo.PeopleInfo", "Industry_Id", "dbo.Industries");
            DropForeignKey("dbo.PeopleInfo", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.PeopleInfo", "AgeGroup_Id", "dbo.AgeGroups");
            DropIndex("dbo.PeopleInfo", new[] { "SecondaryCommunication_Id" });
            DropIndex("dbo.PeopleInfo", new[] { "PrimaryCommunication_Id" });
            DropIndex("dbo.PeopleInfo", new[] { "Occupation_Id" });
            DropIndex("dbo.PeopleInfo", new[] { "Nationality_Id" });
            DropIndex("dbo.PeopleInfo", new[] { "MartialStatus_Id" });
            DropIndex("dbo.PeopleInfo", new[] { "Industry_Id" });
            DropIndex("dbo.PeopleInfo", new[] { "City_Id" });
            DropIndex("dbo.PeopleInfo", new[] { "AgeGroup_Id" });
            DropColumn("dbo.PeopleInfo", "SecondaryCommunication_Id");
            DropColumn("dbo.PeopleInfo", "PrimaryCommunication_Id");
            DropColumn("dbo.PeopleInfo", "Occupation_Id");
            DropColumn("dbo.PeopleInfo", "Nationality_Id");
            DropColumn("dbo.PeopleInfo", "MartialStatus_Id");
            DropColumn("dbo.PeopleInfo", "Industry_Id");
            DropColumn("dbo.PeopleInfo", "City_Id");
            DropColumn("dbo.PeopleInfo", "AgeGroup_Id");

            DropTable("dbo.Status");
            DropTable("dbo.Reasons");
            DropTable("dbo.PeopleInfo");
            DropTable("dbo.People");
            DropTable("dbo.Occupations");
            DropTable("dbo.MartialStatus");
            DropTable("dbo.Industries");
            DropTable("dbo.Countries");
            DropTable("dbo.CommunicationTypes");
            DropTable("dbo.Cities");
            DropTable("dbo.AgeGroups");
        }
    }
}
