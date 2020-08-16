using System;
using System.Collections.Generic;
using System.Linq;
using VRP.UtilityControl.BL.Model;

namespace VRP.UtilityControl.BL.Controller
{
    public class BillController : BaseController
    {
        #region Свойства
        private const string UTILITIES_DATA_FILE = "utilities.dat";
        private const string BILLS_DATA_FILE = "bills.dat";
        private readonly User user;
        public List<Utility> Utilities { get; }
        public Bill Bill { get; }
        #endregion
        public BillController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.", nameof(user));
            Utilities = GetUtilities();
            Bill = GetBill();
        }
        public void Add(Utility utility, decimal money)
        {
            var newUtility = Utilities.SingleOrDefault(u => u.Name == utility.Name);
            if(newUtility == null)
            {
                Utilities.Add(utility);
                Bill.Add(utility, money);
            }
            else
            {
                Bill.Add(newUtility, money);
            }
            Save();
        }

        private Bill GetBill()
        {
            return Load<Bill>(BILLS_DATA_FILE) ?? new Bill(user);
        }

        private List<Utility> GetUtilities()
        {
            return Load<List<Utility>>(UTILITIES_DATA_FILE) ?? new List<Utility>();
        }
        public void Save()
        {
            Save(UTILITIES_DATA_FILE, Utilities);
            Save(BILLS_DATA_FILE, Bill);
        }
    }
}
