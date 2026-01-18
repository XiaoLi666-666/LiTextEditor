using LiTextEditor.FileIO.CSharp;
using System.Linq.Expressions;


namespace LiTextEditor.WinForms
{
    public partial class Form1 : Form
    {
        #region Windows Form Designer generated code
        private readonly TextFileHelper _textFileHelper = new();
        private readonly BinaryFileHelper _binaryFileHelper = new();
        private string _currentFilePath = string.Empty;
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Copy(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbMainEditor.SelectedText))
                {
                    tbMainEditor.Copy();
                    MessageBox.Show("已将选中内容复制到剪贴板", "复制成功", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("请先选中需要复制的文本内容", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"复制失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cut(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbMainEditor.SelectedText))
                {
                    tbMainEditor.Cut();
                    MessageBox.Show("已将选中内容剪切到剪切板", "剪切成功",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("请先选中需要剪切的文本内容", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"剪切失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Paste(object sender, EventArgs e)
        {
            try
            {
                if (Clipboard.ContainsText())
                {
                    tbMainEditor.Paste();

                    MessageBox.Show("已将剪贴板内容粘贴到编辑区", "粘贴成功",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("剪贴板中无可用文本内容", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"粘贴失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NewFile(object sender, EventArgs e)
        {
            try
            {
                if (tslSaveInfo.Text == "未保存")
                {
                    DialogResult result = MessageBox.Show("当前文档有未保存的修改，是否直接新建空白文档？",
                        "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                        return;
                }
                string blankText = _textFileHelper.CreateNewBlankText();
                tbMainEditor.Text = blankText;
                tbMainEditor.SelectAll();
                _currentFilePath = string.Empty;
                tslFilePath.Text = "未打开文件（空白文档）";
                tslSaveInfo.Text = "未保存";
                tslSaveInfo.BackColor = Color.Red;
                MessageBox.Show("已成功新建空白文档！", "新建成功",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"新建文档失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenFile(object sender, EventArgs e)
        {
            try
            {
                if (tslSaveInfo.Text == "未保存")
                {
                    DialogResult result = MessageBox.Show("当前文档有未保存的修改，是否直接打开新文件？", "提示",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                        return;
                }
                using OpenFileDialog openFileDialog = new();
                openFileDialog.Title = "选择要打开的文本文件";
                openFileDialog.Filter = "文本文件(*.txt)|*.txt|所哟文件(*.*)|*.*";
                openFileDialog.Multiselect = false;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _currentFilePath = openFileDialog.FileName;
                    string fileContent = _textFileHelper.OpenTextFile(_currentFilePath);
                    tbMainEditor.Text = fileContent;
                    tslFilePath.Text = $"当前文件：{_currentFilePath}";
                    SetIsSave();
                    MessageBox.Show(
                        $"已成功打开文件：{Path.GetFileName(_currentFilePath)}",
                        "打开成功",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                _currentFilePath = string.Empty;
                MessageBox.Show($"打开文件失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveFile(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(_currentFilePath))
                {
                    _textFileHelper.SaveTextFile(_currentFilePath, tbMainEditor.Text);
                    SetIsSave();
                    MessageBox.Show(
                        $"已经成功保存文件：{Path.GetFileName(_currentFilePath)}",
                        "保存成功",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    SaveFileDialog saveFileDialog = new()
                    {
                        Title = "将文档另存为",
                        Filter = "文本文件 (*.txt)|*.txt|所有文件 (*.*)|*.*",
                        DefaultExt = "txt",
                        RestoreDirectory = true
                    };
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        _currentFilePath = saveFileDialog.FileName;
                        _textFileHelper.SaveTextFile(_currentFilePath, tbMainEditor.Text);
                        SetIsSave();
                        MessageBox.Show($"已成功将文档另存为：{Path.GetFileName(_currentFilePath)}",
                            "另存为成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存文件失败：{ex.Message}",
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditorTextChanged(object sender, EventArgs e)
        {
            if (tbMainEditor.Modified)
            {
                tslSaveInfo.BackColor = Color.Red;
                tslSaveInfo.Text = "未保存";
            }
        }

        private void ExitEditor(object sender, EventArgs e)
        {
            try
            {
                bool hasUnsaavedChanges = !string.IsNullOrEmpty(_currentFilePath) && tbMainEditor.Modified;
                if (hasUnsaavedChanges)
                {
                    DialogResult result = MessageBox.Show(
                        $"当前文档 {Path.GetFileName(_currentFilePath)} 有未保存的修改。是否保存后退出？",
                        "退出确认",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);
                    switch (result)
                    {
                        case DialogResult.Yes:
                            SaveFile(sender, e);
                            Application.Exit();
                            break;
                        case DialogResult.No:
                            Application.Exit();
                            break;
                        case DialogResult.Cancel:
                            return;
                    }
                }
                else
                    Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"退出应用时出现错误：{ex.Message}",
                    "退出错误",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bool hasUnsaavedChanges = !string.IsNullOrEmpty(_currentFilePath) && tbMainEditor.Modified;
                if (hasUnsaavedChanges)
                {
                    DialogResult result = MessageBox.Show(
                        $"当前文档 {Path.GetFileName(_currentFilePath)} 有未保存的修改。是否保存后退出？",
                        "退出确认",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);
                    switch (result)
                    {
                        case DialogResult.Yes:
                            SaveFile(sender, e);
                            e.Cancel = false;
                            break;
                        case DialogResult.No:
                            e.Cancel = false;
                            break;
                        case DialogResult.Cancel:
                            e.Cancel = true;
                            return;
                    }
                }
                else
                    Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"退出应用时出现错误：{ex.Message}",
                    "退出错误",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // 暂未开发完成
        private void NotBeenDevelopedYet(object sender, EventArgs e)
        {
            MessageBox.Show
                (
                "暂未开发完成此功能",
                "提示",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
