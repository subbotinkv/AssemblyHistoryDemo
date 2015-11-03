namespace AssemblyHistoryApp.DAL
{
    using System;

    public class AssemblyHistoryEntity
    {
        public int Id { get; set; }

        public virtual AssemblyEntity AssemblyEntity { get; set; }

        public int AssembyEntityId { get; set; }

        public HistoryEntityType HistoryEntityType { get; set; }

        public string Name { get; set; }

        public DateTime DateTime { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }
    }
}