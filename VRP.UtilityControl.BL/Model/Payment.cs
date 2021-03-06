﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace VRP.UtilityControl.BL.Model
{
    [Serializable]
    public class Payment
    {
        #region Свойства
        public User User { get; }
        public DateTime Date { get; }
        public Dictionary<Utility, decimal> Payments { get; }
        #endregion
        public Payment(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.", nameof(user));
            Date = DateTime.Today;
            Payments = new Dictionary<Utility, decimal>();
        }
        public void Add(Utility Utility, decimal Money)
        {
            var utility = Payments.Keys.FirstOrDefault(u => u.Name.Equals(Utility.Name));
            if(utility == null)
            {
                Payments.Add(Utility, Money);
            }
            else
            {
                Payments[utility] += Money;
            }
        }
    }
}
