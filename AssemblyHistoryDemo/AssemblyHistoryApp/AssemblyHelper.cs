namespace AssemblyHistoryApp
{
    using System;
    using System.Linq;
    using System.Reflection;

    using DAL;

    using Common;

    public static class AssemblyHelper
    {
        public static void ProcessAssembly(Assembly assembly, AssemblyHistoryModel model)
        {
            // Попробуем достать сборку из БД.
            AssemblyEntity assemblyEntity = model.AssemblyEntities.FirstOrDefault(a => a.Name == assembly.FullName);
            if (assemblyEntity == null)
            {
                // Не нашли в БД - сборка загружается в первый раз и ее нужно добавить с БД.
                assemblyEntity = new AssemblyEntity { Name = assembly.FullName };
                model.AssemblyEntities.Add(assemblyEntity);
            }

            // Достанем из сборки все классы (по условию задачи обрабатываем только Классы и методы).
            var types = assembly.GetTypes().Where(a => a.IsClass);
            foreach (Type type in types)
            {
                ProcessTypes(type, model, assemblyEntity);
            }
        }

        private static void ProcessTypes(Type type, AssemblyHistoryModel model, AssemblyEntity assemblyEntity)
        {
            ProcessHistoryAttributes(model, assemblyEntity, type);

            // Достанем из класса все методы (по условию задачи обрабатываем только классы и Методы).
            var methods = type.GetMethods();
            foreach (MethodInfo method in methods)
            {
                ProcessHistoryAttributes(model, assemblyEntity, method);
            }
        }

        private static void ProcessHistoryAttributes(
            AssemblyHistoryModel model,
            AssemblyEntity assemblyEntity,
            MemberInfo info)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            var attributes = info.GetCustomAttributes<HistoryAttribute>();
            foreach (HistoryAttribute attribute in attributes)
            {
                ProcessHistoryAttribute(model, assemblyEntity, attribute);
            }
        }

        private static void ProcessHistoryAttribute(
            AssemblyHistoryModel model,
            AssemblyEntity assemblyEntity,
            HistoryAttribute attribute)
        {
            throw new NotImplementedException();
        }
    }
}
