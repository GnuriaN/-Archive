
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExerciseLog
{
    /// <summary>
    /// Файл для сохранения данных логера
    /// </summary>
    public class FileToSave
    {
        /// <summary>
        /// Список содержащий полный путь всех открытых фалов для записи логов
        /// </summary>
        private static List<string> setting = new List<string>();
        /// <summary>
        /// Словарь содержит полный путь к файлу для зписи и обеъект куда идет запись
        /// </summary>
        public static Dictionary<string, FileToSave> currentFileToSaves = new Dictionary<string, FileToSave>();
        /// <summary>
        /// Закрытое поле для хранения FileInfo
        /// </summary>
        private FileInfo _fileToSave;
        /// <summary>
        /// Закрытое поле для хранения StreamWriter
        /// </summary>
        private StreamWriter _steamFileToSave;
        /// <summary>
        /// Свойство для работы с полем для хранения StreamWriter
        /// </summary>
        public StreamWriter SteamFileToSave
        {
            get
            {
                return _steamFileToSave;
            }
            //Закрыто для изменения из вне
            private set
            {
                _steamFileToSave = value;
            }
        }
        /// <summary>
        /// Проверка настроек куда записывается логер
        /// </summary>
        /// <param name="currentSetting">Текущие настройки</param>
        /// <returns></returns>
        private bool chekSetting(string currentSetting)
        {
            // проверяем настройки 
            return setting.Any(_ => _ == currentSetting);
        }
        /// <summary>
        /// Создаем объект для записи
        /// </summary>
        public FileToSave(string currentSetting)
        {
            if (chekSetting(currentSetting))
            // Такой файл уже есть то присваиваем его поток для записи
            {
                SteamFileToSave = currentFileToSaves[currentSetting].SteamFileToSave;
            }
            // Такого файла нет то зоздаем поток для записи
            else
            {
                // Записываем параметр созданного логера
                setting.Add(currentSetting);
                // Создаем экземпляр потока записи 
                _fileToSave = new FileInfo(currentSetting);
                // Записываем в словарь настроект файлов для сохранения "полный путь к файлу(currentSetting)" и объект файла (FileToSave)
                currentFileToSaves.Add(currentSetting, this);
                // Открываем поток для до записи 
                SteamFileToSave = _fileToSave.AppendText();
            }
        }
    }
}