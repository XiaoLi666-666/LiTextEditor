using LiTextEditor.FileIO.CSharp;

namespace LiTextEditor.WinForms
{
    partial class Form1
    {
        /// <summary>
        /// 设置保存
        /// </summary>
        protected void SetIsSave()
        {
            tslSaveInfo.Text = "已保存";
            tslSaveInfo.BackColor = Color.Green;
            tbMainEditor.Modified = false;
        }
        /// <summary>
        /// 设置未保存
        /// </summary>
        protected void SetIsNotSave(bool jc = true)
        {
            if (jc && tbMainEditor.Modified)
            {
                tslSaveInfo.Text = "未保存";
                tslSaveInfo.BackColor = Color.Red;
            }
        }
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            msMainMenu = new MenuStrip();
            tsmiFile = new ToolStripMenuItem();
            tsmiNew = new ToolStripMenuItem();
            tsmiOpen = new ToolStripMenuItem();
            tsmiSave = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            tsmiBackup = new ToolStripMenuItem();
            tsmiViewAllBackups = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            tsmiExit = new ToolStripMenuItem();
            tsmiEdit = new ToolStripMenuItem();
            tsmiCopy = new ToolStripMenuItem();
            tsmiCut = new ToolStripMenuItem();
            tsmiPaste = new ToolStripMenuItem();
            tsmiSet = new ToolStripMenuItem();
            tbMainEditor = new TextBox();
            ssMainStatus = new StatusStrip();
            tslFilePath = new ToolStripStatusLabel();
            tslThemeInfo = new ToolStripStatusLabel();
            tslSaveInfo = new ToolStripStatusLabel();
            msMainMenu.SuspendLayout();
            ssMainStatus.SuspendLayout();
            SuspendLayout();
            // 
            // msMainMenu
            // 
            msMainMenu.Items.AddRange(new ToolStripItem[] { tsmiFile, tsmiEdit, tsmiSet });
            msMainMenu.Location = new Point(0, 0);
            msMainMenu.Name = "msMainMenu";
            msMainMenu.Size = new Size(800, 25);
            msMainMenu.TabIndex = 0;
            msMainMenu.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            tsmiFile.DropDownItems.AddRange(new ToolStripItem[] { tsmiNew, tsmiOpen, tsmiSave, toolStripMenuItem1, tsmiBackup, tsmiViewAllBackups, toolStripMenuItem2, tsmiExit });
            tsmiFile.Name = "tsmiFile";
            tsmiFile.ShortcutKeys = Keys.Alt | Keys.F;
            tsmiFile.Size = new Size(87, 21);
            tsmiFile.Text = "文件（&File）";
            // 
            // tsmiNew
            // 
            tsmiNew.Name = "tsmiNew";
            tsmiNew.ShortcutKeys = Keys.Control | Keys.N;
            tsmiNew.Size = new Size(307, 22);
            tsmiNew.Text = "新建（&New）";
            tsmiNew.Click += NewFile;
            // 
            // tsmiOpen
            // 
            tsmiOpen.Name = "tsmiOpen";
            tsmiOpen.ShortcutKeys = Keys.Control | Keys.O;
            tsmiOpen.Size = new Size(307, 22);
            tsmiOpen.Text = "打开（&Open）";
            tsmiOpen.Click += OpenFile;
            // 
            // tsmiSave
            // 
            tsmiSave.Name = "tsmiSave";
            tsmiSave.ShortcutKeys = Keys.Control | Keys.S;
            tsmiSave.Size = new Size(307, 22);
            tsmiSave.Text = "保存（&Save）";
            tsmiSave.Click += SaveFile;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(304, 6);
            // 
            // tsmiBackup
            // 
            tsmiBackup.BackColor = Color.Orange;
            tsmiBackup.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Strikeout, GraphicsUnit.Point, 134);
            tsmiBackup.Name = "tsmiBackup";
            tsmiBackup.ShortcutKeys = Keys.Control | Keys.B;
            tsmiBackup.Size = new Size(307, 22);
            tsmiBackup.Text = "备份（&Backup）";
            tsmiBackup.Click += NotBeenDevelopedYet;
            // 
            // tsmiViewAllBackups
            // 
            tsmiViewAllBackups.BackColor = Color.Orange;
            tsmiViewAllBackups.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Strikeout, GraphicsUnit.Point, 134);
            tsmiViewAllBackups.Name = "tsmiViewAllBackups";
            tsmiViewAllBackups.ShortcutKeys = Keys.Control | Keys.V;
            tsmiViewAllBackups.Size = new Size(307, 22);
            tsmiViewAllBackups.Text = "查看所有备份（&ViewAllBackups）";
            tsmiViewAllBackups.Click += NotBeenDevelopedYet;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(304, 6);
            // 
            // tsmiExit
            // 
            tsmiExit.Name = "tsmiExit";
            tsmiExit.ShortcutKeys = Keys.Alt | Keys.F4;
            tsmiExit.Size = new Size(307, 22);
            tsmiExit.Text = "退出（&X exit）";
            tsmiExit.Click += ExitEditor;
            // 
            // tsmiEdit
            // 
            tsmiEdit.DropDownItems.AddRange(new ToolStripItem[] { tsmiCopy, tsmiCut, tsmiPaste });
            tsmiEdit.Name = "tsmiEdit";
            tsmiEdit.ShortcutKeys = Keys.Alt | Keys.E;
            tsmiEdit.Size = new Size(90, 21);
            tsmiEdit.Text = "编辑（&Edit）";
            // 
            // tsmiCopy
            // 
            tsmiCopy.Name = "tsmiCopy";
            tsmiCopy.ShortcutKeys = Keys.Control | Keys.C;
            tsmiCopy.Size = new Size(177, 22);
            tsmiCopy.Text = "复制（&C）";
            tsmiCopy.Click += Copy;
            // 
            // tsmiCut
            // 
            tsmiCut.Name = "tsmiCut";
            tsmiCut.ShortcutKeys = Keys.Control | Keys.X;
            tsmiCut.Size = new Size(177, 22);
            tsmiCut.Text = "剪切（&T）";
            tsmiCut.Click += Cut;
            // 
            // tsmiPaste
            // 
            tsmiPaste.Name = "tsmiPaste";
            tsmiPaste.ShortcutKeys = Keys.Control | Keys.V;
            tsmiPaste.Size = new Size(177, 22);
            tsmiPaste.Text = "粘贴（&P）";
            tsmiPaste.Click += Paste;
            // 
            // tsmiSet
            // 
            tsmiSet.BackColor = Color.Orange;
            tsmiSet.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Strikeout, GraphicsUnit.Point, 134);
            tsmiSet.Name = "tsmiSet";
            tsmiSet.Size = new Size(86, 21);
            tsmiSet.Text = "设置（&Set）";
            // 
            // tbMainEditor
            // 
            tbMainEditor.Dock = DockStyle.Fill;
            tbMainEditor.Font = new Font("新宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            tbMainEditor.Location = new Point(0, 25);
            tbMainEditor.Multiline = true;
            tbMainEditor.Name = "tbMainEditor";
            tbMainEditor.Size = new Size(800, 425);
            tbMainEditor.TabIndex = 1;
            tbMainEditor.Text = "欢迎来到LiTextEditor！！！";
            tbMainEditor.TextChanged += EditorTextChanged;
            // 
            // ssMainStatus
            // 
            ssMainStatus.Items.AddRange(new ToolStripItem[] { tslFilePath, tslThemeInfo, tslSaveInfo });
            ssMainStatus.Location = new Point(0, 428);
            ssMainStatus.Name = "ssMainStatus";
            ssMainStatus.Size = new Size(800, 22);
            ssMainStatus.TabIndex = 2;
            ssMainStatus.Text = "statusStrip1";
            // 
            // tslFilePath
            // 
            tslFilePath.Name = "tslFilePath";
            tslFilePath.Size = new Size(68, 17);
            tslFilePath.Text = "未打开文件";
            // 
            // tslThemeInfo
            // 
            tslThemeInfo.Name = "tslThemeInfo";
            tslThemeInfo.Size = new Size(104, 17);
            tslThemeInfo.Text = "系统主题：未适配";
            // 
            // tslSaveInfo
            // 
            tslSaveInfo.BackColor = Color.Red;
            tslSaveInfo.ForeColor = Color.White;
            tslSaveInfo.Name = "tslSaveInfo";
            tslSaveInfo.RightToLeftAutoMirrorImage = true;
            tslSaveInfo.Size = new Size(44, 17);
            tslSaveInfo.Text = "未保存";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ssMainStatus);
            Controls.Add(tbMainEditor);
            Controls.Add(msMainMenu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = msMainMenu;
            Name = "Form1";
            Text = "LiTextEditor";
            FormClosing += Form1_Closing;
            msMainMenu.ResumeLayout(false);
            msMainMenu.PerformLayout();
            ssMainStatus.ResumeLayout(false);
            ssMainStatus.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip msMainMenu;
        private ToolStripMenuItem tsmiFile;
        private ToolStripMenuItem tsmiEdit;
        private ToolStripMenuItem tsmiNew;
        private ToolStripMenuItem tsmiOpen;
        private ToolStripMenuItem tsmiSave;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem tsmiBackup;
        private ToolStripMenuItem tsmiViewAllBackups;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem tsmiExit;
        private ToolStripMenuItem tsmiCopy;
        private ToolStripMenuItem tsmiCut;
        private ToolStripMenuItem tsmiPaste;
        private TextBox tbMainEditor;
        private StatusStrip ssMainStatus;
        private ToolStripStatusLabel tslFilePath;
        private ToolStripStatusLabel tslThemeInfo;
        private ToolStripStatusLabel tslSaveInfo;
        private ToolStripMenuItem tsmiSet;
    }
}


// Li