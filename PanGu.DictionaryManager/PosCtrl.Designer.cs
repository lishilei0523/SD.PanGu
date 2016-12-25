﻿using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PanGu.DictionaryManager
{
    partial class PosCtrl
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

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // PosCtrl
            // 
            this.AutoScaleDimensions = new SizeF(6F, 12F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Name = "PosCtrl";
            this.Size = new Size(538, 381);
            this.ResumeLayout(false);

        }

        #endregion

    }
}
