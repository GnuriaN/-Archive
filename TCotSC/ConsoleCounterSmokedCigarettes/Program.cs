using System;
using TCotSC;

namespace ConsoleCounterSmokedCigarettes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Делаем запись 
            Console.WriteLine("Первая сигарета");
            CigarettesRepository.CigarettesNow.AddNow(LabelCigarettes.First);
            //Sleep(5);
            Console.WriteLine("Текущая сигарета");
            CigarettesRepository.CigarettesNow.AddNow(LabelCigarettes.Current);
            //Sleep(5);
            Console.WriteLine("Текущая сигарета");
            CigarettesRepository.CigarettesNow.AddNow(LabelCigarettes.Current);
            //Sleep(5);
            Console.WriteLine("Текущая сигарета");
            CigarettesRepository.CigarettesNow.AddNow(LabelCigarettes.Current);
            //Sleep(5);
            Console.WriteLine("Последняя сигарета");
            CigarettesRepository.CigarettesNow.AddNow(LabelCigarettes.Last);
            // Выход из программы
            CloseProgram();
        }
        //-----------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Заглушка для ожидания нажатия любой клавиши
        /// </summary>
        static void CloseProgram()
        {
            Console.WriteLine("Press any key ...");
            Console.ReadKey();
        }
        /// <summary>
        /// Задержка
        /// </summary>
        /// <param name="sec">Время в секундах</param>
        static void Sleep(int sec)
        {
            Console.WriteLine("\tЗадержка на {0} секунд", sec);
            System.Threading.Thread.Sleep(sec*1000);
        }
    }
}
