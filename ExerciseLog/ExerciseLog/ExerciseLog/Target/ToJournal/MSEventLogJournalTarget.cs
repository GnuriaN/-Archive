using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ExerciseLog
{
    /// <summary>
    /// ������ � ������ Microsoft Event Log
    /// </summary>
    public class MsEventLogJournalTarget : ITarget
    {
        public MakeFormat makeFormat;
        /// <summary>
        /// �������� ���� ��� �������� System.Diagnostics.EventLog
        /// </summary>
        private System.Diagnostics.EventLog eventLog;
        /// <summary>
        /// ��������� ��� �������.
        /// </summary>
        private int _codeEvent;
        /// <summary>
        /// ��������� ��������� �������.
        /// </summary>
        private short _category;
        /// <summary>
        ///  ������ ������ �������.
        /// </summary>
        /// <summary>
        ///  ������ ������ �������.
        /// </summary>
        /// <param name="format">������ �������</param>
        public void SetFormat(string format)
        {
            makeFormat._formatTextSender = format;
            makeFormat.Make();
        }
        /// <summary>
        /// ����������� ������ MSEventLogJournalTarget
        /// </summary>
        /// <param name="eventJournalSource">������ ��� ������. �� ���������: ������ � "������� Windows", ������ "����������"</param>
        /// <param name="codeEvent">��������� ��� �������. �� ���������: 55555</param>
        /// <param name="category">��������� ��������� �������.  �������� ��������: 0  =  �����������; 1  =  ����������; 2  =  ����; 3  =  ��������;
        /// 4  =  ������; 5  =  ��������; 6  =  ��������� �������; 7  =  ����  8 � ������ ������� ���� ���������� �������� ���� (��������).
        /// �� ���������: 6 </param>
        public MsEventLogJournalTarget(string eventJournalSource = "Application", int codeEvent = 55555, short category = 6)
        {
            makeFormat = new MakeFormat();
            // ��������� �������� �� ���������
            _codeEvent = codeEvent;
            _category = category;
            // ��������� ������ System.Diagnostics.EventLog ��� ������ � "��������� ������� Windows"
            eventLog = new System.Diagnostics.EventLog
            {
                // ��������� ������ ���� ������� ���������
                Source = eventJournalSource
            };
        }
        /// <summary>
        /// ���������� ���������� ITarget ��� ������ � ������ Microsoft Event Log
        /// </summary>
        /// <param name="currentLog">������� �������</param>
        /// <param name="eventOption">������� �������� �������</param>
        public void SendTo(EventLog currentLog, EventOption eventOption)
        {
            // ������ � "������� Windows", ������ "����������" 
            // ������ ����������� � ����� �����.
            // public static void WriteEntry(string message, EventLogEntryType type, int eventID, short category)
            eventLog.WriteEntry(makeFormat.ToFormat(currentLog), EventLevel(eventOption), _codeEvent, _category);
        }
        /// <summary>
        /// ��������� ���������� ������ ��������������
        /// </summary>
        /// <param name="eventOption">������� �������� �������</param>
        private System.Diagnostics.EventLogEntryType EventLevel(EventOption eventOption)
        {
            System.Diagnostics.EventLogEntryType level;
            // ��������� �������� eventOption � ���������� _level
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
string source,   -> ������ ���� � System.Provider[NAME]                                                    | ������ � "�����" ���� "��������".
string message,  -> ������ ���� � EventData                                                                | ������ � "�����" ���� "�������� ���������".
EventLogEntryType type,          -> EventLogEntryType.Information  - ������ ���� � System.Level (???)      | ������ � "�����" ���� "�������".
         {
         - Error        | Level = 1  | ������. ��������� �� ������������ ��������, � ������� ���������� �������� ������������; ��� �������, ��� ������ ������ ��� �������������� ������������.
         - FailureAudit | Level = 16 | ����� �������. ��������� �� �������, ������������ � ������� ������������ ��� ���� ��������������� �������, ����� ��� ���� ��� �������� �����.
         - Information  | Level = 4  | �����������. ��������� �� ��, ��� ������ �������� ������� ���������.
         - SuccessAudit | Level = 8  | ����� �������. ��������� �� �������, ������������ � ������� ������������ ��� �������� ������� ��������������� �������, �������� ��� �������� ����� � �������.
         - Warning      | Level = 2  | ��������������. ��������� �� �������������� ��������, �������, ������, ����� ����������������� � ������� ����������� ��� ������������� ������� � ����������.
         {
int eventID,     -> ������ ���� � System.EventID                                                           | ������ � ����� ���.  
short category,  -> ������ ���� � System.                                                                  | ������ � "�����" ���� "��������� ������"
         - 0  =  �����������
         - 1  =  ����������
         - 2  =  ����
         - 3  =  ��������
         - 4  =  ������
         - 5  =  ��������
         - 6  =  ��������� �������
         - 7  =  ����
         - 8+ =  (8+) ����������� ����� � ������� ��� ����������� ��������.
byte[] rawData   -> 
)
****************************************************************************************************************************************************************************************************/