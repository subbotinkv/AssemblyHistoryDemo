namespace AssemblyHistoryApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.membersGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMemberType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMemberName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.assembliesGridControl = new DevExpress.XtraGrid.GridControl();
            this.assembliesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.assembliesGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.annotationsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.myOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.myMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuthor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.membersGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assembliesGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assembliesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assembliesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.annotationsGridView)).BeginInit();
            this.myMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // membersGridView
            // 
            this.membersGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMemberType,
            this.colMemberName});
            this.membersGridView.GridControl = this.assembliesGridControl;
            this.membersGridView.Name = "membersGridView";
            this.membersGridView.OptionsBehavior.Editable = false;
            this.membersGridView.OptionsView.ShowGroupPanel = false;
            this.membersGridView.OptionsView.ShowViewCaption = true;
            this.membersGridView.ViewCaption = "Члены сборки";
            // 
            // colMemberType
            // 
            this.colMemberType.Caption = "Тип";
            this.colMemberType.FieldName = "MemberType";
            this.colMemberType.Name = "colMemberType";
            this.colMemberType.Visible = true;
            this.colMemberType.VisibleIndex = 0;
            // 
            // colMemberName
            // 
            this.colMemberName.Caption = "Имя";
            this.colMemberName.FieldName = "Name";
            this.colMemberName.Name = "colMemberName";
            this.colMemberName.Visible = true;
            this.colMemberName.VisibleIndex = 1;
            // 
            // assembliesGridControl
            // 
            this.assembliesGridControl.DataSource = this.assembliesBindingSource;
            this.assembliesGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.membersGridView;
            gridLevelNode2.LevelTemplate = this.annotationsGridView;
            gridLevelNode2.RelationName = "Annotations";
            gridLevelNode1.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            gridLevelNode1.RelationName = "Members";
            this.assembliesGridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.assembliesGridControl.Location = new System.Drawing.Point(0, 24);
            this.assembliesGridControl.MainView = this.assembliesGridView;
            this.assembliesGridControl.Name = "assembliesGridControl";
            this.assembliesGridControl.ShowOnlyPredefinedDetails = true;
            this.assembliesGridControl.Size = new System.Drawing.Size(792, 579);
            this.assembliesGridControl.TabIndex = 1;
            this.assembliesGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.assembliesGridView,
            this.annotationsGridView,
            this.membersGridView});
            // 
            // assembliesBindingSource
            // 
            this.assembliesBindingSource.DataSource = typeof(AssemblyHistoryApp.DAL.AssemblyEntity);
            // 
            // assembliesGridView
            // 
            this.assembliesGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName});
            this.assembliesGridView.GridControl = this.assembliesGridControl;
            this.assembliesGridView.Name = "assembliesGridView";
            this.assembliesGridView.OptionsBehavior.Editable = false;
            this.assembliesGridView.OptionsView.ShowGroupPanel = false;
            this.assembliesGridView.ViewCaption = "Сборки";
            // 
            // colName
            // 
            this.colName.Caption = "Название сборки";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // annotationsGridView
            // 
            this.annotationsGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDateTime,
            this.colAuthor,
            this.colDescription});
            this.annotationsGridView.GridControl = this.assembliesGridControl;
            this.annotationsGridView.Name = "annotationsGridView";
            this.annotationsGridView.OptionsBehavior.Editable = false;
            this.annotationsGridView.OptionsView.ShowGroupPanel = false;
            this.annotationsGridView.OptionsView.ShowViewCaption = true;
            this.annotationsGridView.ViewCaption = "История";
            // 
            // myOpenFileDialog
            // 
            this.myOpenFileDialog.Filter = "Assemblies|*.dll";
            this.myOpenFileDialog.Title = "Выберите сборку";
            // 
            // myMenuStrip
            // 
            this.myMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.myMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.myMenuStrip.Name = "myMenuStrip";
            this.myMenuStrip.Size = new System.Drawing.Size(792, 24);
            this.myMenuStrip.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.myToolStripSeparator,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.openToolStripMenuItem.Text = "Открыть";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItemClick);
            // 
            // myToolStripSeparator
            // 
            this.myToolStripSeparator.Name = "myToolStripSeparator";
            this.myToolStripSeparator.Size = new System.Drawing.Size(118, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            // 
            // colDateTime
            // 
            this.colDateTime.Caption = "Дата";
            this.colDateTime.FieldName = "DateTime";
            this.colDateTime.Name = "colDateTime";
            this.colDateTime.Visible = true;
            this.colDateTime.VisibleIndex = 0;
            // 
            // colAuthor
            // 
            this.colAuthor.Caption = "Автор";
            this.colAuthor.FieldName = "Author";
            this.colAuthor.Name = "colAuthor";
            this.colAuthor.Visible = true;
            this.colAuthor.VisibleIndex = 1;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Описание";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 603);
            this.Controls.Add(this.assembliesGridControl);
            this.Controls.Add(this.myMenuStrip);
            this.MainMenuStrip = this.myMenuStrip;
            this.Name = "MainForm";
            this.Text = "Assembly History App";
            ((System.ComponentModel.ISupportInitialize)(this.membersGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assembliesGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assembliesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assembliesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.annotationsGridView)).EndInit();
            this.myMenuStrip.ResumeLayout(false);
            this.myMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog myOpenFileDialog;
        private System.Windows.Forms.MenuStrip myMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator myToolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private DevExpress.XtraGrid.GridControl assembliesGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView assembliesGridView;
        private System.Windows.Forms.BindingSource assembliesBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Views.Grid.GridView membersGridView;
        private DevExpress.XtraGrid.Columns.GridColumn colMemberType;
        private DevExpress.XtraGrid.Columns.GridColumn colMemberName;
        private DevExpress.XtraGrid.Views.Grid.GridView annotationsGridView;
        private DevExpress.XtraGrid.Columns.GridColumn colDateTime;
        private DevExpress.XtraGrid.Columns.GridColumn colAuthor;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
    }
}

