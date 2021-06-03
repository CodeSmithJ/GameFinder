namespace BFGgameFinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TheOnesOneTwo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Genre", "GenreType", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Genre", "GenreType", c => c.String());
        }
    }
}
