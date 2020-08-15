using System;

namespace VRP.UtilityControl.BL.Model
{
    [Serializable]
    public class Utility
    {
        #region Свойства
        public string Name { get; }
        public double Tariff { get; private set; }
        public int Volume { get; set; }
        public decimal Cost { get { return (decimal)Tariff * Volume; } }
        #endregion
        public Utility(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Название услуги не может быть пустым.", nameof(name));
            }
            Name = name;
        }
        public Utility(string name, double tariff, int volume)
        {
            #region Проверки
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Название услуги не может быть пустым.", nameof(name));
            }
            if(tariff <= 0)
            {
                throw new ArgumentException("Тариф не может быть меньше или равен нулю.", nameof(tariff));
            }
            if(volume < 0)
            {
                throw new ArgumentException("Объем услуги не может быть отрицательным.", nameof(volume));
            }
            #endregion
            Name = name;
            Tariff = tariff;
            Volume = volume;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
