namespace sep24migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Subjects", "Name", c => c.String());
            DropColumn("dbo.Subjects", "Status");
            DropColumn("dbo.Subjects", "DateCreated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subjects", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Subjects", "Status", c => c.String());
            AlterColumn("dbo.Subjects", "Name", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
