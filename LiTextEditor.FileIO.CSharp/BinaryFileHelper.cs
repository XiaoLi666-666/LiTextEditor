using System;
using System.IO;
using System.Text;

namespace LiTextEditor.FileIO.CSharp
{
    /// <summary>
    /// 二进制文件操作工具类
    /// </summary>
    public class BinaryFileHelper
    {
        /// <summary>
        /// 文本内容转换为二进制字节数组（默认UTF-8）
        /// </summary>
        /// <param name="textContent">需要转换的文本内容</param>
        /// <returns>转换后的二进制字节数组</returns>
        /// <exception cref="Exception">当操作发生错误的时候抛出这个错误</exception>
        public byte[] ConvertTextToBinary(string textContent)
        {
            try
            {
                if (string.IsNullOrEmpty(textContent))
                    return Array.Empty<byte>();
                return Encoding.UTF8.GetBytes(textContent);
            }
            catch (Exception ex)
            {
                throw new Exception($"文本转换为二进制失败：{ex.Message}");
            }
        }

        /// <summary>
        /// 将二进制字节数组转换为文本内容（默认UTF-8）
        /// </summary>
        /// <param name="binaryData">需要转换的二进制字节数组</param>
        /// <returns>转换后的文本内容</returns>
        /// <exception cref="Exception">当操作发生错误的时候抛出这个错误</exception>
        public string ConvertBinaryToText(byte[] binaryData)
        {
            try
            {
                if (binaryData == null || binaryData.Length == 0)
                    return string.Empty;
                return Encoding.UTF8.GetString(binaryData);
            }
            catch (Exception ex)
            {
                throw new Exception($"二进制转换为文本失败：{ex.Message}");
            }
        }

        /// <summary>
        /// 读取二进制文件
        /// </summary>
        /// <param name="filePath">完整文件路径</param>
        /// <returns>对应的字节数组</returns>
        /// <exception cref="Exception">当操作发生错误的时候抛出这个错误</exception>
        public byte[] ReadBinaryFile(string filePath)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath))
                    throw new ArgumentNullException("二进制文件路径不能为空");
                if (!File.Exists(filePath))
                    throw new FileNotFoundException("目标二进制文件不存在");
                return File.ReadAllBytes(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception($"读取二进制文件失败：{ex.Message}");
            }
        }

        /// <summary>
        /// 保存二进制文件的完整路径
        /// </summary>
        /// <param name="filePath">保存二进制文件的完整路径</param>
        /// <param name="binaryData">需要写入的二进制字节数组</param>
        /// <exception cref="Exception">当操作发生错误的时候抛出这个错误</exception>
        public void WriteBinaryFile(string filePath, byte[] binaryData)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath))
                    throw new ArgumentNullException("二进制文件保存路径不能为空");
                if (binaryData == null)
                    binaryData = Array.Empty<byte>();
                string directoryPath = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);
                File.WriteAllBytes(filePath, binaryData);
            }
            catch (Exception ex)
            {
                throw new Exception($"写入二进制文件失败：{ex.Message}");
            }
        }
    }
}
