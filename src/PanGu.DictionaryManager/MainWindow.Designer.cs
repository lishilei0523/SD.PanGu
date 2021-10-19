using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PanGu.DictionaryManager
{
    partial class MainWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainWindow));
            this.menuStrip = new MenuStrip();
            this.fileToolStripMenuItem = new ToolStripMenuItem();
            this.openBinDictFile13ToolStripMenuItem = new ToolStripMenuItem();
            this.saveBinDictFile13ToolStripMenuItem = new ToolStripMenuItem();
            this.editToolStripMenuItem = new ToolStripMenuItem();
            this.findToolStripMenuItem = new ToolStripMenuItem();
            this.openFileDialogDict = new OpenFileDialog();
            this.saveFileDialogDict = new SaveFileDialog();
            this.textBoxSearch = new TextBox();
            this.panel1 = new Panel();
            this.listBoxList = new ListBox();
            this.contextMenuStripList = new ContextMenuStrip(this.components);
            this.exportToolStripMenuItem = new ToolStripMenuItem();
            this.buttonSearch = new Button();
            this.panelMain = new Panel();
            this.labelCount = new Label();
            this.label4 = new Label();
            this.buttonBatchInsert = new Button();
            this.buttonDelete = new Button();
            this.buttonUpdate = new Button();
            this.buttonInsert = new Button();
            this.label3 = new Label();
            this.numericUpDownFrequency = new NumericUpDown();
            this.label2 = new Label();
            this.textBoxWord = new TextBox();
            this.label1 = new Label();
            this.statusStrip = new StatusStrip();
            this.label = new ToolStripStatusLabel();
            this.openFileDialogName = new OpenFileDialog();
            this.saveFileDialogText = new SaveFileDialog();
            this.OpenAsTextToolStripMenuItem = new ToolStripMenuItem();
            this.SaveAsTextToolStripMenuItem = new ToolStripMenuItem();
            this.posCtrl = new PosCtrl();
            this.menuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStripList.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((ISupportInitialize)(this.numericUpDownFrequency)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip.Location = new Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new Size(792, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            this.openBinDictFile13ToolStripMenuItem,
            this.saveBinDictFile13ToolStripMenuItem,
            this.OpenAsTextToolStripMenuItem,
            this.SaveAsTextToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new Size(57, 20);
            this.fileToolStripMenuItem.Text = "文件(&F)";
            // 
            // openBinDictFile13ToolStripMenuItem
            // 
            this.openBinDictFile13ToolStripMenuItem.Name = "openBinDictFile13ToolStripMenuItem";
            this.openBinDictFile13ToolStripMenuItem.Size = new Size(182, 22);
            this.openBinDictFile13ToolStripMenuItem.Text = "打开(&O)";
            this.openBinDictFile13ToolStripMenuItem.Click += new EventHandler(this.openBinDictFile13ToolStripMenuItem_Click);
            // 
            // saveBinDictFile13ToolStripMenuItem
            // 
            this.saveBinDictFile13ToolStripMenuItem.Name = "saveBinDictFile13ToolStripMenuItem";
            this.saveBinDictFile13ToolStripMenuItem.Size = new Size(182, 22);
            this.saveBinDictFile13ToolStripMenuItem.Text = "保存(&S)";
            this.saveBinDictFile13ToolStripMenuItem.Click += new EventHandler(this.saveBinDictFile13ToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            this.findToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new Size(43, 20);
            this.editToolStripMenuItem.Text = "编辑";
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.Size = new Size(98, 22);
            this.findToolStripMenuItem.Text = "查找";
            this.findToolStripMenuItem.Click += new EventHandler(this.findToolStripMenuItem_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new Point(3, 3);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new Size(162, 20);
            this.textBoxSearch.TabIndex = 2;
            this.textBoxSearch.TextChanged += new EventHandler(this.textBoxSearch_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listBoxList);
            this.panel1.Controls.Add(this.buttonSearch);
            this.panel1.Controls.Add(this.textBoxSearch);
            this.panel1.Location = new Point(3, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(239, 515);
            this.panel1.TabIndex = 3;
            // 
            // listBoxList
            // 
            this.listBoxList.ContextMenuStrip = this.contextMenuStripList;
            this.listBoxList.FormattingEnabled = true;
            this.listBoxList.Location = new Point(4, 34);
            this.listBoxList.Name = "listBoxList";
            this.listBoxList.Size = new Size(228, 472);
            this.listBoxList.TabIndex = 4;
            this.listBoxList.SelectedIndexChanged += new EventHandler(this.listBoxList_SelectedIndexChanged);
            // 
            // contextMenuStripList
            // 
            this.contextMenuStripList.Items.AddRange(new ToolStripItem[] {
            this.exportToolStripMenuItem});
            this.contextMenuStripList.Name = "contextMenuStripList";
            this.contextMenuStripList.Size = new Size(99, 26);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new Size(98, 22);
            this.exportToolStripMenuItem.Text = "导出";
            this.exportToolStripMenuItem.Click += new EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new Point(183, 1);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new Size(49, 25);
            this.buttonSearch.TabIndex = 3;
            this.buttonSearch.Text = "查找";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new EventHandler(this.buttonSearch_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.labelCount);
            this.panelMain.Controls.Add(this.label4);
            this.panelMain.Controls.Add(this.buttonBatchInsert);
            this.panelMain.Controls.Add(this.buttonDelete);
            this.panelMain.Controls.Add(this.buttonUpdate);
            this.panelMain.Controls.Add(this.buttonInsert);
            this.panelMain.Controls.Add(this.label3);
            this.panelMain.Controls.Add(this.numericUpDownFrequency);
            this.panelMain.Controls.Add(this.label2);
            this.panelMain.Controls.Add(this.textBoxWord);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Controls.Add(this.panel1);
            this.panelMain.Controls.Add(this.posCtrl);
            this.panelMain.Enabled = false;
            this.panelMain.Location = new Point(0, 29);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new Size(792, 585);
            this.panelMain.TabIndex = 4;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new Point(351, 20);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new Size(13, 13);
            this.labelCount.TabIndex = 14;
            this.labelCount.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new Point(284, 21);
            this.label4.Name = "label4";
            this.label4.Size = new Size(67, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "单词总数：";
            // 
            // buttonBatchInsert
            // 
            this.buttonBatchInsert.Location = new Point(526, 505);
            this.buttonBatchInsert.Name = "buttonBatchInsert";
            this.buttonBatchInsert.Size = new Size(75, 25);
            this.buttonBatchInsert.TabIndex = 12;
            this.buttonBatchInsert.Text = "批量增加";
            this.buttonBatchInsert.UseVisualStyleBackColor = true;
            this.buttonBatchInsert.Click += new EventHandler(this.buttonBatchInsert_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Location = new Point(445, 504);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new Size(75, 25);
            this.buttonDelete.TabIndex = 11;
            this.buttonDelete.Text = "删除";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new EventHandler(this.buttonDelete_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Enabled = false;
            this.buttonUpdate.Location = new Point(364, 505);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new Size(75, 25);
            this.buttonUpdate.TabIndex = 10;
            this.buttonUpdate.Text = "修改";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new EventHandler(this.buttonUpdate_Click);
            // 
            // buttonInsert
            // 
            this.buttonInsert.Enabled = false;
            this.buttonInsert.Location = new Point(280, 504);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new Size(75, 25);
            this.buttonInsert.TabIndex = 9;
            this.buttonInsert.Text = "添加";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new EventHandler(this.buttonInsert_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new Point(284, 120);
            this.label3.Name = "label3";
            this.label3.Size = new Size(31, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "词性";
            // 
            // numericUpDownFrequency
            // 
            this.numericUpDownFrequency.Location = new Point(667, 48);
            this.numericUpDownFrequency.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numericUpDownFrequency.Name = "numericUpDownFrequency";
            this.numericUpDownFrequency.Size = new Size(70, 20);
            this.numericUpDownFrequency.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(619, 53);
            this.label2.Name = "label2";
            this.label2.Size = new Size(31, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "词频";
            // 
            // textBoxWord
            // 
            this.textBoxWord.Location = new Point(332, 48);
            this.textBoxWord.Name = "textBoxWord";
            this.textBoxWord.Size = new Size(261, 20);
            this.textBoxWord.TabIndex = 5;
            this.textBoxWord.TextChanged += new EventHandler(this.textBoxWord_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(284, 54);
            this.label1.Name = "label1";
            this.label1.Size = new Size(31, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "单词";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new ToolStripItem[] {
            this.label});
            this.statusStrip.Location = new Point(0, 591);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new Size(792, 22);
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "statusStrip1";
            // 
            // label
            // 
            this.label.Name = "label";
            this.label.Size = new Size(109, 17);
            this.label.Text = "toolStripStatusLabel1";
            // 
            // openFileDialogName
            // 
            this.openFileDialogName.DefaultExt = "*.dct";
            this.openFileDialogName.FileName = "UnknownWords.dct";
            this.openFileDialogName.Filter = "dict|*.dct";
            // 
            // saveFileDialogText
            // 
            this.saveFileDialogText.DefaultExt = "txt";
            this.saveFileDialogText.Filter = "Txt|*.txt";
            // 
            // OpenAsTextToolStripMenuItem
            // 
            this.OpenAsTextToolStripMenuItem.Name = "OpenAsTextToolStripMenuItem";
            this.OpenAsTextToolStripMenuItem.Size = new Size(182, 22);
            this.OpenAsTextToolStripMenuItem.Text = "以文本文件方式打开";
            this.OpenAsTextToolStripMenuItem.Click += new EventHandler(this.OpenAsTextToolStripMenuItem_Click);
            // 
            // SaveAsTextToolStripMenuItem
            // 
            this.SaveAsTextToolStripMenuItem.Name = "SaveAsTextToolStripMenuItem";
            this.SaveAsTextToolStripMenuItem.Size = new Size(182, 22);
            this.SaveAsTextToolStripMenuItem.Text = "保存为文本文件";
            this.SaveAsTextToolStripMenuItem.Click += new EventHandler(this.SaveAsTextToolStripMenuItem_Click);
            // 
            // posCtrl
            // 
            this.posCtrl.Location = new Point(286, 137);
            this.posCtrl.Name = "posCtrl";
            this.posCtrl.Pos = 0;
            this.posCtrl.Size = new Size(480, 293);
            this.posCtrl.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(792, 613);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "字典管理";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStripList.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((ISupportInitialize)(this.numericUpDownFrequency)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private OpenFileDialog openFileDialogDict;
        private SaveFileDialog saveFileDialogDict;
        private PosCtrl posCtrl;
        private TextBox textBoxSearch;
        private Panel panel1;
        private Button buttonSearch;
        private ListBox listBoxList;
        private Panel panelMain;
        private TextBox textBoxWord;
        private Label label1;
        private NumericUpDown numericUpDownFrequency;
        private Label label2;
        private Label label3;
        private Button buttonDelete;
        private Button buttonUpdate;
        private Button buttonInsert;
        private Button buttonBatchInsert;
        private Label labelCount;
        private Label label4;
        private ToolStripMenuItem openBinDictFile13ToolStripMenuItem;
        private ToolStripMenuItem saveBinDictFile13ToolStripMenuItem;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel label;
        private OpenFileDialog openFileDialogName;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem findToolStripMenuItem;
        private ContextMenuStrip contextMenuStripList;
        private ToolStripMenuItem exportToolStripMenuItem;
        private SaveFileDialog saveFileDialogText;
        private ToolStripMenuItem OpenAsTextToolStripMenuItem;
        private ToolStripMenuItem SaveAsTextToolStripMenuItem;

    }
}

