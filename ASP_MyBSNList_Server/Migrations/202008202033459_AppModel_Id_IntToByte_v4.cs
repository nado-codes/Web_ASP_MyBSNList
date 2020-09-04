namespace ASP_MyBSNList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppModel_Id_IntToByte_v4 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.PeopleInfo", new[] { "SecondaryCommunication_Id" });
            DropColumn("dbo.PeopleInfo", "SecondaryCommunicationId");
            RenameColumn(table: "dbo.PeopleInfo", name: "SecondaryCommunication_Id", newName: "SecondaryCommunicationId");
            AlterColumn("dbo.PeopleInfo", "SecondaryCommunicationId", c => c.Byte(nullable: true));
            AlterColumn("dbo.PeopleInfo", "PrimaryCommunicationId", c => c.Byte(nullable: true));
            CreateIndex("dbo.PeopleInfo", "SecondaryCommunicationId");
            //AddForeignKey("dbo.PeopleInfo", "SecondaryCommunicationId", "dbo.CommunicationTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.PeopleInfo", new[] { "SecondaryCommunicationId" });
            AlterColumn("dbo.PeopleInfo", "SecondaryCommunicationId", c => c.Int());
            RenameColumn(table: "dbo.PeopleInfo", name: "SecondaryCommunicationId", newName: "SecondaryCommunication_Id");
            AddColumn("dbo.PeopleInfo", "SecondaryCommunicationId", c => c.Byte(nullable: true));
            AlterColumn("dbo.PeopleInfo", "PrimaryCommunicationId", c => c.Byte(nullable: true));
            CreateIndex("dbo.PeopleInfo", "SecondaryCommunication_Id");
            //AddForeignKey("dbo.PeopleInfo", "SecondaryCommunication_Id", "dbo.CommunicationTypes", "Id");
        }
    }
}
