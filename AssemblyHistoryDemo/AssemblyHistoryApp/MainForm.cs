namespace AssemblyHistoryApp
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;

    using DAL;

    public partial class MainForm : Form
    {
        private readonly AssemblyHistoryContext _dbContext;

        public MainForm()
        {
            InitializeComponent();

            // Поддержка EF-детейлов для GridControl.
            assembliesGridView.DataController.AllowIEnumerableDetails = true;

            // Связывание.
            _dbContext = new AssemblyHistoryContext();
            _dbContext.Assemblies.Include(a => a.Members.Select(b => b.Annotations)).Load();
            assembliesBindingSource.DataSource = _dbContext.Assemblies.Local.ToBindingList();
        }

        private void OpenToolStripMenuItemClick(object sender, EventArgs e)
        {
            DialogResult result = myOpenFileDialog.ShowDialog(this);

            // Если не выбрали сборку, то просто выходим.
            if (result != DialogResult.OK)
            {
                return;
            }

            int changes = LoadAssembly(myOpenFileDialog.FileName);
            MessageBox.Show($"Обработка сборки завершена. Добавлено {changes} новых записей.");
        }

        /// <summary>
        /// Загрузить и обработать сборку.
        /// </summary>
        /// <param name="fileName">Путь к сборке.</param>
        /// <returns>Количество добавленных в БД записей.</returns>
        private int LoadAssembly(string fileName)
        {
            // Загружаем сборку.
            Assembly assembly = Assembly.LoadFile(fileName); ;

            var historyExtractor = new HistoryExtractor(_dbContext);

            // Извлекаем историю из сборки.
            historyExtractor.ExtractFromAssembly(assembly);

            // Сохраняем изменения.
            return _dbContext.SaveChanges();
        }
    }
}