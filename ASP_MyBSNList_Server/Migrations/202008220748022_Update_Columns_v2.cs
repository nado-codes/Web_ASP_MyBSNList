namespace ASP_MyBSNList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Columns_v2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AgeGroups", new[] { "Name" });
            DropIndex("dbo.Cities", new[] { "Name" });
            DropIndex("dbo.CommunicationTypes", new[] { "Name" });
            DropIndex("dbo.Countries", new[] { "Name" });
            DropIndex("dbo.Industries", new[] { "Name" });
            DropIndex("dbo.MartialStatus", new[] { "Name" });
            DropIndex("dbo.Occupations", new[] { "Name" });
            DropIndex("dbo.People", new[] { "Name" });
            DropIndex("dbo.Reasons", new[] { "Name" });
            DropIndex("dbo.Status", new[] { "Name" });
            AlterColumn("dbo.AgeGroups", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Cities", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.CommunicationTypes", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Countries", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Industries", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.MartialStatus", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Occupations", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.People", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Reasons", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Status", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.AgeGroups", "Name", unique: true, name: "Name_Index");
            CreateIndex("dbo.Cities", "Name", unique: true, name: "Name_Index");
            CreateIndex("dbo.CommunicationTypes", "Name", unique: true, name: "Name_Index");
            CreateIndex("dbo.Countries", "Name", unique: true, name: "Name_Index");
            CreateIndex("dbo.Industries", "Name", unique: true, name: "Name_Index");
            CreateIndex("dbo.MartialStatus", "Name", unique: true, name: "Name_Index");
            CreateIndex("dbo.Occupations", "Name", unique: true, name: "Name_Index");
            CreateIndex("dbo.People", "Name", unique: true, name: "Name_Index");
            CreateIndex("dbo.Reasons", "Name", unique: true, name: "Name_Index");
            CreateIndex("dbo.Status", "Name", unique: true, name: "Name_Index");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Status", "Name_Index");
            DropIndex("dbo.Reasons", "Name_Index");
            DropIndex("dbo.People", "Name_Index");
            DropIndex("dbo.Occupations", "Name_Index");
            DropIndex("dbo.MartialStatus", "Name_Index");
            DropIndex("dbo.Industries", "Name_Index");
            DropIndex("dbo.Countries", "Name_Index");
            DropIndex("dbo.CommunicationTypes", "Name_Index");
            DropIndex("dbo.Cities", "Name_Index");
            DropIndex("dbo.AgeGroups", "Name_Index");
            AlterColumn("dbo.Status", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Reasons", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.People", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Occupations", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.MartialStatus", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Industries", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Countries", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.CommunicationTypes", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Cities", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.AgeGroups", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Status", "Name", unique: true);
            CreateIndex("dbo.Reasons", "Name", unique: true);
            CreateIndex("dbo.People", "Name", unique: true);
            CreateIndex("dbo.Occupations", "Name", unique: true);
            CreateIndex("dbo.MartialStatus", "Name", unique: true);
            CreateIndex("dbo.Industries", "Name", unique: true);
            CreateIndex("dbo.Countries", "Name", unique: true);
            CreateIndex("dbo.CommunicationTypes", "Name", unique: true);
            CreateIndex("dbo.Cities", "Name", unique: true);
            CreateIndex("dbo.AgeGroups", "Name", unique: true);
        }
    }
}
