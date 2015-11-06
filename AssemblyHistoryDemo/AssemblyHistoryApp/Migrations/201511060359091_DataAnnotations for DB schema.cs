namespace AssemblyHistoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotationsforDBschema : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MemberAnnotationEntities", "Author", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.MemberAnnotationEntities", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.AssemblyMemberEntities", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.AssemblyEntities", "Name", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AssemblyEntities", "Name", c => c.String());
            AlterColumn("dbo.AssemblyMemberEntities", "Name", c => c.String());
            AlterColumn("dbo.MemberAnnotationEntities", "Description", c => c.String());
            AlterColumn("dbo.MemberAnnotationEntities", "Author", c => c.String());
        }
    }
}
