using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExerciseLog
{
    /// <summary>
    /// Создание формата вывода сообщения
    /// </summary>
    public class MakeFormat
    {
        //
        /// <summary>
        /// Шаблон вывода событий. Правила постоение .Format
        /// по умолчанию
        /// "{number:true} {date:dd.MM.yyyy} {time:HH:MM:ss} {importance:true} {message:true}"
        /// {порядковый номер события} {дата} {время} {важность} {сообщение}
        /// </summary>
        public string _formatTextSender = @"{number:true} {date:dd.MM.yyyy} {time:HH:MM:ss} {importance:true} {message:true}";
        /// <summary>
        /// Шаблон приведения формата
        /// </summary>
        public string _formatText = "{{{0}}}{{{1}}}{{{2}}}{{{3}}}{{{4}}}";
        /// <summary>
        /// Шаблон для даты
        /// </summary>
        public string _formatDate = "dd.MM.yyyy";
        /// <summary>
        /// Шаблон для времени
        /// </summary>
        public string _formatTime = "HH:MM:ss";
        /// <summary>
        /// Создание формата вывода от установленного шаблона _formatTextSender
        /// </summary>
        public void Make()
        {
            // Переменная формата вывода сообщения
            var formatText = new StringBuilder("");
            // Перемеменная формата даты
            var formatDate = new StringBuilder("");
            // переменная формата времени
            var formatTime = new StringBuilder("");
            // Задаем шаблон поиска выражения пораждающий две группы рещультатов
            // первая группа {"значение"} и вторая группа "значение"
            var pattern = @"{(\S*)}";
            // Находим все совпадения в строке format 
            var match = new Regex(pattern).Match(_formatTextSender);
            // Перебераем полученые результаты 
            while (match.Success)
            {
                // разделяем "Имя" параметра и "Значение" из второй группы где храняться "значения"
                // по формату "название параметра" : "значение параметра"
                var res = match.Groups[1].Value.Split(new char[] { ':' }, 2);
                // Выводим на консоль полученные результаты
                switch (res[0])
                {
                    case "number":
                        if (Convert.ToBoolean(res[1])) formatText.Append("{{{0}}}");
                        break;
                    case "date":
                        formatText.Append("{{{1}}}");
                        formatDate.Append(res[1]);
                        break;
                    case "time":
                        formatText.Append("{{{2}}}");
                        formatTime.Append(res[1]);
                        break;
                    case "importance":
                        if (Convert.ToBoolean(res[1])) formatText.Append("{{{3}}}");
                        break;
                    case "message":
                        if (Convert.ToBoolean(res[1])) formatText.Append("{{{4}}}");
                        break;
                    default:
                        // Принудительно вызываем исключение с указанием ошибки формирования формата
                        throw new Exception(string.Format("Ошибка: { 0 }", res[0]));
                        //break;
                }
                // Переходим к следующему совпадению
                match = match.NextMatch();
            }
            _formatText = formatText.ToString();
            _formatDate = formatDate.ToString();
            _formatTime = formatTime.ToString();
        }// Make()
        /// <summary>
        /// Приведение к формату выдачи сообщения перед записью
        /// </summary>
        /// <param name="currentLog">Текущее событие</param>
        /// <returns></returns>
        public string ToFormat(EventLog currentLog)
        {
            return string.Format(_formatText,
                currentLog.EventNumber.ToString(),
                currentLog.EventDate.ToString(_formatDate),
                currentLog.EventDate.ToString(_formatTime),
                currentLog.EventImportance.ToString(),
                currentLog.EventMessage);
        }// ToFormat()

    }
}
