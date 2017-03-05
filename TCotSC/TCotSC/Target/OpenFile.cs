using System;
using System.IO;

namespace TCotSC
{
    public class OpenFile: ITargetOpen
    {
        /// <summary>
        /// Имя файла для записи
        /// </summary>
        private readonly string _fileName = "eventlog.log";
        /// <summary>
        /// Последняя запись
        /// </summary>
        private readonly long _last;
        /// <summary>
        /// Получить номер последней записи из файла
        /// </summary>
        /// <returns>Номер последней записи</returns>
        public long LastCountRecord()
        {
            return _last;
        }
        /// <summary>
        /// Создаем объект для чтения
        /// </summary>
        public OpenFile()
        {
            // Путь где находиться файл для записи
            var fileName = AppDomain.CurrentDomain.BaseDirectory + _fileName;
            // Если файл не создан, то возвращаем 0 и выходим
            if (!File.Exists(fileName))
            {
                _last = 0;
                return;
            }
            // Полученем количество строк в файле, это и есть номер последней записи
            _last = System.IO.File.ReadAllLines(fileName).Length;
        }
    }
}