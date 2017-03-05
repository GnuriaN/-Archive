using System;
using System.Collections.Generic;

namespace TCotSC
{
    /// <summary>
    /// Список текущих сигарет
    /// </summary>
    public class CigarettesRepository
    {
        /// <summary>
        /// Экземпляр класса CigarettesRepository
        /// </summary>
        private static readonly CigarettesRepository СigarettesNow = new CigarettesRepository();
        /// <summary>
        /// Последняя запись
        /// </summary>
        private long _lastCount = 0;
        /// <summary>
        /// Список текущих сигарет
        /// </summary>
        public List<Cigarete> CigarettesList = new List<Cigarete>();
        /// <summary>
        /// Точка назначения вывода событий
        /// </summary>
        public ITargetOpen Opener = new OpenFile();
        /// <summary>
        /// Точка назначения вывода событий
        /// </summary>
        public ITargetSave Sender = new SaveToFile();
        /// <summary>
        /// Доступ к сигаретам
        /// </summary>
        public static CigarettesRepository CigarettesNow
        {
            get { return СigarettesNow; }
        }
        /// <summary>
        /// Закрытый конструктор класса
        /// </summary>
        private CigarettesRepository()
        {
            // Необходимо получить данные о последней записи
            _lastCount = Opener.LastCountRecord();
        }
        /// <summary>
        /// Добавление в словарь сигареты
        /// </summary>
        public void AddNow(LabelCigarettes currentLabel)
        {
            // изменяем значение поледней записи
            _lastCount++;
            // Создаем объект тукущей сигареты и заполняем его поля
            var currentCigarette = new Cigarete
            {
                СigaretteCount = _lastCount,
                СigaretteDateTime = DateTime.Now,
                СigaretteLabel = currentLabel
            };
            // Добавляем текущую сигарету к списку 
            CigarettesList.Add(currentCigarette);
            // Отправить текущую сигарету для записи в Sender
            Sender.SendTo(currentCigarette);
        }
    }
}