using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ExerciseLog
{
    /// <summary>
    /// Вывода события в консоль
    /// </summary>
    public class ConsoleTarget : ITarget
    {
        public MakeFormat makeFormat;
        /// <summary>
        /// Реализация интерфейса ITarget вывода информации на консоль
        /// </summary>
        /// <param name="currentLog">Текущее событие</param>
        /// <param name="eventOption">Текущая важность события</param>
        public void SendTo(EventLog currentLog, EventOption eventOption)
        {
            //Вывод события в консоль
            Console.WriteLine(makeFormat.ToFormat(currentLog));
        }
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
        /// Объект для вывода события в консоль
        /// </summary>
        public ConsoleTarget()
        {
            makeFormat = new MakeFormat();
        }
    }
}