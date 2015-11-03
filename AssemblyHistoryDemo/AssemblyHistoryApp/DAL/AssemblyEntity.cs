namespace AssemblyHistoryApp.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Reflection;

    public class AssemblyEntity
    {
        public AssemblyEntity()
        {
            
        }

        public AssemblyEntity(Assembly assembly)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly));
            }

            Name = assembly.FullName;
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<AssemblyMemberEntity> Members { get; set; }
    }
}