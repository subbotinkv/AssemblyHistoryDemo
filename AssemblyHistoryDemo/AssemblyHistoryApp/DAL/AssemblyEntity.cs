namespace AssemblyHistoryApp.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Reflection;

    /// <summary>
    /// �������� ��� �������� � �� ���������� � �������.
    /// </summary>
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

        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Name { get; set; }

        public ICollection<AssemblyMemberEntity> Members { get; set; }
    }
}