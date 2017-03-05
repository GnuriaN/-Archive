using System;
using System.Collections.Generic;
using System.Management;

namespace SMARTHDD
{
    public class BlockDevicesSmart
    {
        /// <summary>
        /// Создаем словарь Dictionary<Номер диска, Объект HDD>();
        /// </summary>
        public Dictionary<int, BlockDevices> dicDrives;
        /// <summary>
        /// Наличие ошибок доступа к WMI
        /// </summary>
        public bool IsErrorsAccess { get; set; } = false;
        /// <summary>
        /// Сообщение об ошибке доступа к WMI
        /// </summary>
        public string Errors { get; set; } = "No";
        /// <summary>
        /// Информация S.A.M.R.T. по всем дискам
        /// </summary>
        public BlockDevicesSmart()
        {
            // Если экземпляр данного класа уже создан, то не создавать новый экземпляр
            if (_create) return;
            _create = true;
            // Создаем словарь Dictionary<Номер диска, Объект HDD>();
            dicDrives = new Dictionary<int, BlockDevices>();
            GetHDD();
            GetSMART();
        }
        /// <summary>
        /// Создал ли класс
        /// </summary>
        private readonly bool _create = false;
        /// <summary>
        /// Получение информации о дисках
        /// </summary>
        public void GetHDD()
        {
            // Получаем данные о дисках в системе и заносим их в словарь
            try
            {
                // Индекс устройства
                var iDriveIndex = 0;
                // Создаем словарь Dictionary<Номер диска, Объект HDD>();
                var wdSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
                // Делаем запрос по всем мультимидийным устройствам хранения информации
                var pmSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
                // Установка начального индекса диска
                iDriveIndex = 0;
                // Поиск всех физическим дискам 
                foreach (var drive in wdSearcher.Get())
                {
                    var hdd = new BlockDevices
                    {
                        Model = drive["Model"].ToString().Trim(),
                        Type = drive["InterfaceType"].ToString().Trim()
                    };
                    // Отрезаем все диски, что не интерпритируются как IDE, так как только с них получаеться S.M.A.R.T.
                    if (hdd.Type != "IDE") continue;
                    dicDrives.Add(iDriveIndex, hdd);
                    iDriveIndex++;
                }
                // Делаем запрос на получение сирийного номера
                iDriveIndex = 0;
                foreach (var drive in pmSearcher.Get())
                {
                    // Нам нужны только жеские диски подключеные напрямую к системе
                    if (iDriveIndex >= dicDrives.Count)
                        break;

                    dicDrives[iDriveIndex].Serial = drive["SerialNumber"]?.ToString().Trim() ?? "None";
                    iDriveIndex++;
                }
            }
            catch (ManagementException e)
            {
                IsErrorsAccess = true;
                Errors = string.Format("An error occurred while querying for WMI data: " + e.Message);
            }
        }
        /// <summary>
        /// Получение информации S.M.A.R.T. по дискам
        /// </summary>
        public void GetSMART()
        {
            // Для отлова исключений
            try
            {
                // Индекс устройства
                var iDriveIndex = 0;
                // Получаем данные по устройствам через WMI (требуются права администратора)
                var searcher = new ManagementObjectSearcher("Select * from Win32_DiskDrive")
                {
                    // Путь для области построение запроса
                    Scope = new ManagementScope(@"\root\wmi"),
                    Query = new ObjectQuery("Select * from MSStorageDriver_FailurePredictStatus")
                };
                // Делаем запрос по всем мультимидийным устройствам хранения информации для получения статуса S.M.A.R.T.
                iDriveIndex = 0;
                foreach (var drive in searcher.Get())
                {
                    // Отрезаем все диски, что не интерпритируются как SCSI, так как только с них получаеться S.M.A.R.T.
                    if (drive.Properties["InstanceName"].Value.ToString().Substring(0, 4) != "SCSI") continue;

                    dicDrives[iDriveIndex].IsOK = (bool)drive.Properties["PredictFailure"].Value == false;
                    iDriveIndex++;
                }
                // Запрос на получение атрибутов flags, value worste
                searcher.Query = new ObjectQuery("Select * from MSStorageDriver_FailurePredictData");
                iDriveIndex = 0;
                foreach (var data in searcher.Get())
                {
                    var bytes = (byte[])data.Properties["VendorSpecific"].Value;
                    for (var i = 0; i < 30; ++i)
                    {
                        try
                        {
                            int id = bytes[i * 12 + 2];
                            int flags = bytes[i * 12 + 4]; // least significant status byte, +3 most significant byte, but not used so ignored.
                                                           // bool advisory = (flags & 0x1) == 0x0;
                            var failureImminent = (flags & 0x1) == 0x1;

                            int value = bytes[i * 12 + 5];
                            int worst = bytes[i * 12 + 6];
                            var vendordata = BitConverter.ToInt32(bytes, i * 12 + 7);
                            if (id == 0) continue;

                            var attr = dicDrives[iDriveIndex].Attributes[id];
                            attr.Value = value;
                            attr.Worst = worst;
                            attr.Raw = vendordata;
                            attr.IsOK = failureImminent == false;
                        }
                        catch
                        {
                            // Не существует ключа атрибута.
                        }
                    }
                    iDriveIndex++;
                }
                // Запрос на получение пороговых значений атрибутов 
                searcher.Query = new ObjectQuery("Select * from MSStorageDriver_FailurePredictThresholds");
                iDriveIndex = 0;
                foreach (var data in searcher.Get())
                {
                    var bytes = (byte[])data.Properties["VendorSpecific"].Value;
                    for (var i = 0; i < 30; ++i)
                    {
                        try
                        {
                            int id = bytes[i * 12 + 2];
                            int thresh = bytes[i * 12 + 3];
                            if (id == 0) continue;
                            var attr = dicDrives[iDriveIndex].Attributes[id];
                            attr.Threshold = thresh;
                        }
                        catch
                        {
                            //  Не существует ключа атрибута.
                        }
                    }
                    iDriveIndex++;
                }
            }
            catch (ManagementException e)
            {
                IsErrorsAccess = true;
                Errors = string.Format("Ошибка получения данных из WMI: " + e.Message);
            }
        }
    }
}