using System;
using System.Collections.Generic;
using System.Linq;

namespace VRP.UtilityControl.BL.Model
{
    [Serializable]
    public class Bill
    {
        #region Свойства
        public User User { get; }
        public DateTime Date { get; }
        public Dictionary<Utility, decimal> Bills { get; }
        #endregion
        public Bill(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.", nameof(user));
            Date = DateTime.Today;
            Bills = new Dictionary<Utility, decimal>();
        }
        public void Add(Utility Utility, decimal Money)
        {
            var utility = Bills.Keys.FirstOrDefault(u => u.Name.Equals(Utility.Name));
            if(utility == null)
            {
                Bills.Add(Utility, Money);
            }
            else
            {
                Bills[utility] += Money;
            }
        }
    }
}
