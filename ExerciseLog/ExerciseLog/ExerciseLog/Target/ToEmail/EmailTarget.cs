using System;
using System.Runtime.InteropServices;

namespace ExerciseLog
{
    /// <summary>
    /// �������� �� �����
    /// </summary>
    public class EmailTarget : ITarget
    {
        /// <summary>
        /// ���� ��� �������� ������� ������ ���������
        /// </summary>
        public MakeFormat makeFormat;
        /// <summary>
        /// ������ ��������� ����� ��� ������ ���������
        /// </summary>
        private EmailToSend emailToSend;
        /// <summary>
        /// ������ ������ �������.
        /// </summary>
        /// <param name="format">������ �������</param>
        public void SetFormat(string format)
        {
            makeFormat._formatTextSender = format;
            makeFormat.Make();
        }
        /// <summary>
        /// �������� ���� ��� ��������� ��������� ������
        /// </summary>
        public EmailTarget(string smtpServer, int smtpPort, string from, string password, string mailto, string subject, string attachFile) 
        {
            //������������� ������ ������ 
            makeFormat = new MakeFormat();
            //������� ������
            emailToSend = new EmailToSend(smtpServer, smtpPort, from, password, mailto, subject, attachFile);
        }
        /// <summary>
        /// ���������� ���������� ITarget ��� �������� �� �����
        /// </summary>
        /// <param name="currentLog">������� �������</param>
        /// <param name="eventOption">������� �������� �������</param>
        public void SendTo(EventLog currentLog, EventOption eventOption)
        {
            //�������� ���������
            SendMail(message: makeFormat.ToFormat(currentLog));
        }
        /// <summary>
        /// �������� ������ �� �������� ���� _mail _send
        /// </summary>
        /// <param name="message">���������</param>
        public void SendMail(string message)
        {
            try
            {
                // ��������� ����� ���������
                emailToSend.MailMessage.Body = message;
                // �������� ��������������� ���������� ��������� _mailMessage � ��������������� ����������������
                // ���������� smtpClient
                emailToSend.SmtpClient.Send(emailToSend.MailMessage);
                // Console.WriteLine("!!! ����� ���� !!!");
            }
            catch (Exception exception)
            {
                throw new Exception("Mail.Send: " + exception.Message);
            }
        }
    }
}