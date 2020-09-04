namespace ASP_MyBSNList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationAppModel_Id_IntToByte_v5 : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.PeopleInfo", "SecondaryCommunicationId", "dbo.CommunicationTypes", "Id");
        }
        
        public override void Down()
        {
            AddForeignKey("dbo.PeopleInfo", "SecondaryCommunication_Id", "dbo.CommunicationTypes", "Id");
        }
    }
}
