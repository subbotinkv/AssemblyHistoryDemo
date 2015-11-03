namespace AssemblyHistoryApp.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class AssemblyMemberEntity
    {
        public AssemblyMemberEntity()
        {
            
        }

        public AssemblyMemberEntity(AssemblyEntity assembly, MemberInfo memberInfo)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly));
            }
            if (memberInfo == null)
            {
                throw new ArgumentNullException(nameof(memberInfo));
            }

            MemberType = memberInfo.MemberType;
            Name = memberInfo.Name;

            Assembly = assembly;
        }

        public int Id { get; set; }

        public MemberTypes MemberType { get; set; }

        public string Name { get; set; }

        public int AssemblyId { get; set; }

        public AssemblyEntity Assembly { get; set; }

        public ICollection<MemberAnnotationEntity> Annotations { get; set; }
    }
}