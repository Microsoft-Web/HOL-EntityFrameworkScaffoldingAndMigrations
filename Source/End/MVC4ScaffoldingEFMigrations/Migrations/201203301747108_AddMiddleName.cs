namespace MVC4ScaffoldingEFMigrations.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddMiddleName : DbMigration
    {
        public override void Up()
        {
            AddColumn("People", "MiddleName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("People", "MiddleName");
        }
    }
}
