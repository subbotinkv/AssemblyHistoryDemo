namespace AssemblyHistoryApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Common;
    using DAL;

    internal class HistoryExtractor
    {
        private readonly AssemblyHistoryContext _context;

        public HistoryExtractor(AssemblyHistoryContext context)
        {
            _context = context;
        }

        public void ExtractFromAssembly(Assembly assembly)
        {
            // Получим сборку.
            AssemblyEntity assemblyEntity = GetAssemblyEntity(assembly);

            // Извлечем все типы сборки.
            var assemblyTypes = assembly.GetTypes();

            // Обработаем классы сборки.
            ProcessTypes(assemblyEntity, assemblyTypes.Where(a => a.IsClass));

            // Возможность обрабатывать интерфейсы.
            //ProcessTypes(_context, assemblyEntity, assemblyTypes.Where(a=>a.IsInterface));
        }

        private void ProcessTypes(AssemblyEntity assemblyEntity, IEnumerable<Type> types)
        {
            foreach (Type type in types)
            {
                ProcessType(assemblyEntity, type);
            }
        }

        private void ProcessType(AssemblyEntity assemblyEntity, Type type)
        {
            ProcessMember(assemblyEntity, type);

            // Извлечем члены типа.
            var members = type.GetMembers();

            // Обработаем методы.
            ProcessMembers(assemblyEntity, members.Where(a => a.MemberType == MemberTypes.Method));

            // Возможность обработки свойств.
            //ProcessMembers(assemblyEntity, members.Where(a => a.MemberType == MemberTypes.Property));

            // Возможность обработки полей.
            //ProcessMembers(assemblyEntity, members.Where(a => a.MemberType == MemberTypes.Field));

            // И т.д.
        }

        private void ProcessMembers(AssemblyEntity assemblyEntity, IEnumerable<MemberInfo> memberInfos)
        {
            foreach (MemberInfo memberInfo in memberInfos)
            {
                ProcessMember(assemblyEntity, memberInfo);
            }
        }

        private void ProcessMember(AssemblyEntity assemblyEntity, MemberInfo memberInfo)
        {
            var historyAttributes = memberInfo.GetCustomAttributes<HistoryAttribute>().ToList();
            if (historyAttributes.Any())
            {
                AssemblyMemberEntity memberEntity = GetAssemblyMemberEntity(assemblyEntity, memberInfo);

                foreach (HistoryAttribute historyAttribute in historyAttributes)
                {
                    GetMemberAnnotationEntity(memberEntity, historyAttribute);
                }
            }
        }

        private AssemblyEntity GetAssemblyEntity(Assembly assembly)
        {
            AssemblyEntity assemblyEntity = _context.Assemblies.FirstOrDefault(a => a.Name == assembly.FullName);
            if (assemblyEntity == null)
            {
                assemblyEntity = new AssemblyEntity(assembly);
                _context.Assemblies.Add(assemblyEntity);
            }

            return assemblyEntity;
        }

        private AssemblyMemberEntity GetAssemblyMemberEntity(AssemblyEntity assemblyEntity, MemberInfo memberInfo)
        {
            AssemblyMemberEntity memberEntity = _context.Members.FirstOrDefault(a => a.MemberType == memberInfo.MemberType && a.Name == memberInfo.Name && a.AssemblyId == assemblyEntity.Id);
            if (memberEntity == null)
            {
                memberEntity = new AssemblyMemberEntity(assemblyEntity, memberInfo);
                _context.Members.Add(memberEntity);
            }

            return memberEntity;
        }

        private MemberAnnotationEntity GetMemberAnnotationEntity(AssemblyMemberEntity memberEntity, HistoryAttribute historyAttribute)
        {
            MemberAnnotationEntity annotationEntity =
                _context.Annotations.FirstOrDefault(
                    a => a.DateTime == historyAttribute.DateTime && a.Author == historyAttribute.Author && a.Description == historyAttribute.Description && a.MemberId == memberEntity.Id);
            if (annotationEntity == null)
            {
                annotationEntity = new MemberAnnotationEntity(memberEntity, historyAttribute);
                _context.Annotations.Add(annotationEntity);
            }

            return annotationEntity;
        }
    }
}
