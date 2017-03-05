using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace ExerciseLog
{
    /// <summary>
    /// Почтовый ящик для получения данных логера
    /// </summary>
    public class EmailToSend
    {
        //
        /// <summary>
        /// Текущие настройки для отправки сообщения
        /// </summary>
        private EmailSettrings cES;
        /// <summary>
        /// Закрытое поле для хранения MailMessage. Экземпляр тела письма
        /// </summary>
        private MailMessage _mailMessage;
        /// <summary>
        /// Закрытое поле для хранения SmtpClient. Экземпляр открытой сессии
        /// </summary>
        private SmtpClient _smtpClient;
        /// <summary>
        /// Поле для хранения MailMessage. Экземпляр тела письма
        /// </summary>
        public MailMessage MailMessage
        {
            get
            {
                return _mailMessage;
            }
            set
            {
                _mailMessage = value;
            }
        }
        /// <summary>
        /// Экземпляр открытой сессии SmtpClient
        /// </summary>
        public SmtpClient SmtpClient
        {
            get
            {
                // Проверяем открытая сейчас сессия. Если сессия закрыта то открываем ее заново если нет,
                // то возращаем текущее ее значение
                return _smtpClient ?? (_smtpClient = MailSessionInit());
            }
            set
            {
                _smtpClient = value;
            }
        }
        /// <summary>
        /// Список содержащий полный путь всех открытых фалов для записи логов
        /// </summary>
        private static List<string> setting = new List<string>();
        /// <summary>
        /// Словарь содержит полный путь к файлу для зписи и обеъект куда идет запись
        /// </summary>
        public static Dictionary<string, EmailToSend> currentEmailToSend = new Dictionary<string, EmailToSend>();
        /// <summary>
        /// Проверка настроек куда записывается логер
        /// </summary>
        /// <param name="currentSetting">Текущие настройки</param>
        /// <returns></returns>
        private bool chekSetting(string currentSetting)
        {
            // проверяем настройки 
            return setting.Any(_ => _ == currentSetting);
        }
        /// <summary>
        /// Объект для отправки по почте
        /// </summary>
        /// <param name="smtpServer">SMTP сервер</param>
        /// <param name="smtpPort">Порт для SMTP сервера</param>
        /// <param name="from">Адресат и (аккаунт) отправителя</param>
        /// <param name="password">Пароль для доступа к SMTP Серверу с использование аккаунта from</param>
        /// <param name="mailto">Получатель письма</param>
        /// <param name="subject">Тема письма</param>
        /// <param name="attachFile">Вложение в письмо </param>
        public EmailToSend(string smtpServer, int smtpPort, string from, string password, string mailto, string subject, string attachFile)
        {
            // Инициализация объекта и полей класса EmailSettrings
            cES = new EmailSettrings
            {
                SmtpServer = smtpServer,
                SmtpPort = smtpPort,
                From = @from,
                Password = password,
                Mailto = mailto,
                Subject = subject,
                AttachFile = attachFile
            };
            // Проверка существует ли такой Email-lkz отправки
            if (chekSetting(from))
            // Такой Email уже есть то присваиваем его поток для записи
            {
                // Инициализация тела письма 
                MailMessageInit();
                // Инициализация сессии с сервером
                _smtpClient = currentEmailToSend[from].MailSessionInit();
            }
            // Такого Email нет то зоздаем поток для записи
            else
            {
                // Добовляем новое значение к скиску настроек 
                setting.Add(from);
                // Записываем в словарь настроект файлов для сохранения "полный путь к файлу(currentSetting)" и объект файла (FileToSave)
                currentEmailToSend.Add(from, this);
                // Инициализация тела письма 
                MailMessageInit();
                // Инициализация сессии с сервером
                _smtpClient = MailSessionInit();
            }
        }
        /// <summary>
        /// Инициализация тела письма
        /// </summary>
        protected void MailMessageInit()
        {
            // Создаем экземпляр класса MailAddress для указания в поле FROM (Отправитель)
            var mailFrom = new MailAddress(cES.From);
            // Создаем экземпляр класса MailAddress для указания в поле TO (Получатель)
            var mailTo = new MailAddress(cES.Mailto);
            // Создаем экземпляр сообщения MailMessage для дальнейшей отправки через SMTPClient
            // Используем подготовленные для конструктора экземпляры класса MailAddress 
            // mailFrom и mailTo. Добавляем заголовок (тему) сообщения
            _mailMessage = new MailMessage(mailFrom, mailTo)
            {
                Subject = cES.Subject,
            };
            // Проверка на вложения и при наличие вложения прикрепить вложение
            // Инициализация = В настоящий момент не используется
            if (!string.IsNullOrEmpty(cES.AttachFile))
                _mailMessage.Attachments.Add(new Attachment(cES.AttachFile));
        }
        /// <summary>
        /// Инициализация соединения с почтовым сервером
        /// </summary>
        protected SmtpClient MailSessionInit()
        {
            // Создаем экземпляр класса _SmtpClient для отправки сообщения используем заранее 
            // имеющиеся параметры HOST (_smtpServer) и PORT _smtpPort
            // Сообщаем о необходимости использовать SSL сертификат (TLS)
            // Задаем данные для авторизации используя класс NetworkCredential с имеющимися данными
            // userName = from и password = password
            // Указываем как будут обрабатываться исходящие сообщения электронной почты.
            var smtpClient = new SmtpClient(cES.SmtpServer, cES.SmtpPort)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(@cES.From, cES.Password),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            return smtpClient;
        }
    }
}