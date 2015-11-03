namespace AssemblyHistoryApp.DAL
{
    using System.Data.Entity;

    public class AssemblyHistoryModel : DbContext
    {
        public AssemblyHistoryModel()
            : base("name=AssemblyHistoryModel")
        {
        }

        public virtual DbSet<AssemblyEntity> AssemblyEntities { get; set; }

        public virtual DbSet<AssemblyHistoryEntity> AssemblyHistoryEntities { get; set; }
    }
}