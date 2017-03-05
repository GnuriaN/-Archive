using System;
using ExerciseLog;

namespace TestEventLog
{
    class Program
    {
        static void Main(string[] args)
        {

            // Переопределяем точку назначения запись
            // EventLogRepository.Instance[""].Sender = new EmailTarget(smtpServer: "smtp.mail.ru", smtpPort: 25, from: TestEmail.EventEmail1.From, password: TestEmail.EventEmail1.Password, mailto: "info@sabaka.net", subject: "Message from EventLog system", attachFile: null);
            /*  " from: TestEmail.EventEmail1.From, password: TestEmail.EventEmail1.Password "
             *  
             *  namespace ExerciseLog
             *  {
             *      public static class TestEmail
             *      {
             *          public static class EventEmail1
             *          {
             *              public static string From = "eventlog@sabaka.net";
             *              public static string Password = "!qazsw23ert!";
             *          }
             *      }
             *  }
             *  
             */
            // EventLogRepository.DefaultLog.Sender = new MsEventLogJournalTarget(eventJournalSource: "Application",codeEvent: 55555, category: 6);

            // Переопределяем точку назначения запись для дефолтного лога
            // EventLogRepository.DefaultLog.Sender = new FileTarget("dedault.log");
            EventLogRepository.DefaultLog.Sender = new MsEventLogJournalTarget(eventJournalSource: "Application",codeEvent: 55555, category: 6);
            EventLogRepository.DefaultLog.Sender.SetFormat(@"{number:true} {date:dd.MM.yyyy} {time:HH:MM:ss} {importance:true} {message:true}");
            //EventLogRepository.DefaultLog.SetLevel(EventOption.Trace);

            string eks = "";

            // Инициализируем экземпляр словаря
            eks = "one";

            EventLogRepository.Create(eks);
            // Переопределяем точку назначения запись
            EventLogRepository.Instance[eks].Sender = new FileTarget("log.log");
            EventLogRepository.Instance[eks].Sender.SetFormat(@"{number:true} {time:HH:MM:ss} {importance:true} {message:true}");
            //EventLogRepository.Instance[eks].SetLevel(EventOption.Fatal);
            
            // Инициализируем экземпляр словаря
            eks = "two";

            EventLogRepository.Create(eks);
            // Переопределяем точку назначения запись
            EventLogRepository.Instance[eks].Sender = new MsEventLogJournalTarget(eventJournalSource: "Application", codeEvent: 55555, category: 6);
            EventLogRepository.Instance[eks].Sender.SetFormat(@"{number:true} {time:HH:MM:ss} {message:true}");
            //EventLogRepository.Instance[eks].SetLevel(EventOption.Info);

            // Пишем в именной лог one
            eks = "one";

            // Fatal, Error, Warn, Info, Debug, Trace => Тестируем с помощью единого метода CreateEventLog
            Console.WriteLine("Тестирование CreateEventLog с использованием enum EventOption\n");
            Console.WriteLine("\nТестирование EventLogRepository.Instance[{0}].CreateEventLog()", eks);
            EventLogRepository.Instance[eks].CreateEventLog("Fall event", EventOption.Fatal);
            
            Console.WriteLine("\nТестирование EventLogRepository.Instance[{0}].CreateEventLog()", eks);
            EventLogRepository.Instance[eks].CreateEventLog("Error event", EventOption.Error);
            
            Console.WriteLine("\nТестирование EventLogRepository.Instance[{0}].CreateEventLog()", eks);
            EventLogRepository.Instance[eks].CreateEventLog("Warn event", EventOption.Warn);
            
            Console.WriteLine("\nТестирование EventLogRepository.Instance[{0}].CreateEventLog()", eks);
            EventLogRepository.Instance[eks].CreateEventLog("Info event", EventOption.Info);
            
            // А вот тут я хочу записать в логгер по умолчанию
            Console.WriteLine("\nТестирование EventLogRepository.DefaultLog.CreateEventLog()");
            EventLogRepository.DefaultLog.CreateEventLog("Debug event", EventOption.Debug);

            Console.WriteLine("\nТестирование EventLogRepository.Instance[{0}].CreateEventLog()", eks);
            EventLogRepository.Instance[eks].CreateEventLog("Trace event", EventOption.Trace);
            
            Console.WriteLine("\nТестирование Log#");
            // Fatal, Error, Warn, Info, Debug, Trace => Тестируем с помощью метода Log# 
            Console.WriteLine("\nТестирование EventLogRepository.Instance[{0}].LogFatal", eks);
            EventLogRepository.Instance[eks].LogFatal("Fall event");
            
            Console.WriteLine("\nТестирование EventLogRepository.Instance[{0}].LogError", eks);
            EventLogRepository.Instance[eks].LogError("Error event");
            
            Console.WriteLine("\nТестирование EventLogRepository.Instance[{0}].LogWarn", eks);
            EventLogRepository.Instance[eks].LogWarn("Warn event");
            
            // а теперь попишем в логер "two"
            eks = "two";

            Console.WriteLine("\nТестирование EventLogRepository.Instance[{0}].LogInfo", eks);
            EventLogRepository.Instance[eks].LogInfo("Info event");

            Console.WriteLine("\nТестирование EventLogRepository.Instance[{0}].LogDebug", eks);
            EventLogRepository.Instance[eks].LogDebug("Debug event");
            
            // и снова пишем в "one"
            eks = "one";

            // Но я передумал и написал в лог по умолчанию.
            Console.WriteLine("\nТестирование EventLogRepository.DefaultLog].LogTrace");
            EventLogRepository.DefaultLog.LogTrace("Trace event");
            
            Console.WriteLine("\n -= ВСЕ =-");

            // Что должно получится при условие
            // 1 - EventLogRepository.DefaultLog.Sender = new ConsoleTarget(); 
            // 2 - EventLogRepository.Instance["one"].Sender = new ConsoleTarget();
            // 3 - EventLogRepository.Instance["two"].Sender = new MsEventLogJournalTarget();
            //
            // Записей на консоле:
            //  - DefaultLog = 2 записи
            //  - Instance["one"] = 8 записей
            // Записей в Журнал Windows(Приложения)
            //  - Instance["two"] = 2 записи
            // 
            // Console.WriteLine("Записей из 2 / {0}", EventLogRepository.DefaultLog.EventLogList.Count);
            // Console.WriteLine("Записей из 8 / {0}", EventLogRepository.Instance["one"].EventLogList.Count);
            // Console.WriteLine("Записей из 2 / {0}", EventLogRepository.Instance["two"].EventLogList.Count);
            // 
            // Тест пройдет.

            Console.ReadKey();
        }
    }
}
