namespace AssemblyHistoryApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Common;
    using DAL;

    /// <summary>
    /// Вспомогательный класс для извлечения истории.
    /// </summary>
    internal class HistoryExtractor
    {
        /// <summary>
        /// Контекст БД в которую ведется добавление информации.
        /// </summary>
        private readonly AssemblyHistoryContext _context;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context">Контекст БД.</param>
        public HistoryExtractor(AssemblyHistoryContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Извлечь историю (аннотации) из сборки.
        /// </summary>
        /// <param name="assembly">Сборка.</param>
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

        /// <summary>
        /// Произвести обработку типов.
        /// </summary>
        /// <param name="assemblyEntity">Сущность сборки для типов.</param>
        /// <param name="types">Типы, обработку которых необходимо произвести.</param>
        private void ProcessTypes(AssemblyEntity assemblyEntity, IEnumerable<Type> types)
        {
            foreach (Type type in types)
            {
                ProcessType(assemblyEntity, type);
            }
        }

        /// <summary>
        /// Произвести обработку одного типа.
        /// </summary>
        /// <param name="assemblyEntity">Сущность сборки для указанного типа.</param>
        /// <param name="type">Тип, обработку которого необходимо произвести.</param>
        private void ProcessType(AssemblyEntity assemblyEntity, Type type)
        {
            // Типы тоже являются наследниками MemberInfo, поэтому извлечение истории можно выполнять единообразно как для членов типов, так и для самих типов.
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

        /// <summary>
        /// Произвести обработку членов типа.
        /// </summary>
        /// <param name="assemblyEntity">Сущность сборки для типа.</param>
        /// <param name="memberInfos">Метаданные.</param>
        private void ProcessMembers(AssemblyEntity assemblyEntity, IEnumerable<MemberInfo> memberInfos)
        {
            foreach (MemberInfo memberInfo in memberInfos)
            {
                ProcessMember(assemblyEntity, memberInfo);
            }
        }

        /// <summary>
        /// Произвести обработку одного члена типа.
        /// </summary>
        /// <param name="assemblyEntity">Сущность сборки для типа.</param>
        /// <param name="memberInfo">Метаданные.</param>
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

        /// <summary>
        /// Получить существующую информацию о сборке, либо добавить ее в БД.
        /// </summary>
        /// <param name="assembly">Сборка.</param>
        /// <returns>Сущность сборки.</returns>
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

        /// <summary>
        /// Получить существующую информацию о содержимом сборки, либо добавить ее в БД.
        /// </summary>
        /// <param name="assemblyEntity">Сущность сборки, для которой необходимо получить информацию.</param>
        /// <param name="memberInfo">Метаданные содержимого сборки по которым нужно искать информацию.</param>
        /// <returns>Сущнось содержимого сборки.</returns>
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

        /// <summary>
        /// Получить существующую информацию о историии содержимого сборки, либо добавить ее в БД.
        /// </summary>
        /// <param name="memberEntity">Сущность содержимого сборки, для которой необходимо получить информацию.</param>
        /// <param name="historyAttribute">Атрибут истории по которому нужно искать информацию.</param>
        /// <returns>Сущность истории.</returns>
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
