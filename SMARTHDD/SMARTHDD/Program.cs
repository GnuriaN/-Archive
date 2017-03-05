using System;
using System.Collections.Generic;

namespace SMARTHDD
{
    /// <summary>
    /// Origin code: http://www.cyberforum.ru/csharp-beginners/thread1099026.html
    /// 
    /// -----------------------------------------------------------------------------------------------
    /// Программа не может сравнится с Crystal Disk Info или HD Tune Pro 
    /// Она писалась для себя, что бы попробывть. В качестве исходного кода был взят код указанный выше.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Основная программа
        /// </summary>
        public static void Main()
        {
            var blockDevicesSmart = new BlockDevicesSmart();
            // Проверка на наличие ошибок при получение доступа в WMI
            if (!blockDevicesSmart.IsErrorsAccess)
            {
                // Вывод на экран результатов...
                foreach (var drive in blockDevicesSmart.dicDrives)
                {
                    PrintResultTable(drive);
                }
            }
            else
            {
                Console.WriteLine(blockDevicesSmart);
            }

            CloseProgram();
        }
        /// <summary>
        /// Заглушка для ожидания нажатия любой клавиши
        /// </summary>
        static void CloseProgram()
        {
            Console.WriteLine("Press any key ...");
            Console.ReadKey();
        }
        /// <summary>
        /// Вывод в виде таблицы полученных значений S.M.A.R.T.
        /// </summary>
        /// <param name="drive">Текущий диск</param>
        private static void PrintResultTable(KeyValuePair<int, BlockDevices> drive)
        {
            var tLine = "+----------------------------------+-------+-------+-----------+----------+--------+";
            var diskInfo = string.Format("| {0,-80} |", string.Format("DRIVE: {0} S/N: {1} Type: {2} Status: {3}", drive.Value.Model, drive.Value.Serial, drive.Value.Type, ((drive.Value.IsOK) ? "OK" : "BAD")));
            var tSmartInfo = string.Format("| {0,-32} | {1,-5} | {2,-5} | {3,-9} | {4,-8} | {5,-6} |", "ID", "Value", "Worst", "Threshold", "Raw", "Status");

            Console.WriteLine("+----------------------------------------------------------------------------------+");
            Console.WriteLine(diskInfo);
            Console.WriteLine(tLine);
            Console.WriteLine(tSmartInfo);
            Console.WriteLine(tLine);

            foreach (var attr in drive.Value.Attributes)
            {
                if (attr.Value.HasData)
                    Console.WriteLine("| {0,-32} |  {1,3}  |  {2,3}  | {3,9} | {4,8} |  {5,-4}  |", attr.Value.Attribute, attr.Value.Value, attr.Value.Worst, attr.Value.Threshold, attr.Value.Raw, ((attr.Value.IsOK) ? "OK" : ""));
            }

            Console.WriteLine(tLine);
            Console.WriteLine();
        }
    }
}