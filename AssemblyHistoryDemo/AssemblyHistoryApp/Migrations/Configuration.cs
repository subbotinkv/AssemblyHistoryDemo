namespace AssemblyHistoryApp.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.AssemblyHistoryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "AssemblyHistoryApp.DAL.AssemblyHistoryContext";
        }

        protected override void Seed(DAL.AssemblyHistoryContext context)
        {
            
        }
    }
}
