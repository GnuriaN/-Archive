using System.Configuration;

namespace TestConfigSettings
{
    /// <summary>
    /// 
    /// </summary>
    public class FolderElement : ConfigurationElement
    {
        [ConfigurationProperty("folderType", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string FolderType
        {
            get { return ((string)(base["folderType"])); }
            set { base["folderType"] = value; }
        }
        [ConfigurationProperty("path", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string Path
        {
            get { return ((string)(base["path"])); }
            set { base["path"] = value; }
        }
    }
}