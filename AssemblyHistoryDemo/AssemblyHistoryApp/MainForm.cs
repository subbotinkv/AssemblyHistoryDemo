namespace AssemblyHistoryApp
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;

    using DAL;

    using Common;

    // TODO: Написать простые и XML-комменты.

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OpenToolStripMenuItemClick(object sender, EventArgs e)
        {
            DialogResult result = myOpenFileDialog.ShowDialog(this);
            if (result != DialogResult.OK)
            {
                return;
            }

            // TODO: обернуть в try/catch, т.к. при загрузке сборки можно получить ошибку.
            Assembly assembly = Assembly.LoadFile(myOpenFileDialog.FileName);
            if (assembly != null)
            {
                using (var model = new AssemblyHistoryModel())
                {
                    ProccessAssembly(assembly, model);
                }
            }
        }

        private void ProccessAssembly(Assembly assembly, AssemblyHistoryModel model)
        {
            AssemblyEntity assemblyEntity = model.AssemblyEntities.FirstOrDefault(a => a.Name == assembly.FullName);
            if (assemblyEntity == null)
            {
                assemblyEntity = new AssemblyEntity { Name = assembly.FullName };
                model.AssemblyEntities.Add(assemblyEntity);
            }

            var types = assembly.GetTypes().Where(a => a.IsClass);
            foreach (Type type in types)
            {
                ProcessClass(type, model, assemblyEntity);
            }
        }

        private void ProcessClass(Type type, AssemblyHistoryModel model, AssemblyEntity assemblyEntity)
        {
            ProcessMemberInfo(model, assemblyEntity, type);

            var methods = type.GetMethods();
            foreach (MethodInfo method in methods)
            {
                ProcessMemberInfo(model, assemblyEntity, method);
            }
        }

        private void ProcessMemberInfo(
            AssemblyHistoryModel model,
            AssemblyEntity assemblyEntity,
            MemberInfo info,
            string name = null)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                name = info.Name;
            }

            // TODO: реализовать получение HistoryEntityType по info.MemberType.

            var attributes = info.GetCustomAttributes<HistoryAttribute>();
            foreach (HistoryAttribute attribute in attributes)
            {
                ProcessHistoryAttribute(model, assemblyEntity, HistoryEntityType.Class, name, attribute);
            }
        }

        private void ProcessHistoryAttribute(
            AssemblyHistoryModel model,
            AssemblyEntity assemblyEntity,
            HistoryEntityType historyEntityType,
            string name,
            HistoryAttribute attribute)
        {
            // TODO: Реализация.
        }
    }
}
