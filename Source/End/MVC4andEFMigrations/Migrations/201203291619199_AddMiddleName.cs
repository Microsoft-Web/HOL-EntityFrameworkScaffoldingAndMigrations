namespace MVC4andEFMigrations.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddMiddleName1 : DbMigration
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
