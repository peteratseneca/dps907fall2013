namespace sep24migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Semesters = c.Int(nullable: false),
                        Credential = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false),
                        Status = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        Program_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Programs", t => t.Program_Id)
                .Index(t => t.Program_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Subjects", new[] { "Program_Id" });
            DropForeignKey("dbo.Subjects", "Program_Id", "dbo.Programs");
            DropTable("dbo.Subjects");
            DropTable("dbo.Programs");
        }
    }
}
