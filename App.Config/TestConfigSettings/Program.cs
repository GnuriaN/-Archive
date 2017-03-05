using System;
using System.Configuration;

namespace TestConfigSettings
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var section = (StartupFoldersConfigSection)ConfigurationManager.GetSection("StartupFolders");

            if (section != null)
            {
                for (var ind = 0; ind <= section.FolderItems.Count - 1; ind++)
                {
                    Console.WriteLine(section.FolderItems[ind].FolderType);
                    Console.WriteLine(section.FolderItems[ind].Path);
                }
            }

            Console.WriteLine("Press any key....");
            Console.ReadKey();
        }
    }
}