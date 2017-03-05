namespace TCotSC
{
    /// <summary>
    /// Вывод в ...
    /// </summary>
    public interface ITargetSave
    {
        /// <summary>
        /// Запись в ...
        /// </summary>
        /// <param name="currentCigarette">Информаци о текущей сигарете</param>
        void SendTo(Cigarete currentCigarette);
    }
}