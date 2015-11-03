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
        public MainForm()
        {
            InitializeComponent();
            
            // Поддержка EF-детейлов для GridControl.
            assembliesGridView.DataController.AllowIEnumerableDetails = true;
            
            // Связывание.
            var dbContext = new AssemblyHistoryContext();
            dbContext.Assemblies.Include(a => a.Members.Select(b => b.Annotations)).Load();
            assembliesBindingSource.DataSource = dbContext.Assemblies.Local.ToBindingList();
        }

        private void OpenToolStripMenuItemClick(object sender, EventArgs e)
        {
            DialogResult result = myOpenFileDialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                Assembly assembly = null;
                try
                {
                    assembly = Assembly.LoadFile(myOpenFileDialog.FileName);
                }
                catch (Exception)
                {
                    MessageBox.Show("Возникла ошибка при загрузке сборки. Попробуйте загрузить другую сборку.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Если удалось загрузить сборку, то обрабатываем ее.
                if (assembly != null)
                {
                    using (var context = new AssemblyHistoryContext())
                    {
                        var historyExtractor = new HistoryExtractor(context);

                        historyExtractor.ExtractFromAssembly(assembly);

                        int changes = context.SaveChanges();

                        MessageBox.Show($"Добавлено {changes} записей");
                    }
                }
            }
        }
    }
}