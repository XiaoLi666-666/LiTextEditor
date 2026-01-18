using System;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace LiTextEditor.YAML.CSharp
{
    /// <summary>
    /// 通用YAML读写工具类
    /// </summary>
    // 暂时弃用
    [Obsolete("此类暂时弃用", true)]
    public class YamlCommonHelper
    {
        #region 通用配置：YAML解析器/序列化器
        /// <summary>
        /// 获取通用YAML反序列化器
        /// </summary>
        /// <returns>通用YAML反序列化器</returns>
        // 暂时弃用
        [Obsolete("此方法暂时弃用", true)]
        private static IDeserializer GetCommonDeserializer()
        {
            return new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .IgnoreUnmatchedProperties()
                .Build();
        }

        /// <summary>
        /// 获取通用YAML序列化器
        /// </summary>
        /// <returns>通用YAML序列化器</returns>
        // 暂时弃用
        [Obsolete("此方法暂时弃用", true)]
        private static ISerializer GetCommonSerializer()
        {
            return new SerializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
        }
        #endregion

        #region 从YAML反序列化为任意实体类
        // 暂时弃用
        [Obsolete("此方法暂时弃用", true)]
        public static T DeserializeFromYaml<T>(string yamlFilePath) where T : new()
        {
            if (string.IsNullOrEmpty(yamlFilePath))
                throw new ArgumentNullException(nameof(yamlFilePath), "YAML文件路径不能为空");
            return new T();
        }
        #endregion
    }
}
