namespace AssemblyHistoryApp.DAL
{
    using System.Collections.Generic;

    public class AssemblyEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<AssemblyHistoryEntity> Details { get; protected set; }
    }
}