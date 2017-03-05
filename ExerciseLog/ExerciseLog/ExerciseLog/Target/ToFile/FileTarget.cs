using System;
using System.IO;

namespace ExerciseLog
{
    /// <summary>
    /// Записи события в файл
    /// </summary>
    public class FileTarget : ITarget
    {
        /// <summary>
        /// Закрытое поле для хранения StreamWriter
        /// </summary>
        private StreamWriter _steamFileToSave;
        /// <summary>
        /// Поле для хранения формата вывода сообщения
        /// </summary>
        public MakeFormat makeFormat;
        /// <summary>
        ///  Шаблон вывода событий.
        /// </summary>
        /// <param name="format">Формат шаблона</param>
        public void SetFormat(string format)
        {
            makeFormat._formatTextSender = format;
            makeFormat.Make();
        }
        /// <summary>
        /// Объект для записи события в файл
        /// </summary>
        public FileTarget(string fileName, string pathToFile = null)
        {
            // Создаем эземпляр формата для вывода события
            makeFormat = new MakeFormat();
            // Проверка. Есои путь не указан, то использывать текущий каталог
            if (pathToFile == null) pathToFile = AppDomain.CurrentDomain.BaseDirectory;
            // Полный путь до файла
            var fullFileName = pathToFile + fileName;
            // Создаем объект для записи с поступившими настройками 
            var fileToSave = new FileToSave(fullFileName);
            // Открываем поток для до записи 
            _steamFileToSave = fileToSave.SteamFileToSave;
        }
        /// <summary>
        /// Реализация интерфейса ITarget для записи в файл
        /// </summary>
        /// <param name="currentLog">Текущее событие</param>
        /// <param name="eventOption">Текущая важность события</param>
        public void SendTo(EventLog currentLog, EventOption eventOption)
        {
            // Осуществляем запись в открытый поток
            _steamFileToSave.WriteLine(makeFormat.ToFormat(currentLog));
            // принудительно записываем в файл очищая поток
            _steamFileToSave.Flush();
        }
    }
}