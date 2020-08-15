using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using VRP.UtilityControl.BL.Model;

namespace VRP.UtilityControl.BL.Controller
{
    public class PaymentController : BaseController
    {
        private const string UTILITIES_DATA_FILE = "utilities.dat";
        private const string PAYMENTS_DATA_FILE = "payments.dat";
        private readonly User user;
        public List<Utility> Utilities { get; }
        public Payment Payment { get; }
        public PaymentController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.", nameof(user));
            Utilities = GetUtilities();
            Payment = GetPayment();
        }
        public void Add(Utility utility, decimal money)
        {
            var newUtility = Utilities.SingleOrDefault(u => u.Name == utility.Name);
            if(newUtility == null)
            {
                Utilities.Add(utility);
                Payment.Add(utility, money);
                Save();
            }
            else
            {
                Payment.Add(newUtility, money);
                Save();
            }
        }

        private Payment GetPayment()
        {
            return Load<Payment>(PAYMENTS_DATA_FILE) ?? new Payment(user);
        }

        private List<Utility> GetUtilities()
        {
            return Load<List<Utility>>(UTILITIES_DATA_FILE) ?? new List<Utility>();
        }
        public void Save()
        {
            Save(UTILITIES_DATA_FILE, Utilities);
            Save(PAYMENTS_DATA_FILE, Payment);
        }
    }
}
