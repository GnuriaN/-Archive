using System;

namespace ExerciseLog
{
    /// <summary>
    /// Событие
    /// </summary>
    public class EventLog
    {
        //{порядковый номер события} {дата} {время} {важность} {сообщение}
        /// <summary>
        /// Номер события
        /// </summary>
        public long EventNumber;
        /// <summary>
        /// Дата и время события
        /// </summary>
        public DateTime EventDate;
        /// <summary>
        /// Важность события
        /// </summary>
        public EventOption EventImportance;
        /// <summary>
        /// Сообщение события
        /// </summary>
        public string EventMessage;
    }
}