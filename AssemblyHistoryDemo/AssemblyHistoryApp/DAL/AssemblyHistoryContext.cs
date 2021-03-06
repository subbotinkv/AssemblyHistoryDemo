namespace AssemblyHistoryApp.DAL
{
    using System.Data.Entity;

    public class AssemblyHistoryContext : DbContext
    {
        public AssemblyHistoryContext()
            : base("name=AssemblyHistoryContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AssemblyHistoryContext, Migrations.Configuration>());
        }

        public DbSet<AssemblyEntity> Assemblies { get; set; }

        public DbSet<AssemblyMemberEntity> Members { get; set; }

        public DbSet<MemberAnnotationEntity> Annotations { get; set; }
    }
}