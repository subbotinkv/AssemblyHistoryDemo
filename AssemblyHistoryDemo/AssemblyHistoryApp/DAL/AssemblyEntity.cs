namespace AssemblyHistoryApp.DAL
{
    using System.Collections.Generic;

    public class AssemblyEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<AssemblyHistoryEntity> Details { get; set; }
    }
}