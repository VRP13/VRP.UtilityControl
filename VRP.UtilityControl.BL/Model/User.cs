using System;

namespace VRP.UtilityControl.BL.Model
{
    [Serializable]
    public class User
    {
        #region Свойства
        public string Name { get; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Flat { get; set; }
        #endregion
        public User(string name, string city, string street, string house, string flat)
        {
            #region Проверки
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не может быть пустым.", nameof(name));
            }
            if (string.IsNullOrWhiteSpace(city))
            {
                throw new ArgumentNullException("Название города не может быть пустым.", nameof(city));
            }
            if (string.IsNullOrWhiteSpace(street))
            {
                throw new ArgumentNullException("Название улицы не может быть пустым.", nameof(street));
            }
            if (string.IsNullOrWhiteSpace(house))
            {
                throw new ArgumentNullException("Номер дома не может быть пустым.", nameof(house));
            }
            if (string.IsNullOrWhiteSpace(flat))
            {
                throw new ArgumentNullException("Номер квартиры не может быть пустым.", nameof(flat));
            }
            #endregion
            Name = name;
            City = city;
            Street = street;
            House = house;
            Flat = flat;
        }
        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не может быть пустым.", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return $"{Name}: гор.{City}, ул.{Street}, {House}-{Flat}.";
        }
    }
}
