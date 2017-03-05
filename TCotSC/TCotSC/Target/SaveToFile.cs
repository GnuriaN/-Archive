using System;
using System.IO;
using System.Text;

namespace TCotSC
{
    /// <summary>
    /// Запись в файл
    /// </summary>
    public class SaveToFile: ITargetSave
    {
        /// <summary>
        /// Закрытое поле для хранения StreamWriter
        /// </summary>
        private readonly StreamWriter _steamFileToSave;
        /// <summary>
        /// Имя файла для записи
        /// </summary>
        private readonly string _fileName = "eventlog.log";
        /// <summary>
        /// Записываем в файл
        /// </summary>
        public void SendTo(Cigarete currentCigarette)
        {
            // Подготавливаем строку для вывода
            var text = $"{currentCigarette.СigaretteCount} {currentCigarette.СigaretteDateTime.ToString("dd.MM.yyyy")} {currentCigarette.СigaretteDateTime.ToString("HH:MM:ss")} {currentCigarette.СigaretteLabel}";
            // Записываем в поток
            _steamFileToSave.WriteLine(text);
            // Принудительно записываем в файл и очищаем поток
            _steamFileToSave.Flush();
        }
        /// <summary>
        /// Создаем объект для записи
        /// </summary>
        public SaveToFile()
        {
            // Путь где находиться файл для записи
            var fileName = AppDomain.CurrentDomain.BaseDirectory + _fileName;
            // Создаем экземпляр потока записи 
            var fileToSave = new FileInfo(fileName);
            // Открываем поток для до записи 
            _steamFileToSave = fileToSave.AppendText();
        }
    }
}