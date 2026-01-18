using System;
using System.IO;
using System.Text;

/// <summary>
/// 文本文件文件操作工具类
/// </summary>

namespace LiTextEditor.FileIO.CSharp
{
    /// <summary>
    /// 文本文件操作工具类
    /// </summary>
    public class TextFileHelper
    {
        /// <summary>
        /// 新建空白文本
        /// </summary>
        /// <returns>空白字符串</returns>
        public string CreateNewBlankText()
        {
            try
            {
                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception($"新建空白文本失败：{ex.Message}");
            }
        }

        /// <summary>
        /// 打开文本文件，返回文件内容（UTF-8）
        /// </summary>
        /// <param name="filePath">文本文件完整路径</param>
        /// <returns>文本文件中的内容</returns>
        /// <exception cref="Exception">打开文本文件时的错误</exception>
        public string OpenTextFile(string filePath)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath))
                    throw new ArgumentNullException("文件路径不能为空");
                if (!File.Exists(filePath))
                    throw new FileNotFoundException("目标文本文件不存在");
                return File.ReadAllText(filePath, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                throw new Exception($"打开文本文件失败：{ex.Message}");
            }
        }

        /// <summary>
        /// 保存文本内容到指定文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="textContent">需要保存的文本内容</param>
        /// <exception cref="Exception">在遇到参数为空时抛出此错误</exception>
        public void SaveTextFile(string filePath, string textContent)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath))
                    throw new ArgumentNullException("保存路径不能为空");
                if (textContent == null)
                    textContent = string.Empty;
                string directoryPath = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);
                File.WriteAllText(filePath, textContent, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                throw new Exception("保存文本文件失败：" + ex.Message);
            }
        }
    }
}