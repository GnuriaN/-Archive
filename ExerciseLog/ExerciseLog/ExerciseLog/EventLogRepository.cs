using System;
using System.Collections.Generic;

namespace ExerciseLog
{
    /// <summary>
    /// Логер
    /// </summary>
    public class EventLogRepository
    {
        //*********************************************************************
        // Закрытые поля класса
        //*********************************************************************

        /// <summary>
        /// Экземпляр класса EventLogRepository
        /// </summary>
        private static readonly EventLogRepository defaultLog = new EventLogRepository();
        /// <summary>
        /// Словарь экземпляров именных логеров &lt;имя логера,  экземпляр класса EventLogRepository&gt;
        /// </summary>
        private static Dictionary<string, EventLogRepository> instance = new Dictionary<string, EventLogRepository>();
        /// <summary>
        /// Текущий уровень записи событий
        /// </summary>
        private EventOption _level = EventOption.Trace;
        //*********************************************************************
        // Открытые поля класса
        //*********************************************************************

        /// <summary>
        /// Коллекция для хранения произошедших событий
        /// </summary>
        public List<EventLog> EventLogList = new List<EventLog>();
        /// <summary>
        /// Точка назначения вывода событий
        /// </summary>
        public ITarget Sender = new ConsoleTarget();

        //*********************************************************************
        // Публичные методы
        //*********************************************************************
       
        /// <summary>
        /// Доступ к именному логеру
        /// </summary>
        public static Dictionary<string, EventLogRepository> Instance
        {
            get { return instance; }
        }
        /// <summary>
        /// Логер по умолчанию
        /// </summary>
        public static EventLogRepository DefaultLog
        {
            get { return defaultLog; }
        }
        /// <summary>
        /// Создание именного логера 
        /// </summary>
        /// <param name="name">Идентификатор логера</param>
        public static void Create(string name)
        {
            try
            {
                // Добовляем экземпляр созданного объекта в словарь
                instance.Add(name, new EventLogRepository());
            }
            // Исключение на случий повторения имени
            // мне кажеться или это как то по другому должно быть реализовано для библиотеке?
            // какая консоль в библиотеке? А если логер применяеться к другом типе приложений?
            catch (ArgumentException)
            {
                Console.WriteLine("Элимент {0} уже создан", name);
            }
        }
        /// <summary>
        /// Установить необходимый уровень важности записи событий
        /// </summary>
        /// <param name="level"></param>
        public void SetLevel(EventOption level)
        {
            _level = level;
        }
        /// <summary>
        /// Логирование события с важность: Fatal
        /// </summary>
        /// <param name="currentMessage">Сообщение вызванного события</param>
        public void LogFatal(string currentMessage)
        {
            CreateEventLog(currentMessage, EventOption.Fatal);
        }
        /// <summary>
        /// Логирование события с важность: Error
        /// </summary>
        /// <param name="currentMessage">Сообщение вызванного события</param>
        public void LogError(string currentMessage)
        {
            CreateEventLog(currentMessage, EventOption.Error);
        }
        /// <summary>
        /// Логирование события с важность: Warn
        /// </summary>
        /// <param name="currentMessage">Сообщение вызванного события</param>
        public void LogWarn(string currentMessage)
        {
            CreateEventLog(currentMessage, EventOption.Warn);
        }
        /// <summary>
        /// Логирование события с важность:  Info
        /// </summary>
        /// <param name="currentMessage">Сообщение вызванного события</param>
        public void LogInfo(string currentMessage)
        {
            CreateEventLog(currentMessage, EventOption.Info);
        }
        /// <summary>
        /// Логирование события с важность: Debug
        /// </summary>
        /// <param name="currentMessage">Сообщение вызванного события</param>
        public void LogDebug(string currentMessage)
        {
            CreateEventLog(currentMessage, EventOption.Debug);
        }
        /// <summary>
        /// Логирование события с важность: Trace 
        /// </summary>
        /// <param name="currentMessage">Сообщение вызванного события</param>
        public void LogTrace(string currentMessage)
        {
            CreateEventLog(currentMessage, EventOption.Trace);
        }
        /// <summary>
        /// Запись в коллекцию произошедших событий
        /// </summary>
        /// <param name="currentMessage">Сообщение вызванного события</param>
        /// <param name="eventImportance">Важность вызванного события</param>
        public void CreateEventLog(string currentMessage, EventOption eventImportance)
        {
            var currentEventLog = new EventLog
            {
                // Номер события по порядку
                EventNumber = EventLogList.Count + 1,
                // Дата и время когда произошло событие
                EventDate = DateTime.Now,
                // Важность события
                EventImportance = eventImportance,
                // Сообщение события
                EventMessage = currentMessage
            };
            // Запись текущего события в список
            EventLogList.Add(currentEventLog);
            // Вызов метода записи при условие, что текущий уровень важносты (currentEventLog.EventImportance)
            // выше или такой же как разрешенный уровень (_level) для записи в текущем экземпляре.
            if (currentEventLog.EventImportance <= _level)
            {
                Sender.SendTo(currentEventLog, currentEventLog.EventImportance);
            }
            
        }
    }
}