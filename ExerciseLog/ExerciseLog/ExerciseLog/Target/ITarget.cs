namespace ExerciseLog
{
    /// <summary>
    /// ����� ������� � ...
    /// </summary>
    public interface ITarget
    {
        /// <summary>
        /// ��������� ��� ������ �������
        /// </summary>
        /// <param name="currentLog">������� �������</param>
        /// <param name="eventOption">������� �������� �������</param>
        void SendTo(EventLog currentLog, EventOption eventOption);
        /// <summary>
        /// ��������� ������� ��� ��������������
        /// �� ���������
        /// "{number:true} {date:dd.MM.yyyy} {time:HH:MM:ss} {importance:true} {message:true}"
        /// </summary>
        /// <param name="format"></param>
        void SetFormat(string format);
    }
}