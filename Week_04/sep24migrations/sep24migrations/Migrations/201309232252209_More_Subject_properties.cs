namespace sep24migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class More_Subject_properties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subjects", "Status", c => c.String());
            AddColumn("dbo.Subjects", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Subjects", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Subjects", "Name", c => c.String());
            DropColumn("dbo.Subjects", "DateCreated");
            DropColumn("dbo.Subjects", "Status");
        }
    }
}
