namespace AssemblyHistoryApp
{
    using System;
    using System.Reflection;
    using System.Windows.Forms;

    using DAL;

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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
                    MessageBox.Show(
                        "Возникла ошибка при загрузке сборки. Попробуйте загрузить другую сборку.",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                // Если удалось загрузить сборку, то обрабатываем ее.
                if (assembly != null)
                {
                    using (var model = new AssemblyHistoryModel())
                    {
                        // Обработаем содержимое сборки.
                        AssemblyHelper.ProcessAssembly(assembly, model);

                        // Сохраним результат.
                        model.SaveChanges();
                    }
                }
            }
        }
    }
}
