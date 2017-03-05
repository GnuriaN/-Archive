using System;
using System.Runtime.InteropServices;

namespace ExerciseLog
{
    /// <summary>
    /// Отправка по почте
    /// </summary>
    public class EmailTarget : ITarget
    {
        /// <summary>
        /// Поле для хранения формата вывода сообщения
        /// </summary>
        public MakeFormat makeFormat;
        /// <summary>
        /// Объект почтового ящика для вывода сообщения
        /// </summary>
        private EmailToSend emailToSend;
        /// <summary>
        /// Шаблон вывода событий.
        /// </summary>
        /// <param name="format">Формат шаблона</param>
        public void SetFormat(string format)
        {
            makeFormat._formatTextSender = format;
            makeFormat.Make();
        }
        /// <summary>
        /// Почтовый ящик для получения сообщений логера
        /// </summary>
        public EmailTarget(string smtpServer, int smtpPort, string from, string password, string mailto, string subject, string attachFile) 
        {
            //Устанавливаем формат вывода 
            makeFormat = new MakeFormat();
            //Создаем объект
            emailToSend = new EmailToSend(smtpServer, smtpPort, from, password, mailto, subject, attachFile);
        }
        /// <summary>
        /// Реализация интерфейса ITarget для отправки по почте
        /// </summary>
        /// <param name="currentLog">Текущее событие</param>
        /// <param name="eventOption">Текущая важность события</param>
        public void SendTo(EventLog currentLog, EventOption eventOption)
        {
            //Отправка сообщения
            SendMail(message: makeFormat.ToFormat(currentLog));
        }
        /// <summary>
        /// Отправка письма на почтовый ящик _mail _send
        /// </summary>
        /// <param name="message">Сообщение</param>
        public void SendMail(string message)
        {
            try
            {
                // Добавляем текст сообщения
                emailToSend.MailMessage.Body = message;
                // Отправка подготовленного экземпляра сообщения _mailMessage с подготовленными характеристиками
                // экземпляра smtpClient
                emailToSend.SmtpClient.Send(emailToSend.MailMessage);
                // Console.WriteLine("!!! Пиьмо ушло !!!");
            }
            catch (Exception exception)
            {
                throw new Exception("Mail.Send: " + exception.Message);
            }
        }
    }
}