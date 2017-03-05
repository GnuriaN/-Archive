using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseLog
{
    /// <summary>
    /// Настройки для отправки сообщения
    /// </summary>
    public class EmailSettrings
    {
        /// <summary>
        /// SMTP сервер
        /// </summary>
        public string SmtpServer { get; set; }
        /// <summary>
        /// Порт для SMTP сервера
        /// </summary>
        public int SmtpPort { get; set; }
        /// <summary>
        /// Адресат и (аккаунт) отправителя
        /// </summary>
        public string From { get; set; }
        /// <summary>
        /// Пароль для доступа к SMTP Серверу с использование аккаунта _from
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Получатель письма
        /// </summary>
        public string Mailto { get; set; }
        /// <summary>
        /// Тема письма
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Вложение в письмо 
        /// </summary>
        public string AttachFile { get; set; }
    }
}