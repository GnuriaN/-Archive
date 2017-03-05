using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ExerciseLog
{
    /// <summary>
    /// Записи в журнал Microsoft Event Log
    /// </summary>
    public class MsEventLogJournalTarget : ITarget
    {
        public MakeFormat makeFormat;
        /// <summary>
        /// Закрытое поле для хранения System.Diagnostics.EventLog
        /// </summary>
        private System.Diagnostics.EventLog eventLog;
        /// <summary>
        /// Системный код события.
        /// </summary>
        private int _codeEvent;
        /// <summary>
        /// Системная категория события.
        /// </summary>
        private short _category;
        /// <summary>
        ///  Шаблон вывода событий.
        /// </summary>
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
        /// Конструктор класса MSEventLogJournalTarget
        /// </summary>
        /// <param name="eventJournalSource">Журнал для записи. По умолчанию: Запись в "Журналы Windows", журнал "Приложения"</param>
        /// <param name="codeEvent">Системный код события. По умолчанию: 55555</param>
        /// <param name="category">Системная категория события.  Варианты значения: 0  =  Отсутствует; 1  =  Устройства; 2  =  Диск; 3  =  Принтеры;
        /// 4  =  Службы; 5  =  Оболочка; 6  =  Системное событие; 7  =  Сеть  8 и больше создает свое уникальное значение типа (Значение).
        /// По умолчанию: 6 </param>
        public MsEventLogJournalTarget(string eventJournalSource = "Application", int codeEvent = 55555, short category = 6)
        {
            makeFormat = new MakeFormat();
            // Установка настроек до умолчанию
            _codeEvent = codeEvent;
            _category = category;
            // Экземпляр класса System.Diagnostics.EventLog для работы с "Журналами Событий Windows"
            eventLog = new System.Diagnostics.EventLog
            {
                // Указываем журнал куда пишутся сообщения
                Source = eventJournalSource
            };
        }
        /// <summary>
        /// Реализация интерфейса ITarget для записи в журнал Microsoft Event Log
        /// </summary>
        /// <param name="currentLog">Текущее событие</param>
        /// <param name="eventOption">Текущая важность события</param>
        public void SendTo(EventLog currentLog, EventOption eventOption)
        {
            // Запись в "Журналы Windows", журнал "Приложения" 
            // Полная расшифровка в конце файла.
            // public static void WriteEntry(string message, EventLogEntryType type, int eventID, short category)
            eventLog.WriteEntry(makeFormat.ToFormat(currentLog), EventLevel(eventOption), _codeEvent, _category);
        }
        /// <summary>
        /// Получение системного уровня предупреждения
        /// </summary>
        /// <param name="eventOption">Текущая важность события</param>
        private System.Diagnostics.EventLogEntryType EventLevel(EventOption eventOption)
        {
            System.Diagnostics.EventLogEntryType level;
            // Соотносим параметр eventOption с параметром _level
            // Fatal (0)  <=>  Error         (1)
            // Error (1)  <=>  Error         (1)
            // Warn  (2)  <=>  Warning       (2)
            // Info  (3)  <=>  Information   (4)
            // Debug (4)  <=>  Information   (4)
            // Trace (5)  <=>  Information   (4)
            switch (eventOption)
            {
                case EventOption.Fatal:
                case EventOption.Error:
                    level = System.Diagnostics.EventLogEntryType.Error;
                    break;
                case EventOption.Warn:
                    level = System.Diagnostics.EventLogEntryType.Warning;
                    break;
                case EventOption.Info:
                case EventOption.Debug:
                case EventOption.Trace:
                    level = System.Diagnostics.EventLogEntryType.Information;
                    break;
                default:
                    throw new System.ArgumentOutOfRangeException(nameof(eventOption), eventOption, null);
            }
            return level;
        }
    }
}
/***************************************************************************************************************************************************************************************************
public static void WriteEntry(    
string source,   -> запись идет в System.Provider[NAME]                                                    | запись в "Общее" поле "Источник".
string message,  -> запись идет в EventData                                                                | запись в "Общее" поле "Сведенья сообщения".
EventLogEntryType type,          -> EventLogEntryType.Information  - запись идет в System.Level (???)      | запись в "Общее" поле "Уровень".
         {
         - Error        | Level = 1  | Ошибка. Указывает на существенную проблему, о которой необходимо сообщить пользователю; как правило, это потеря данных или функциональных возможностей.
         - FailureAudit | Level = 16 | Аудит отказов. Указывает на событие, происходящее в системе безопасности при сбое контролируемого доступа, такое как сбой при открытии файла.
         - Information  | Level = 4  | Уведомление. Указывает на то, что важная операция успешно выполнена.
         - SuccessAudit | Level = 8  | Аудит успехов. Указывает на событие, происходящее в системе безопасности при успешной попытке контролируемого доступа, например при успешном входе в систему.
         - Warning      | Level = 2  | Предупреждение. Указывает на незначительную проблему, которая, однако, может свидетельствовать о наличии предпосылок для возникновения проблем в дальнейшем.
         {
int eventID,     -> запись идет в System.EventID                                                           | запись в Общее Код.  
short category,  -> запись идет в System.                                                                  | запись в "Общее" поле "Категория задачи"
         - 0  =  Отсутствует
         - 1  =  Устройства
         - 2  =  Диск
         - 3  =  Принтеры
         - 4  =  Службы
         - 5  =  Оболочка
         - 6  =  Системное событие
         - 7  =  Сеть
         - 8+ =  (8+) указывается число в скобках без расшифровки значения.
byte[] rawData   -> 
)
****************************************************************************************************************************************************************************************************/