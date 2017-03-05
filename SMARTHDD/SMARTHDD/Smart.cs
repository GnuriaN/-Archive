namespace SMARTHDD
{
    /// <summary>
    /// Объект S.M.A.R.T.
    /// </summary>
    public class Smart
    {
        /*
        Attribute - имя атрибута;
        ID - номер атрибута;
        Value - значение атрибута(выше лучше);
        Threshold - пороговое значения атрибута(если значение меньше чем Threshold, готовьтесь к неприятностям);
        Worst - самое низкое значение атрибута за все время тестирования;
        Raw - текущее значение атрибута в 16-ричном значении(меньше лучше);
        Type - тип атрибута(PR - Performance-related, ER - Error rate, EC - Events count, SP - Self-preserve).
        */
        /// <summary>
        /// Флаг, есть ли какое либо значение у текущего атребута 
        /// </summary>
        public bool HasData => Value != 0 || Worst != 0 || Threshold != 0 || Raw != 0;
        /// <summary>
        /// Наименование атрибута S.M.A.R.T. 
        /// </summary>
        public string Attribute { get; set; }
        /// <summary>
        /// Значение атрибута
        /// </summary>
        public int Value { get; set; }
        /// <summary>
        /// Cамое низкое значение атрибута
        /// </summary>
        public int Worst { get; set; }
        /// <summary>
        /// Пороговое значения атрибута
        /// </summary>
        public int Threshold { get; set; }
        /// <summary>
        /// Текущее значение атрибута
        /// </summary>
        public int Raw { get; set; }
        /// <summary>
        /// Статус атрибута
        /// </summary>
        public bool IsOK { get; set; }
        /// <summary>
        /// Объект S.M.A.R.T.
        /// </summary>
        public Smart()
        {
        }
        /// <summary>
        /// Инициализация объекта S.M.A.R.T. с установкой наименование атрибута S.M.A.R.T.
        /// </summary>
        /// <param name="attributeName">Наименование атрибута S.M.A.R.T.</param>
        public Smart(string attributeName)
        {
            this.Attribute = attributeName;
        }
    }
}