namespace ExerciseLog
{
    /// <summary>
    /// Вывод события в ...
    /// </summary>
    public interface ITarget
    {
        /// <summary>
        /// Интерфейс для записи события
        /// </summary>
        /// <param name="currentLog">Текущее событие</param>
        /// <param name="eventOption">Текущая важность события</param>
        void SendTo(EventLog currentLog, EventOption eventOption);
        /// <summary>
        /// Установка шаблона для преобразования
        /// по умолчанию
        /// "{number:true} {date:dd.MM.yyyy} {time:HH:MM:ss} {importance:true} {message:true}"
        /// </summary>
        /// <param name="format"></param>
        void SetFormat(string format);
    }
}