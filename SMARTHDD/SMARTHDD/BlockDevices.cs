using System.Collections.Generic;

namespace SMARTHDD
{
    /// <summary>
    /// Блочное устройство поддерживающее S.M.A.R.T.
    /// </summary>
    public class BlockDevices
    {
        /// <summary>
        /// Порядковый номер устройства
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// Статус состояния устройства
        /// </summary>
        public bool IsOK { get; set; }
        /// <summary>
        /// Модель устройства
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// Тип устройства
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Серийный номер устройства
        /// </summary>
        public string Serial { get; set; }
        /// <summary>
        /// Словарь состояния устройства согласно S.M.A.R.T.
        /// Attributes состоият из кода атрибута и объекта S.M.A.R.T. инициализированного наименование атрибута.
        /// Полный перечень кодов http://www.hdsentinel.com/help/en/56_attrib.html
        /// </summary>
        public Dictionary<int, Smart> Attributes = new Dictionary<int, Smart>()
        {
            {0x00, new Smart("Invalid")},
            {0x01, new Smart("Raw read error rate")},
            {0x02, new Smart("Throughput performance")},
            {0x03, new Smart("Spinup time")},
            {0x04, new Smart("Start/Stop count")},
            {0x05, new Smart("Reallocated sector count")},
            {0x06, new Smart("Read channel margin")},
            {0x07, new Smart("Seek error rate")},
            {0x08, new Smart("Seek timer performance")},
            {0x09, new Smart("Power-on hours count")},
            {0x0A, new Smart("Spinup retry count")},
            {0x0B, new Smart("Calibration retry count")},
            {0x0C, new Smart("Power cycle count")},
            {0x0D, new Smart("Soft read error rate")},
            {0xB8, new Smart("End-to-End error")},
            {0xBB, new Smart("Reported UNC Errors")},
            {0xBC, new Smart("Command Timeout")},
            {0xBD, new Smart("High Fly Writes")},
            {0xBE, new Smart("Airflow Temperature")},
            {0xBF, new Smart("G-sense error rate")},
            {0xC0, new Smart("Power-off retract count")},
            {0xC1, new Smart("Load/Unload cycle count")},
            {0xC2, new Smart("HDD temperature")},
            {0xC3, new Smart("Hardware ECC recovered")},
            {0xC4, new Smart("Reallocation count")},
            {0xC5, new Smart("Current pending sector count")},
            {0xC6, new Smart("Offline scan uncorrectable count")},
            {0xC7, new Smart("UDMA CRC error rate")},
            {0xC8, new Smart("Write error rate")},
            {0xC9, new Smart("Soft read error rate")},
            {0xCA, new Smart("Data Address Mark errors")},
            {0xCB, new Smart("Run out cancel")},
            {0xCC, new Smart("Soft ECC correction")},
            {0xCD, new Smart("Thermal asperity rate (TAR)")},
            {0xCE, new Smart("Flying height")},
            {0xCF, new Smart("Spin high current")},
            {0xD0, new Smart("Spin buzz")},
            {0xD1, new Smart("Offline seek performance")},
            {0xD3, new Smart("Vibration During Write")},
            {0xD4, new Smart("Shock During Write")},
            {0xDC, new Smart("Disk shift")},
            {0xDD, new Smart("G-sense error rate")},
            {0xDE, new Smart("Loaded hours")},
            {0xDF, new Smart("Load/unload retry count")},
            {0xE0, new Smart("Load friction")},
            {0xE1, new Smart("Load/Unload cycle count")},
            {0xE2, new Smart("Load-in time")},
            {0xE3, new Smart("Torque amplification count")},
            {0xE4, new Smart("Power-off retract count")},
            {0xE6, new Smart("GMR head amplitude")},
            {0xE7, new Smart("Temperature")},
            {0xF0, new Smart("Head flying hours")},
            {0xFA, new Smart("Read error retry rate")},
            /* Для новых ключей */
        };
    }
}
