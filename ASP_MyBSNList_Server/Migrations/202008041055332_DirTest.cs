using System.IO;

namespace ASP_MyBSNList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DirTest : DbMigration
    {
        public override void Up()
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
        }
        
        public override void Down()
        {
        }
    }
}
