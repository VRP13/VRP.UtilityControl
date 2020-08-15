using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using VRP.UtilityControl.BL.Model;

namespace VRP.UtilityControl.BL.Controller
{
    public class UserController : BaseController
    {
        private const string USERS_DATA_FILE = "users.dat";
        public List<User> Users { get; }
        public User CurrentUser { get; }
        public bool IsNewUser { get; } = false;
        public UserController(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не может быть пустым.", nameof(name));
            }
            Users = GetUsersData();
            CurrentUser = Users.SingleOrDefault(user => user.Name == name);
            if(CurrentUser == null)
            {
                CurrentUser = new User(name);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }
        private List<User> GetUsersData()
        {
            return Load<List<User>>(USERS_DATA_FILE) ?? new List<User>();
        }
        public void SetNewUserData(string city, string street, string house, string flat)
        {
            #region Проверки
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
            CurrentUser.City = city;
            CurrentUser.Street = street;
            CurrentUser.House = house;
            CurrentUser.Flat = flat;
            Save();
        }
        public void Save()
        {
            Save(USERS_DATA_FILE, Users);
        }
    }
}
