using System.Configuration;

namespace TestConfigSettings
{
    /// <summary>
    /// 
    /// </summary>
    public class StartupFoldersConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("Folders")]
        public FoldersCollection FolderItems
        {
            get { return ((FoldersCollection)(base["Folders"])); }
        }
    }
}