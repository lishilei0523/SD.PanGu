using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PanGu.DictionaryManager
{
    partial class EncoderView
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(EncoderView));
            this.comboBoxEncoder = new ComboBox();
            this.label1 = new Label();
            this.buttonOk = new Button();
            this.SuspendLayout();
            // 
            // comboBoxEncoder
            // 
            this.comboBoxEncoder.FormattingEnabled = true;
            this.comboBoxEncoder.Items.AddRange(new object[] {
            "UTF-8",
            "GB2312"});
            this.comboBoxEncoder.Location = new Point(140, 32);
            this.comboBoxEncoder.Name = "comboBoxEncoder";
            this.comboBoxEncoder.Size = new Size(121, 20);
            this.comboBoxEncoder.TabIndex = 0;
            this.comboBoxEncoder.Text = "UTF-8";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(23, 36);
            this.label1.Name = "label1";
            this.label1.Size = new Size(101, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "导入文本编码格式";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new Point(25, 78);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new Size(75, 23);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new EventHandler(this.buttonOk_Click);
            // 
            // FormEncoder
            // 
            this.AutoScaleDimensions = new SizeF(6F, 12F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(292, 134);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxEncoder);
            this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormEncoder";
            this.Text = "选择导入文本编码格式";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox comboBoxEncoder;
        private Label label1;
        private Button buttonOk;
    }
}