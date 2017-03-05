namespace ExerciseLog
{
    /// <summary>
    /// Перечисляемый тип данных куда выводятся данные о событие
    /// </summary>
    public enum OutputToOption
    {
        ToConsol = 0,
        ToFile,
        ToEmail,
        ToWindowsEventLog
    };
}