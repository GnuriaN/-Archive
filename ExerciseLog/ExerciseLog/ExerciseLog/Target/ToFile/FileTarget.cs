using System;
using System.IO;

namespace ExerciseLog
{
    /// <summary>
    /// ������ ������� � ����
    /// </summary>
    public class FileTarget : ITarget
    {
        /// <summary>
        /// �������� ���� ��� �������� StreamWriter
        /// </summary>
        private StreamWriter _steamFileToSave;
        /// <summary>
        /// ���� ��� �������� ������� ������ ���������
        /// </summary>
        public MakeFormat makeFormat;
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
        /// ������ ��� ������ ������� � ����
        /// </summary>
        public FileTarget(string fileName, string pathToFile = null)
        {
            // ������� �������� ������� ��� ������ �������
            makeFormat = new MakeFormat();
            // ��������. ���� ���� �� ������, �� ������������ ������� �������
            if (pathToFile == null) pathToFile = AppDomain.CurrentDomain.BaseDirectory;
            // ������ ���� �� �����
            var fullFileName = pathToFile + fileName;
            // ������� ������ ��� ������ � ������������ ����������� 
            var fileToSave = new FileToSave(fullFileName);
            // ��������� ����� ��� �� ������ 
            _steamFileToSave = fileToSave.SteamFileToSave;
        }
        /// <summary>
        /// ���������� ���������� ITarget ��� ������ � ����
        /// </summary>
        /// <param name="currentLog">������� �������</param>
        /// <param name="eventOption">������� �������� �������</param>
        public void SendTo(EventLog currentLog, EventOption eventOption)
        {
            // ������������ ������ � �������� �����
            _steamFileToSave.WriteLine(makeFormat.ToFormat(currentLog));
            // ������������� ���������� � ���� ������ �����
            _steamFileToSave.Flush();
        }
    }
}